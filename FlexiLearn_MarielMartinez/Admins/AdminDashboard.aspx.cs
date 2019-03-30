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

namespace FlexiLearn_MarielMartinez.Admins {
    public partial class AdminDashboard : System.Web.UI.Page {

        /// <summary>
        /// All requests in the database
        /// </summary>
        List<RegistrationRequest> allRequests;

        /// <summary>
        /// Displays all request records on the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            allRequests = requestDAO.ReadAll();

            if (!IsPostBack) {
                GVRegistrationRequests.DataSource = allRequests;
                GVRegistrationRequests.DataBind();
            }
        }

        /// <summary>
        /// Retrieves all IDs of rows that were selected
        /// </summary>
        /// <returns>List of all IDs</returns>
        private List<int> GetSelectedIDs() {
            List<int> selectedIDs = new List<int>();
            foreach (GridViewRow row in GVRegistrationRequests.Rows) {
                CheckBox chkSelection = (CheckBox)row.FindControl("ChkSelected");
                if (chkSelection.Checked) {
                    int id = Convert.ToInt32(((HiddenField)row.FindControl("HFID")).Value);
                    selectedIDs.Add(id);
                }
            }
            return selectedIDs;
        }

        /// <summary>
        /// Accepts all selected requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAccept_Click(object sender, EventArgs e) {
            List<int> selectedIDs = GetSelectedIDs();

            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            CourseDAO courseDAO = new CourseDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);

            foreach (int id in selectedIDs) {
                RegistrationRequest request = requestDAO.SearchByRegistrationID(id);
                request.RegistrationStatus = Status.ACCEPTED;
                requestDAO.ModifyStatus(request);
            }

            allRequests = requestDAO.ReadAll();
            GVRegistrationRequests.DataSource = allRequests;
            GVRegistrationRequests.DataBind();
        }

        /// <summary>
        /// Rejects all selected requests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnReject_Click(object sender, EventArgs e) {
            List<int> selectedIDs = GetSelectedIDs();

            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            CourseDAO courseDAO = new CourseDAO(
                ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);

            foreach (int id in selectedIDs) {
                RegistrationRequest request = requestDAO.SearchByRegistrationID(id);
                request.RegistrationStatus = Status.REJECTED;
                requestDAO.ModifyStatus(request);
            }

            allRequests = requestDAO.ReadAll();
            GVRegistrationRequests.DataSource = allRequests;
            GVRegistrationRequests.DataBind();
        }

    }
}