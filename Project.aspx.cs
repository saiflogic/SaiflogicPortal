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
    public partial class Project : System.Web.UI.Page
    {
        Common CM = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!Page.IsPostBack)
            {
                try
                {
                    String ProjID = Request.QueryString["ProjectID"];
                    String SQL = "select * from vw_projects where rowid = {0}";
                    DataTable DTProjInfo = new DataTable();
                    CM.SQLDGFill(CM.GetConnString(), String.Format(SQL, ProjID), DTProjInfo);

                    

                    foreach (DataRow dr in DTProjInfo.Rows)
                    {
                        txtEntity.Value = dr["entity"].ToString();
                        txtProjectManager.Value = dr["pmfirstname"].ToString();
                        txtShortDesc.Value = dr["short_desc"].ToString();
                        txtLongDesc.Value = dr["long_desc"].ToString();
                        txtStartDate.Value = dr["start_date"].ToString();
                        txtEndDate.Value = dr["end_date"].ToString();
                        //ddlPhysState.SelectedValue = dr["State"].ToString();
                        txtPrice.Value = dr["price"].ToString();
                        
                        
                    }
                    //CM.PopluateDropdown(SQLStates, ddlPhysState, "state_code", "state_code");

                }
                catch (Exception ex)
                {
                    lblException.Text = ex.Message;
                    lblException.ForeColor = Color.Red;
                }
            }

        }

        protected void cmdSubmit_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SaifLogic_DB"].ConnectionString);

            SqlCommand command = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "UPDATE_PROJECT"
            };
            //command.Parameters.Add("@Entity", SqlDbType.VarChar).Value = txtEntity.Value.Trim();
            //command.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAddress.Value.Trim();
            //command.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Value.Trim();
            //command.Parameters.Add("@State", SqlDbType.VarChar).Value = txtCity.Value.Trim();
            //command.Parameters.Add("@ZIP", SqlDbType.VarChar).Value = txtZip.Value.Trim();
            //command.Parameters.Add("@UserFirstName", SqlDbType.VarChar).Value = txtFirstName.Value.Trim();
            //command.Parameters.Add("@UserLastName", SqlDbType.VarChar).Value = txtLastName.Value.Trim();
            //command.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = txtEmail.Value.Trim();
            //command.Parameters.Add("@UserPhoneNum", SqlDbType.VarChar).Value = txtPhoneNum.Value.Trim();
            //command.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVE";
            //command.Parameters.Add("@WalletID", SqlDbType.VarChar).Value = txtWalletID.Value.Trim();
            //command.Connection = connection;

            connection.Open();
            command.ExecuteNonQuery();
            lblException.Text = "Project updated successfully!";
        }
    }
}