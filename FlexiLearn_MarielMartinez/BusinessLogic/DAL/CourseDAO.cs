using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;

namespace FlexiLearn_MarielMartinez.BusinessLogic.DAL {
    public class CourseDAO {

        /// <summary>
        /// Connection string to the database where the UserTable resides
        /// </summary>
        string connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection string to the database where the UserTable resides</param>
        public CourseDAO(string connectionString) {
            this.connectionString = connectionString;
        }
        
        /// <summary>
        /// Reads all records in the Course table and returns them as a List of Course objects
        /// </summary>
        /// <returns>A List of all Courses in the database</returns>
        public List<Course> ReadAll() {
            List<Course> courses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand select = new SqlCommand("SELECT * FROM Course;");

                select.Connection = connection;
                SqlDataReader reader = select.ExecuteReader();

                while (reader.Read()) {
                    courses.Add(new Course(
                        Convert.ToString(reader["courseCode"]),
                        Convert.ToString(reader["courseTitle"]),
                        Convert.ToString(reader["courseSubject"]),
                        Convert.ToSingle(reader["courseDuration"]),
                        Convert.ToSingle(reader["courseFee"])
                    ));
                }

                if (courses.Count < 0) {
                    return null;
                }
            }
            return courses;
        }

        public Course SearchByCourseCode(string code) {
            Course course = null;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand select = new SqlCommand("SELECT * FROM Course WHERE courseCode=@CCode;");
                select.Parameters.AddWithValue("@CCode", code);

                select.Connection = connection;
                SqlDataReader reader = select.ExecuteReader();

                if (reader.Read()) {
                    course = new Course(
                        Convert.ToString(reader["courseCode"]),
                        Convert.ToString(reader["courseTitle"]),
                        Convert.ToString(reader["courseSubject"]),
                        Convert.ToSingle(reader["courseDuration"]),
                        Convert.ToSingle(reader["courseFee"])
                    );
                }
            }

            return course;
        }
    }
}