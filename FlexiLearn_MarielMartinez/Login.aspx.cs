using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlexiLearn_MarielMartinez.BusinessLogic.DAL;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;

namespace FlexiLearn_MarielMartinez {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        /// <summary>
        /// Will authenticate users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnLogin_Click(object sender, EventArgs e) {
            // Get inputs
            string email = TxtEmail.Text;
            string password = TxtPassword.Text;

            // Authenticate and redirect depending on whether successful or not
            UserTableDAO userDao = new UserTableDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            if (userDao.AuthenticateUser(email, password)) {
                FormsAuthentication.RedirectFromLoginPage(email, false);
            } else {
                LblFail.Text = "Email or password incorrect";
            }
        }
    }
}