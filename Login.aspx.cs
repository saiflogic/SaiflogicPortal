using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaifLogic
{
    public partial class Login : System.Web.UI.Page
    {
        Common CM = new Common();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            //this.lblException.Text = "";

            String SQL = "select count(*) from USERS where useremail = @UserID and userpassword = @Password and status = 'ACTIVE'";
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SaifLogic_DB"].ConnectionString);
            SqlCommand command = new SqlCommand(SQL, connection);
            command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = txtUserName.Value.Trim();
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = CM.Encrypt(txtPassword.Value.Trim());
            String CheckUser;

            try
            {
                if (txtUserName.Value == "" || txtPassword.Value == "")
                {
                    lblException.ForeColor = Color.Red;
                    lblException.Text = "Please make sure you entered a User ID/Password!";
                }
                else
                {
                    connection.Open();
                    CheckUser = command.ExecuteScalar().ToString();

                    if (CheckUser == "1")
                    {
                        //Update LastLogon date 
                        SqlCommand commandLoginDate = new SqlCommand("UPDATE_USER_LASTLOGONDATE");
                        commandLoginDate.Parameters.Add("@UserID", SqlDbType.VarChar).Value = txtUserName.Value.Trim();
                        commandLoginDate.Parameters.Add("@LastLogin", SqlDbType.DateTime).Value = DateTime.Now;
                        CM.CallSP(commandLoginDate);

                        //Log in user
                        //FormsAuthentication.RedirectFromLoginPage(txtID.Text.Trim(), cbRemUser.Checked);

                        //FormsAuthenticationTicket tkt;
                        //String cookiestr;
                        //HttpCookie ck;
                        //tkt = new FormsAuthenticationTicket(1, txtID.Text, DateTime.Now, DateTime.Now.AddMinutes(5), cbRemUser.Checked, "UserData");
                        //cookiestr = FormsAuthentication.Encrypt(tkt);
                        //ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        //if (cbRemUser.Checked)
                        //    ck.Expires = tkt.Expiration;
                        //ck.Path = FormsAuthentication.FormsCookiePath;
                        //Response.Cookies.Add(ck);
                        //String strRedirect;
                        //strRedirect = Request["ReturnUrl"];
                        //if (strRedirect == null)
                        //    strRedirect = "Default.aspx";
                        //Response.Redirect("inspections.aspx", true);

                        //code to start getting userdata from here
                        //String UserData = ddlDealers.SelectedValue;
                        String SQLUserID = "select CAST(userID AS varchar(max)) + '|' + userfunction as UserInfo from users where useremail = '{0}'";
                        String UserData = CM.SQLExecuteScalar(string.Format(SQLUserID, txtUserName.Value.Trim()));

                        FormsAuthenticationTicket tkt;
                        String cookiestr;
                        HttpCookie ck;
                        //tkt = new FormsAuthenticationTicket(1, txtID.Value, DateTime.Now, DateTime.Now.AddMinutes(1440), true, UserData);
                        tkt = new FormsAuthenticationTicket(1, txtUserName.Value.Trim(), DateTime.Now, DateTime.Now.AddMinutes(2592000), true, UserData);
                        cookiestr = FormsAuthentication.Encrypt(tkt);
                        ck = new HttpCookie(FormsAuthentication.FormsCookieName, cookiestr);
                        //if (cbRemUser.Checked)
                        ck.Expires = tkt.Expiration;
                        ck.Path = FormsAuthentication.FormsCookiePath;
                        Response.Cookies.Add(ck);
                        Response.Redirect("Dashboard.aspx", true);

                    }
                    else
                    {
                        lblException.Text = "Login failed";
                    }
                }
            }
            catch (Exception exception)
            {
                lblException.Text = exception.Message;
                lblException.ForeColor = Color.Red;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}