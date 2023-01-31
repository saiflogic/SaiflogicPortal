using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Util;
using Nethereum.Web3.Accounts;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Xml;

namespace SaifLogic
{
    public class Common
    {
        SqlConnection SQLCon = new SqlConnection();
        public string GetConnString()
        {
            string connectionName = "SaifLogic_DB";
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            return connectionString;
        }
        public SqlConnection GetSQLConn()
        {
            SQLCon.ConnectionString = GetConnString();
            return SQLCon;
        }
        public string GetUserData()
        {
            FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            return ticket.UserData.ToString();
        }
        public void SQLDGFill(String DBConn, String SQL, DataTable DT)
        {
            SQLCon.ConnectionString = DBConn.ToString();
            SQLCon.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(SQL, SQLCon);
            SDA.Fill(DT);
            SQLCon.Close();
        }
        public void SQLDGFillCommand(DataTable DT, SqlCommand cmd)
        {
            SQLCon.ConnectionString = GetConnString();
            SQLCon.Open();
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            SDA.Fill(DT);
            SQLCon.Close();
        }
        public void SQLNonQueryCommand(String DBConn, String SQL)
        {
            SQLCon.ConnectionString = DBConn.ToString();
            SQLCon.Open();
            SqlCommand SQLCom = new SqlCommand(SQL, SQLCon);
            SQLCom.CommandTimeout = 120;
            SQLCom.ExecuteNonQuery();
            SQLCon.Close();
        }
        public void SQLDBConnClose()
        {
            SQLCon.Close();
        }
        public string SQLExecuteScalar(String SQL)
        {
            string ValToRead;
            SQLCon.ConnectionString = GetConnString().ToString();
            SQLCon.Open();
            SqlCommand SQLCom = new SqlCommand(SQL, SQLCon);
            try
            {
                ValToRead = SQLCom.ExecuteScalar().ToString();
            }
            catch (NullReferenceException nullEx)
            {
                ValToRead = "";
            }
            SQLCon.Close();
            return ValToRead;
        }
        public void PopluateDropdown(String SQL, DropDownList DdList, String ValueField, String TextFeild)
        {
            DataTable dt = new DataTable();
            SQLDGFill(GetConnString(), SQL, dt);
            DdList.DataSource = dt;
            DdList.DataTextField = TextFeild;
            DdList.DataValueField = ValueField;
            DdList.DataBind();
        }
        public void PopluateTelerikDropdown(String SQL, Telerik.Web.UI.RadComboBox DdList, String ValueField, String TextFeild)
        {
            DataTable dt = new DataTable();
            SQLDGFill(GetConnString(), SQL, dt);
            DdList.DataSource = dt;
            DdList.DataTextField = TextFeild;
            DdList.DataValueField = ValueField;
            DdList.DataBind();
        }
        public void PopluateTelerikDropdownDownList(String SQL, Telerik.Web.UI.RadDropDownList DdList, String ValueField, String TextFeild)
        {
            DataTable dt = new DataTable();
            SQLDGFill(GetConnString(), SQL, dt);
            DdList.DataSource = dt;
            DdList.DataTextField = TextFeild;
            DdList.DataValueField = ValueField;
            DdList.DataBind();
        }
        public void PopulateCheckBoxFromDatabase(String SQL, CheckBoxList ChkBoxList, String ValueField, String TextField)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            SQLDGFill(GetConnString(), SQL, dt);
            ChkBoxList.DataSource = dt;
            ChkBoxList.DataTextField = TextField;
            ChkBoxList.DataValueField = ValueField;
            ChkBoxList.DataBind();
        }
        public void PopluateListbox(String SQL, ListBox DdList, String ValueField, String TextFeild)
        {
            DataTable dt = new DataTable();
            SQLDGFill(GetConnString(), SQL, dt);
            DdList.DataSource = dt;
            DdList.DataTextField = TextFeild;
            DdList.DataValueField = ValueField;
            DdList.DataBind();

        }
        public void PopulateRadioListFromDatabase(String SQL, RadioButtonList rdBoxList, String ValueField, String TextField)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            SQLDGFill(GetConnString(), SQL, dt);
            rdBoxList.DataSource = dt;
            rdBoxList.DataTextField = TextField;
            rdBoxList.DataValueField = ValueField;
            rdBoxList.DataBind();
        }
        public void SignOutUser()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();
            //Response.End();
        }
        public void CallSP(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection(GetConnString());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Dispose();
        }
        public string GetEmailTemplate(string NodeName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(HttpContext.Current.Server.MapPath("EmailTemplate.xml"));
            return document.SelectSingleNode("EmailTemplate/" + NodeName).InnerText;
        }
        public async Task EmailSend(string SendTo, string BodyMessage, string Subject)
        {
            if (ConfigurationManager.AppSettings["EmailActive"] == "true")
            {
                var client = new SendGridClient(ConfigurationManager.AppSettings["SendGridAPIKey"].ToString());
                var from = new EmailAddress(ConfigurationManager.AppSettings["EmailFrom"].ToString(), "Sugar Land MMA");
                var subject = Subject;
                var to = new EmailAddress(SendTo);
                var plainTextContent = BodyMessage;
                var htmlContent = BodyMessage;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg).ConfigureAwait(false);

                ;
            }
        }
        public async Task EmailSendWithAttachment(string SendTo, string BodyMessage, string Subject, SendGrid.Helpers.Mail.Attachment attc)
        {
            if (ConfigurationManager.AppSettings["EmailActive"] == "true")
            {
                var client = new SendGridClient(ConfigurationManager.AppSettings["SendGridAPIKey"].ToString());
                var from = new EmailAddress(ConfigurationManager.AppSettings["EmailFrom"].ToString(), "Sugar Land MMA");
                var subject = Subject;
                var to = new EmailAddress(SendTo);
                var plainTextContent = BodyMessage;
                var htmlContent = BodyMessage;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                msg.AddAttachment(attc);
                String ccListRaw = ConfigurationManager.AppSettings["EmailFrom"].ToString();
                msg.AddCc(ccListRaw);

                var response = await client.SendEmailAsync(msg);
            }
        }
        public async Task EmailSendWithAttachment2(string SendTo, string BodyMessage, string Subject, SendGrid.Helpers.Mail.Attachment attc, string fromEmail, string CCemail)
        {
            if (ConfigurationManager.AppSettings["EmailActive"] == "true")
            {
                var client = new SendGridClient(ConfigurationManager.AppSettings["SendGridAPIKey"].ToString());
                var from = new EmailAddress(fromEmail, "Sugar Land MMA");
                var subject = Subject;
                var to = new EmailAddress(SendTo);
                var plainTextContent = BodyMessage;
                var htmlContent = BodyMessage;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                msg.AddAttachment(attc);
                String ccListRaw = CCemail;
                msg.AddCc(ccListRaw);

                var response = await client.SendEmailAsync(msg);
            }
        }
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "Sug@rL@ndMMA";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "Sug@rL@ndMMA";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public string GetUserIDNum(String User)
        {
            String SQLID = "select userid from users where upper(useremail) = upper('{0}')";
            String Val = SQLExecuteScalar(String.Format(SQLID, User));
            return Val;
        }
        public void Log(String LogMessage)
        {
            FileStream fs = new FileStream(ConfigurationManager.AppSettings["LogFile"], FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + ": " + LogMessage);
            sw.Close();
        }
        public string UploadGenDocumentToAzureNoResize(string FolderName, Stream File, string filename_withExtension, string fileExtension)
        {
            try
            {
                string storageAccount_connectionString;

                //Copy the storage account connection string from Azure portal     
                storageAccount_connectionString = ConfigurationManager.AppSettings["AzureStorage_ConnectionString"];

                CloudStorageAccount mycloudStorageAccount = CloudStorageAccount.Parse(storageAccount_connectionString);
                CloudBlobClient blobClient = mycloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(ConfigurationManager.AppSettings["AzureStorage_ContainerName"]);

                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(string.Format("_{0}/", FolderName) + filename_withExtension);
                cloudBlockBlob.Properties.ContentType = fileExtension;
                cloudBlockBlob.UploadFromStream(File); // << Uploading the file to the blob >>  
                var blobUrl = cloudBlockBlob.Uri.AbsoluteUri;
                return cloudBlockBlob.Uri.AbsoluteUri; ;
            }
            catch (Exception ex)
            {
                Log(string.Format("Error calling 'UploadGenDocumentToAzureNoResize'. Error message: {0}.", ex.Message));
                return "1";
            }
        }
        [Function("transfer", "bool")]
        public class TransferFunction : FunctionMessage
        {
            [Parameter("address", "to", 1)]
            public string To { get; set; }

            [Parameter("uint", "tokens", 2)]
            public int TokenAmount { get; set; }
        }
        public async Task<BigInteger> getKptGasFee(string fromAddress, string toAddress, string contractAddress)
        {
            var url = "https://mainnet.infura.io/v3/819e1597a26346b19891b29b1c355d07";
            var privateKey = "0x96318da9f459a007c8a3d20e6598515d0269b9ab802d4a402ce04f0d7c288a70";
            var account = new Account(privateKey, Nethereum.Signer.Chain.MainNet);
            var web3 = new Nethereum.Web3.Web3(account, url);

            var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var transfer = new TransferFunction()
            {
                To = toAddress,
                TokenAmount = 1
            };
            var estimate = await transferHandler.EstimateGasAsync(contractAddress, transfer);
            //transfer.Gas = estimate.Value;
            // for demo purpouses gas estimation it is done in the background so we don't set it
            return estimate.Value;


        }
        public async Task<string> transfer5(string fromAddress, string toAddress, string contractAddress)
        {
            var url = "https://mainnet.infura.io/v3/819e1597a26346b19891b29b1c355d07";
            var privateKey = "0x96318da9f459a007c8a3d20e6598515d0269b9ab802d4a402ce04f0d7c288a70";
            var account = new Account(privateKey, Nethereum.Signer.Chain.MainNet);
            var web3 = new Nethereum.Web3.Web3(account, url);


            //var balanceOfFunctionMessage = new BalanceOfFunction()
            //{
            //    Owner = account.Address,
            //};

            //var balanceHandler = web3.Eth.GetContractQueryHandler<BalanceOfFunction>();
            //var balance = await balanceHandler.QueryAsync<BigInteger>(contractAddress, balanceOfFunctionMessage);
            //Console.WriteLine("Balance of owner: " + balance);

            //var estimatedGas = await transferHandler.EstimateGasAsync(contractAddress, transactionMessage);
            //Console.WriteLine("Estimated Gas: " + estimatedGas);
            //// for demo purpouses gas estimation it is done in the background so we don't set it
            //transactionMessage.Gas = estimatedGas.Value;

            var transferHandler = web3.Eth.GetContractTransactionHandler<TransferFunction>();
            var transfer = new TransferFunction()
            {
                To = toAddress,
                TokenAmount = 1
            };
            var signedTransaction = await transferHandler.SignTransactionAsync(contractAddress, transfer);
            Console.WriteLine("signedTransaction: " + signedTransaction.ToString());

            var txnHash = TransactionUtils.CalculateTransactionHash(signedTransaction);
            Console.WriteLine($"Transaction Hash: 0x{txnHash}");

            var transactionHash = await web3.Eth.Transactions.SendRawTransaction.SendRequestAsync(signedTransaction);
            Console.WriteLine($"Real Transaction Hash: {transactionHash}");

            var _txnHash = "0x" + txnHash;
            Console.WriteLine($"Is Transaction Hash the same : {transactionHash == _txnHash}");

            //var transactionReceipt = await transferHandler.SendRequestAndWaitForReceiptAsync(contractAddress, transfer);


            return "";
        }
        public BigInteger getAccountBalance(string addressOwner, string contractAddress)
        {
            var url = "https://mainnet.infura.io/v3/819e1597a26346b19891b29b1c355d07";
            var privateKey = "0x96318da9f459a007c8a3d20e6598515d0269b9ab802d4a402ce04f0d7c288a70";
            var account = new Account(privateKey, Nethereum.Signer.Chain.MainNet);
            var web3 = new Nethereum.Web3.Web3(account, url);

            var tokenService = new Nethereum.StandardTokenEIP20.StandardTokenService(web3, contractAddress);
            //var ownerBalanceTask = tokenService.BalanceOfQueryAsync("ss", addressOwner);
            var ownerBalanceTask = tokenService.BalanceOfQueryAsync(addressOwner, null).Result;

            return ownerBalanceTask;
        }
    }
}