using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SaifLogic
{
    public partial class CustomerManagement : System.Web.UI.Page
    {
        Common CM = new Common();
        String CurrUser = HttpContext.Current.User.Identity.Name.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                //String[] Userinfo = CM.GetUserData().Split('|');

                //if (Userinfo[1] == "Administrator")
                //{

                //}
                //else
                //{
                //    Server.Transfer("Dashboard.aspx");
                //}
            }
        }
        public void UpdateGrids()
        {

            lblException.Text = "";

            //update inspectors grid
            String SQLUsers = "SELECT * from CUSTOMERS order by userfirstname";
            DataTable dtUsers = new DataTable();
            CM.SQLDGFill(CM.GetConnString(), SQLUsers, dtUsers);
            radGridCustomer.DataSource = dtUsers;
            radGridCustomer.DataBind();
        }
        protected void radGridCustomer_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            String SQLUsers = "SELECT * from CUSTOMERS order by userfirstname";
            DataTable dtUsers = new DataTable();
            CM.SQLDGFill(CM.GetConnString(), SQLUsers, dtUsers);
            radGridCustomer.DataSource = dtUsers;
        }
        protected void lnkEdit_Click(object sender, EventArgs e)
        {

        }

        protected void lnkActivate_Click(object sender, EventArgs e)
        {
            lblException.Text = "";
            //GridViewRow gRow = ((LinkButton)sender).Parent.Parent as GridViewRow;
            GridDataItem gRow = ((LinkButton)sender).Parent.Parent as GridDataItem;
            String UserID = ((Label)gRow.Cells[1].FindControl("lblID")).Text;
            String ActiveStatus = ((Label)gRow.Cells[7].FindControl("lblStatus")).Text;
            try
            {
                this.lblException.Text = "";
                if (ActiveStatus == "ACTIVE")
                {
                    SqlCommand command = new SqlCommand("ACTIVATE_USER");
                    command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                    command.Parameters.Add("@ActiveDate", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "INACTIVE";
                    CM.CallSP(command);
                    lblException.Text = "User was activated!";
                    UpdateGrids();
                    ((LinkButton)gRow.Cells[0].FindControl("lnkActivate")).Text = "Deactivate";
                    gRow.Cells[7].BackColor = Color.Red;
                }
                else
                {
                    SqlCommand command = new SqlCommand("ACTIVATE_USER");
                    command.Parameters.Add("@UserID", SqlDbType.VarChar).Value = UserID;
                    command.Parameters.Add("@ActiveDate", SqlDbType.DateTime).Value = DateTime.Now;
                    command.Parameters.Add("@Status", SqlDbType.NVarChar).Value = "ACTIVE";
                    CM.CallSP(command);
                    lblException.Text = "User was deactivated!";
                    UpdateGrids();
                    ((LinkButton)gRow.Cells[0].FindControl("lnkActivate")).Text = "Activate";
                    gRow.Cells[7].BackColor = Color.Green;
                }
            }
            catch (Exception exception)
            {
                lblException.Text = exception.Message;
                lblException.ForeColor = Color.Red;
            }
        }

        protected void radGridCustomer_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                try
                {

                    Label ActiveStatus = (Label)e.Item.FindControl("lblStatus");
                    Label UserID = (Label)e.Item.FindControl("lblID");
                    LinkButton lnkActivation = (LinkButton)e.Item.FindControl("lnkActivate");
                    //ImageButton QRImage = (ImageButton)e.Item.FindControl("imgQR");

                    lblException.Text = "";

                    if (ActiveStatus.Text == "ACTIVE")
                    {
                        lnkActivation.Text = "DEACTIVATE";
                        e.Item.Cells[12].BackColor = Color.LightGreen;
                        e.Item.Cells[12].ForeColor = Color.White;

                        ////set qr link
                        //QRImage.PostBackUrl = "QR.aspx?UserID=" + UserID.Text + "&Mode=Admin";
                    }
                    else
                    {
                        lnkActivation.Text = "ACTIVATE";
                        e.Item.Cells[12].BackColor = Color.IndianRed;
                        e.Item.Cells[12].ForeColor = Color.White;
                    }



                }
                catch (Exception ex)
                {
                    lblException.Text = ex.Message;
                    lblException.ForeColor = Color.Red;
                }
            }
        }
    }
}