using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FlexiLearn_MarielMartinez.BusinessLogic.DAL;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;

namespace FlexiLearn_MarielMartinez.Members {
    public partial class RequestRegistration : System.Web.UI.Page {

        /// <summary>
        /// Details for all courses in the database
        /// </summary>
        List<Course> courses;

        /// <summary>
        /// Connection string for the database
        /// </summary>
        string connectionString;

        /// <summary>
        /// When the page loads, all courses from the database are retrieved and displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e) {
            connectionString = ConfigurationManager.ConnectionStrings["flexiLearn"].ConnectionString;
            CourseDAO dao = new CourseDAO(connectionString);
            courses = dao.ReadAll();

            if (!IsPostBack) {
                GVCourses.DataSource = courses;
                GVCourses.DataBind();
            }
        }        

        /// <summary>
        /// Displays all courses in the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnShowAll_Click(object sender, EventArgs e) {
            GVCourses.DataSource = courses;
            GVCourses.DataBind();
        }

        /// <summary>
        /// Displayed courses based on whatever inputs were given in filters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnFilter_Click(object sender, EventArgs e) {
            // If there isn't a value for an input, adding dummy value that will match all courses
            string subject = (TxtSubject.Text != null) ? TxtSubject.Text.ToUpper() : "";
            string title = (TxtTitle.Text != null) ? TxtTitle.Text.ToUpper() : "";

            // Needed to use TryParse because the number textboxes did not register as null even when empty
            float maxDuration;
            if (!float.TryParse(TxtMaxDuration.Text, out maxDuration)) {
                maxDuration = 9999999;
            };
            float maxFee;
            if (!float.TryParse(TxtMaxFee.Text, out maxFee)) {
                maxFee = 9999999;
            };

            List<Course> filtered = new List<Course>();

            // Add all courses that match all specifications
            foreach (Course course in courses) {
                if (course.Title.ToUpper().Contains(title)
                    && course.Subject.ToUpper().Contains(subject)
                    && course.Duration <= maxDuration
                    && course.Fee <= maxFee) {
                    filtered.Add(course);
                }
            }

            // Display in GridView
            GVCourses.DataSource = filtered;
            GVCourses.DataBind();
        }

        /// <summary>
        /// Creates registrations for the courses that were selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnAdd_Click(object sender, EventArgs e) {
            List<string> selectedCourseCodes = new List<string>();
            foreach (GridViewRow row in GVCourses.Rows) {
                CheckBox chkSelection = (CheckBox)row.FindControl("ChkSelectCourse");
                if (chkSelection.Checked) {
                    selectedCourseCodes.Add(row.Cells[1].Text);
                }
            }

            CourseDAO courseDAO = new CourseDAO(connectionString);
            UserTableDAO userTableDAO = new UserTableDAO(connectionString);
            RegistrationRequestDAO registrationRequestDAO = new RegistrationRequestDAO(connectionString);

            foreach (string code in selectedCourseCodes) {
                Course course = courseDAO.SearchByCourseCode(code);
                User loggedInUser = userTableDAO.SearchByEmail(Context.User.Identity.Name);
                registrationRequestDAO.AddRegistrationRequest(
                    new RegistrationRequest(loggedInUser, course, Status.NEW));
            }

            // Redirect to dashboard so they can see the request went through
            Response.Redirect("./UserDashboard.aspx");
        }

    }
}