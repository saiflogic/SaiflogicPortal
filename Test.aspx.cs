using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SaifLogic
{
    public partial class Test : System.Web.UI.Page
    {
        Common CM = new Common();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdEncrypt_Click(object sender, EventArgs e)
        {
            lblOutput.Text = CM.Encrypt(txtinput.Text);
        }
    }
}