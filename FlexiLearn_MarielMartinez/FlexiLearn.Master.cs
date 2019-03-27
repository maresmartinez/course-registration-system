using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FlexiLearn_MarielMartinez {
    public partial class FlexiLearn : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.IsAuthenticated) {
                HLLogin.Visible = false;
                HLLogout.Visible = true;
            } else {
                HLLogin.Visible = true;
                HLLogout.Visible = false;
            }

            
        }
    }
}