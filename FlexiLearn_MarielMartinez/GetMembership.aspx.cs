using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;
using FlexiLearn_MarielMartinez.BusinessLogic.DAL;
using System.Configuration;

namespace FlexiLearn_MarielMartinez {
    public partial class GetMembership : System.Web.UI.Page {

        /// <summary>
        /// When page is loaded, the Education Drop Down List will be populated 
        /// with all EducationLevel enum values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            foreach (EducationLevel level in Enum.GetValues(typeof(EducationLevel))) {
                DDEducation.Items.Add(level.ToString());
            }
        }

        /// <summary>
        /// Creates a user based on the user's input. Validation handled by jQuery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnCreate_Click(object sender, EventArgs e) {
            // Get all inputs
            string name = TxtName.Text;
            string email = TxtEmail.Text;
            string phone = TxtPhone.Text;
            EducationLevel level = (EducationLevel)Enum.Parse(typeof(EducationLevel), 
                DDEducation.SelectedItem.ToString());
            string birthday = TxtBirthday.Text;
            string password = TxtPassword.Text;

            User user = null;
            if (string.IsNullOrEmpty(phone)) {
                user = new User(name, email, level, birthday, password);
            } else {
                user = new User(name, email, phone, level, birthday, password);
            }

            UserTableDAO userDao = new UserTableDAO(ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            userDao.AddUser(user);

            LblSuccess.Text = "Account successfully created. <a href='login.aspx'>You may login here</a>.<br><br>";
            
        }
    }
}