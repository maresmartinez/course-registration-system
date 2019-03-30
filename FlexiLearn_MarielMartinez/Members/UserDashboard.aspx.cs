using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlexiLearn_MarielMartinez.BusinessLogic.DAL;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;

namespace FlexiLearn_MarielMartinez.Members {
    public partial class UserDashboard : System.Web.UI.Page {

        /// <summary>
        /// All the registration requests submitted by the user
        /// </summary>
        List<RegistrationRequest> userRequests;

        /// <summary>
        /// Populates the gridview to show all request data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            userRequests = requestDAO.GetAllUserRequests(Context.User.Identity.Name);

            if (!IsPostBack) {
                GVRegistrationRequests.DataSource = userRequests;
                GVRegistrationRequests.DataBind();
            }
        }

        protected void BtnRemove_Click(object sender, EventArgs e) {

            List<int> selectedIDs = new List<int>();
            foreach (GridViewRow row in GVRegistrationRequests.Rows) {
                CheckBox chkSelection = (CheckBox)row.FindControl("ChkDeleteRequest");
                if (chkSelection.Checked) {
                    int id = int.Parse(((HiddenField)row.FindControl("HFID")).Value);
                    selectedIDs.Add(id);
                }
            }

            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            foreach (int id in selectedIDs) {
                requestDAO.DeleteRegistrationRequest(id);
            }

            userRequests = requestDAO.GetAllUserRequests(Context.User.Identity.Name);
            GVRegistrationRequests.DataSource = userRequests;
            GVRegistrationRequests.DataBind();
        }
    }
}