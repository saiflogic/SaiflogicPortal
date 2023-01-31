using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaifLogic
{
    public partial class AwardKPT : System.Web.UI.Page
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
                        txtWalletID.Value = dr["walletid"].ToString();
                        //txtShortDesc.Value = dr["short_desc"].ToString();
                        //txtLongDesc.Value = dr["long_desc"].ToString();
                        //txtStartDate.Value = dr["start_date"].ToString();
                        //txtEndDate.Value = dr["end_date"].ToString();
                        //ddlPhysState.SelectedValue = dr["State"].ToString();
                        //txtPrice.Value = dr["price"].ToString();


                    }
                    txtKptBalance.Value = CM.getAccountBalance("0x4042b2DDF7609B9108b9BbDd7A14c5D9597307B3", "0x84E19A90791545a7619Ae9b8229fa37fA41d7cD1").ToString();
                    //CM.PopluateDropdown(SQLStates, ddlPhysState, "state_code", "state_code");

                }
                catch (Exception ex)
                {
                    lblException.Text = ex.Message;
                    lblException.ForeColor = Color.Red;
                }
            }
        }

        protected void cmdSubmit1_Click(object sender, EventArgs e)
        {
            txtEstimatedGas.Value = CM.getKptGasFee("0x4042b2DDF7609B9108b9BbDd7A14c5D9597307B3", txtWalletID.Value, "0x84E19A90791545a7619Ae9b8229fa37fA41d7cD1").Result.ToString();
        }

        protected void cmdSubmit2_Click(object sender, EventArgs e)
        {

        }
    }
}