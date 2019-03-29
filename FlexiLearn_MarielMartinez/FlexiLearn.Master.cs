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
                HLHome.Visible = true;
                HLDashboard.Visible = true;
                HLRegistration.Visible = true;
                LBLoginLogout.Text = "Logout";
            } else {
                HLHome.Visible = false;
                HLDashboard.Visible = false;
                HLRegistration.Visible = false;
                LBLoginLogout.Text = "Login";
            }   
        }

        protected void LBLoginLogout_Click(object sender, EventArgs e) {
            if (Request.IsAuthenticated) {
                LBLoginLogout.Text = "Login";
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            } else {
                Response.Redirect("./Login.aspx");
            }
        }
    }
}