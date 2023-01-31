using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SaifLogic
{
    public partial class Projects : System.Web.UI.Page
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
            String SQLUsers = "SELECT * from VW_PROJECTS order by rowid";
            DataTable dtUsers = new DataTable();
            CM.SQLDGFill(CM.GetConnString(), SQLUsers, dtUsers);
            radGridProjects.DataSource = dtUsers;
            radGridProjects.DataBind();
        }
        protected void radGridProjects_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                //try
                //{

                //    Label ActiveStatus = (Label)e.Item.FindControl("lblStatus");
                //    Label UserID = (Label)e.Item.FindControl("lblID");
                //    LinkButton lnkActivation = (LinkButton)e.Item.FindControl("lnkActivate");
                //    //ImageButton QRImage = (ImageButton)e.Item.FindControl("imgQR");

                //    lblException.Text = "";

                //    if (ActiveStatus.Text == "ACTIVE")
                //    {
                //        lnkActivation.Text = "DEACTIVATE";
                //        e.Item.Cells[11].BackColor = Color.LightGreen;
                //        e.Item.Cells[11].ForeColor = Color.White;

                //        ////set qr link
                //        //QRImage.PostBackUrl = "QR.aspx?UserID=" + UserID.Text + "&Mode=Admin";
                //    }
                //    else
                //    {
                //        lnkActivation.Text = "ACTIVATE";
                //        e.Item.Cells[11].BackColor = Color.IndianRed;
                //        e.Item.Cells[11].ForeColor = Color.White;
                //    }



                //}
                //catch (Exception ex)
                //{
                //    lblException.Text = ex.Message;
                //    lblException.ForeColor = Color.Red;
                //}
            }
        }

        protected void radGridProjects_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            String SQLUsers = "SELECT * from VW_PROJECTS order by rowid";
            DataTable dtUsers = new DataTable();
            CM.SQLDGFill(CM.GetConnString(), SQLUsers, dtUsers);
            radGridProjects.DataSource = dtUsers;
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            GridDataItem gRow = ((LinkButton)sender).Parent.Parent as GridDataItem;
            String ProjID = ((Label)gRow.Cells[1].FindControl("lblID")).Text;

            try
            {
                Response.Redirect("Project.aspx?ProjectID=" + ProjID);
            }
            catch (Exception exception)
            {
                lblException.Text = exception.Message;
                lblException.ForeColor = Color.Red;
            }
        }

        protected void lnkActivate_Click(object sender, EventArgs e)
        {
            GridDataItem gRow = ((LinkButton)sender).Parent.Parent as GridDataItem;
            String ProjID = ((Label)gRow.Cells[1].FindControl("lblID")).Text;

            try
            {
                Response.Redirect("AwardKPT.aspx?ProjectID=" + ProjID);
            }
            catch (Exception exception)
            {
                lblException.Text = exception.Message;
                lblException.ForeColor = Color.Red;
            }
        }
    }
}