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

        List<RegistrationRequest> allRequests;

        protected void Page_Load(object sender, EventArgs e) {
            UpdateGVRegistrationRequests();
        }

        /// <summary>
        /// Displays the most updated requests records in the database 
        /// </summary>
        private void UpdateGVRegistrationRequests() {
            RegistrationRequestDAO requestDAO = new RegistrationRequestDAO(ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString);
            allRequests = requestDAO.ReadAll();

            // Create custom data to display in GridView

            //Ref: https://stackoverflow.com/questions/1042618/how-to-create-a-datatable-in-c-sharp-and-how-to-add-rows
            DataTable requestData = new DataTable();
            requestData.Columns.Add("Requester Name");
            requestData.Columns.Add("Course Code");
            requestData.Columns.Add("Course Title");
            requestData.Columns.Add("Request Status");

            foreach (RegistrationRequest request in allRequests) {
                DataRow newRow = requestData.NewRow();
                newRow["Requester Name"] = request.RegistrationUser.Name;
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