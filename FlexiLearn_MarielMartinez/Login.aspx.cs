using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            // Authenticate and redirect depending on whether successful or not
            UserTableDAO userDao = new UserTableDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            if (userDao.AuthenticateUser(username, password)) {
                // TODO redirect to members section
                Response.Write("Yes");
            } else {
                // TODO show error
                Response.Write("No");
            }
        }
    }
}