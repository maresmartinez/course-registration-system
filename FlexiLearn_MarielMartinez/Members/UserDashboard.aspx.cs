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
            UpdateGVRegistrationRequests();
        }

        /// <summary>
        /// Deletes a request record from the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GVRegistrationRequests_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            RegistrationRequest deletingRequest = userRequests[e.RowIndex];

            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            requestDAO.DeleteRegistrationRequest(deletingRequest);

            UpdateGVRegistrationRequests();
        }

        /// <summary>
        /// Displays the most updated requests records in the database 
        /// </summary>
        private void UpdateGVRegistrationRequests() {
            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            userRequests = requestDAO.GetAllUserRequests(Context.User.Identity.Name);

            // Create custom data to display in GridView

            //Ref: https://stackoverflow.com/questions/1042618/how-to-create-a-datatable-in-c-sharp-and-how-to-add-rows
            DataTable requestData = new DataTable();
            requestData.Columns.Add("Course Code");
            requestData.Columns.Add("Course Title");
            requestData.Columns.Add("Request Status");

            foreach (RegistrationRequest request in userRequests) {
                DataRow newRow = requestData.NewRow();
                newRow["Course Code"] = request.RegistrationCourse.CourseCode;
                newRow["Course Title"] = request.RegistrationCourse.Title;
                newRow["Request Status"] = request.RegistrationStatus;
                requestData.Rows.Add(newRow);
            }

            // Display data
            GVRegistrationRequests.DataSource = requestData;
            GVRegistrationRequests.DataBind();
        }
    }
}