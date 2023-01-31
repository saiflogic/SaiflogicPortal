using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaifLogic
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        Common CM = new Common();
        String SQLStates = "select distinct state_code from cities_extended order by state_code";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //CM.PopluateDropdown(SQLStates, ddlPhysState, "state_code", "state_code");
            }
        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            this.lblException.Text = "";

            try
            {
                if (txtAddress.Value == "" || txtCity.Value == "" || txtZip.Value == "" || txtFirstName.Value == "" || txtLastName.Value == "" || txtEmail.Value == "" || txtEntity.Value == "" || txtPhoneNum.Value == "")
                {
                    lblException.ForeColor = Color.Red;
                    lblException.Text = "Please make sure you have filled out all fields!";
                }
                else
                {
                    //if (!CheckUserExists())
                    //{
                        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SaifLogic_DB"].ConnectionString);

                        SqlCommand command = new SqlCommand
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "ADD_NEW_CUSTOMER"
                        };
                        command.Parameters.Add("@Entity", SqlDbType.VarChar).Value = txtEntity.Value.Trim();
                        command.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAddress.Value.Trim();
                        command.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Value.Trim();
                        command.Parameters.Add("@State", SqlDbType.VarChar).Value = txtCity.Value.Trim();
                        command.Parameters.Add("@ZIP", SqlDbType.VarChar).Value = txtZip.Value.Trim();
                        command.Parameters.Add("@UserFirstName", SqlDbType.VarChar).Value = txtFirstName.Value.Trim();
                        command.Parameters.Add("@UserLastName", SqlDbType.VarChar).Value = txtLastName.Value.Trim();
                        command.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = txtEmail.Value.Trim();
                        command.Parameters.Add("@UserPhoneNum", SqlDbType.VarChar).Value = txtPhoneNum.Value.Trim();
                        command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE";
                        command.Parameters.Add("@WalletID", SqlDbType.VarChar).Value = txtWalletID.Value.Trim();
                        command.Connection = connection;

                        connection.Open();
                        command.ExecuteNonQuery();
                        lblException.Text = "Customer was added successfully!";

                        lblException.ForeColor = Color.Green;
                        //String EmailBodyCustomer = CM.GetEmailTemplate("NEW_USER_REGISTRATION");
                        //EmailBodyCustomer = EmailBodyCustomer.Replace("'[Name]'", txtFirstName.Value.Trim() + " " + txtLastName.Value.Trim());
                        //CM.EmailSend(txtEmail.Value, EmailBodyCustomer, "Thank You for Registering with Sugarland MMA").Wait();

                        String EmailBodyAdmin = CM.GetEmailTemplate("NEW_USER_REGISTRATION_ADMIN");
                        EmailBodyAdmin = EmailBodyAdmin.Replace("'[Entity]'", txtEntity.Value.Trim());
                        EmailBodyAdmin = EmailBodyAdmin.Replace("'[Name]'", txtFirstName.Value.Trim() + " " + txtLastName.Value.Trim());
                        EmailBodyAdmin = EmailBodyAdmin.Replace("'[Email]'", txtEmail.Value.Trim());
                        EmailBodyAdmin = EmailBodyAdmin.Replace("'[Phone]'", txtPhoneNum.Value.Trim());
                        CM.EmailSend(ConfigurationManager.AppSettings["AdminEmailTo"], EmailBodyAdmin, "NOTICE: New Customer").Wait();
                        connection.Close();
                        connection.Dispose();

                        txtPhoneNum.Value = "";
                        txtEmail.Value = "";
                        txtFirstName.Value = "";
                        txtLastName.Value = "";
                        txtAddress.Value = "";
                        txtCity.Value = "";
                        txtZip.Value = "";
                        txtEntity.Value = "";
                        txtState.Value = "";
                    //}
                    //else
                    //{
                    //    lblException.Text = "An account already exists with this e-mail address!";
                    //    lblException.ForeColor = Color.Red;
                    //}
                }
            }
            catch (Exception exception)
            {
                lblException.Text = exception.Message;
                lblException.ForeColor = Color.Red;
            }
        }
    }
}