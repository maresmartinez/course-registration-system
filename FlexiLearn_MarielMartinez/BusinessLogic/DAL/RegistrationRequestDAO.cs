using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;

namespace FlexiLearn_MarielMartinez.BusinessLogic.DAL {
    public class RegistrationRequestDAO {

        /// <summary>
        /// Connection string to the database where the UserTable resides
        /// </summary>
        string connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection string to the database where the UserTable resides</param>
        public RegistrationRequestDAO(string connectionString) {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Adds a registration request to the database. 
        /// </summary>
        /// <param name="request">The registration request</param>
        /// <returns>The number of records inserted</returns>
        public int AddRegistrationRequest(RegistrationRequest request) {
            // TODO: Prevent users from submitting multiple requests for same course

            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();


                SqlCommand insert = new SqlCommand("INSERT INTO RegistrationRequest (email, coursecode, status)" +
                    "VALUES (@UEmail, @CCode, @Status);");
                insert.Parameters.AddWithValue("@UEmail", request.RegistrationUser.Email);
                insert.Parameters.AddWithValue("@CCode", request.RegistrationCourse.CourseCode);
                insert.Parameters.AddWithValue("@Status", request.RegistrationStatus.ToString());

                insert.Connection = connection;

                count = insert.ExecuteNonQuery();
            }
            return count;
        }

        /// <summary>
        /// Deletes a registration record in the database
        /// </summary>
        /// <param name="id">The id of the registration request to be deleted</param>
        /// <returns>The number of rows deleted</returns>
        public int DeleteRegistrationRequest(int id) {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand delete = new SqlCommand("DELETE FROM RegistrationRequest " +
                    "WHERE registrationID=@ID");
                delete.Parameters.AddWithValue("@ID", id);

                delete.Connection = connection;

                count = delete.ExecuteNonQuery();
            }
            return count;
        }

        /// <summary>
        /// Updates the status of a registration record in the database
        /// </summary>
        /// <param name="request">The registration record to be modified</param>
        /// <returns>The number of records changed</returns>
        public int ModifyStatus(RegistrationRequest request) {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand update = new SqlCommand("UPDATE RegistrationRequest " +
                    "SET status=@RStatus WHERE registrationID=@ID;");
                update.Parameters.AddWithValue("@ID", request.ID);
                update.Parameters.AddWithValue("@RStatus", request.RegistrationStatus.ToString());

                update.Connection = connection;

                count = update.ExecuteNonQuery();
            }
            return count;
        }

        public RegistrationRequest SearchByRegistrationID(int id) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand select = new SqlCommand("SELECT * FROM RegistrationRequest " +
                    "WHERE registrationID=@ID;");
                select.Parameters.AddWithValue("@ID", id);

                select.Connection = connection;
                SqlDataReader reader = select.ExecuteReader();

                if (reader.Read()) {
                    CourseDAO courseDAO = new CourseDAO(connectionString);
                    UserTableDAO userTableDAO = new UserTableDAO(connectionString);

                    return new RegistrationRequest(
                        Convert.ToInt32(reader["registrationID"]),

                        // Use the UserTableDAO to retrieve a User object
                        userTableDAO.SearchByEmail(Convert.ToString(reader["email"])),

                        // Use the CourseDAO to retrieve a Course object
                        courseDAO.SearchByCourseCode(Convert.ToString(reader["courseCode"])),

                        // Create a Status enum
                        (Status)Enum.Parse(typeof(Status), Convert.ToString(reader["status"]))
                    );
                }
            }
            return null;
        }

        /// <summary>
        /// Reads all records in the Course table and returns them as a List of Course objects
        /// </summary>
        /// <returns>A List of all Courses in the database</returns>
        public List<RegistrationRequest> ReadAll() {
            List<RegistrationRequest> requests = new List<RegistrationRequest>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand select = new SqlCommand("SELECT * FROM RegistrationRequest;");

                select.Connection = connection;
                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read()) {
                    CourseDAO courseDAO = new CourseDAO(connectionString);
                    UserTableDAO userTableDAO = new UserTableDAO(connectionString);

                    requests.Add(new RegistrationRequest(
                        Convert.ToInt32(reader["registrationID"]),

                        // Use the UserTableDAO to retrieve a User object
                        userTableDAO.SearchByEmail(Convert.ToString(reader["email"])),
                        
                        // Use the CourseDAO to retrieve a Course object
                        courseDAO.SearchByCourseCode(Convert.ToString(reader["courseCode"])),

                        // Create a Status enum
                        (Status)Enum.Parse(typeof(Status), Convert.ToString(reader["status"]))
                    ));
                }

                if (requests.Count < 0) {
                    return null;
                }
            }
            return requests;
        }

        /// <summary>
        /// Retrieves all user requests based on a given user
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <returns>A list of all the user's request. Returns null if user has no requests, or user does not exist in database</returns>
        public List<RegistrationRequest> GetAllUserRequests(string username) {
            List<RegistrationRequest> requests = new List<RegistrationRequest>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand select = new SqlCommand("SELECT * FROM RegistrationRequest WHERE email=@UEmail;");
                select.Parameters.AddWithValue("@UEmail", username);

                select.Connection = connection;
                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read()) {
                    CourseDAO courseDAO = new CourseDAO(connectionString);
                    UserTableDAO userTableDAO = new UserTableDAO(connectionString);

                    requests.Add(new RegistrationRequest(
                        int.Parse(reader["registrationId"].ToString()),

                        // Use the UserTableDAO to retrieve a User object
                        userTableDAO.SearchByEmail(Convert.ToString(reader["email"])),

                        // Use the CourseDAO to retrieve a Course object
                        courseDAO.SearchByCourseCode(Convert.ToString(reader["courseCode"])),

                        // Create a Status enum
                        (Status)Enum.Parse(typeof(Status), Convert.ToString(reader["status"]))
                    ));
                }

                if (requests.Count < 0) {
                    return null;
                }
            }
            return requests;
        }
    }
}