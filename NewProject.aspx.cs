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
    public partial class NewProject : System.Web.UI.Page
    {
        Common CM = new Common();
        String CurrUser = HttpContext.Current.User.Identity.Name;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            this.lblException.Text = "";

            try
            {
                if (txtEntity.Value == "" || txtProjectManager.Value == "" || txtShortDesc.Value == "" || txtStartDate.Value == "")
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
                        CommandText = "ADD_NEW_PROJECT"
                    };
                    command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = txtEntity.Value.Trim();
                    command.Parameters.Add("@ProjManagerID", SqlDbType.Int).Value = txtProjectManager.Value.Trim();
                    command.Parameters.Add("@ShortDesc", SqlDbType.VarChar).Value = txtShortDesc.Value.Trim();
                    command.Parameters.Add("@LongDesc", SqlDbType.VarChar).Value =  txtLongDesc.Value.Trim();
                    command.Parameters.Add("@DateCreated", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = CurrUser;
                    command.Parameters.Add("@StartDate", SqlDbType.Date).Value = txtStartDate.Value.Trim();
                    command.Parameters.Add("@Price", SqlDbType.Float).Value = txtPrice.Value.Trim();


                    command.Connection = connection;

                    connection.Open();
                    command.ExecuteNonQuery();
                    lblException.Text = "Project was created successfully!";

                    lblException.ForeColor = Color.Green;
                    
                    connection.Close();
                    connection.Dispose();

                    txtEntity.Value = "";
                    txtLongDesc.Value = "";
                    txtShortDesc.Value = "";
                    txtStartDate.Value = "";
                    txtProjectManager.Value = "";
                    txtEndDate.Value = "";
                    
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