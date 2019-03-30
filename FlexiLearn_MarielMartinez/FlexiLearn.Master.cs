using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlexiLearn_MarielMartinez {
    public partial class FlexiLearn : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.IsAuthenticated) {
                BtnLoginLogout.Text = "Logout";
            } else {
                BtnLoginLogout.Text = "Login";
            }
        }

        protected void BtnLoginLogout_Click(object sender, EventArgs e) {
            if (Request.IsAuthenticated) {
                BtnLoginLogout.Text = "Login";
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            } else {
                Response.Redirect("./Login.aspx");
            }
        }
    }
}