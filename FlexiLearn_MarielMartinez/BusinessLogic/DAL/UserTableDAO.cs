using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using FlexiLearn_MarielMartinez.BusinessLogic.Entities;

namespace FlexiLearn_MarielMartinez.BusinessLogic.DAL {
    public class UserTableDAO {

        /// <summary>
        /// Connection string to the database where the UserTable resides
        /// </summary>
        string connectionString;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection string to the database where the UserTable resides</param>
        public UserTableDAO(string connectionString) {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Adds a user's details as a record in the UserTable
        /// </summary>
        /// <param name="user">The user to be added to the UserTable</param>
        /// <returns></returns>
        public int AddUser(User user) {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                // Create insert statement depending on whether or not user has a phone number
                SqlCommand insert;
                if (string.IsNullOrEmpty(user.Phone)) {
                    // Adds users who do NOT have a phone number 
                    insert = new SqlCommand("INSERT INTO UserTable (username, email, education, birthday, password, salt, registration_date) " +
                        "VALUES (@UName, @Email, @Education, @Birthday, @Password, @Salt, @RegistrationDate);");
                    insert.Parameters.AddWithValue("@UName", user.Username);
                    insert.Parameters.AddWithValue("@Email", user.Email);
                    insert.Parameters.AddWithValue("@Education", user.Education.ToString());
                    insert.Parameters.AddWithValue("@Birthday", user.Birthday);
                    insert.Parameters.AddWithValue("@Password", user.Password);
                    insert.Parameters.AddWithValue("@Salt", user.Salt);
                    insert.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                } else {
                    // Adds users who DO have a phone number
                    insert = new SqlCommand("INSERT INTO UserTable (username, email, phone, education, birthday, password, salt, registration_date) " +
                        "VALUES (@UName, @Email, @Phone, @Education, @Birthday, @Password, @Salt, @RegistrationDate);");
                    insert.Parameters.AddWithValue("@UName", user.Username);
                    insert.Parameters.AddWithValue("@Email", user.Email);
                    insert.Parameters.AddWithValue("@Phone", user.Phone);
                    insert.Parameters.AddWithValue("@Education", user.Education.ToString());
                    insert.Parameters.AddWithValue("@Birthday", user.Birthday);
                    insert.Parameters.AddWithValue("@Password", user.Password);
                    insert.Parameters.AddWithValue("@Salt", user.Salt);
                    insert.Parameters.AddWithValue("@RegistrationDate", user.RegistrationDate);
                }

                insert.Connection = connection;

                count = insert.ExecuteNonQuery();
            }
            return count;
        }

        /// <summary>
        /// Checks a username and password against the records in the UserTable. If credentials are invalid, this method 
        /// will not specify whether it was the username or password that was incorrect.
        /// </summary>
        /// <param name="username">The username of the user</param>
        /// <param name="plainTextPassword">The password in plain-text of the user</param>
        /// <returns>Whether or not the username and password matched any records in the UserTable</returns>
        public bool AuthenticateUser(string username, string plainTextPassword) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand select = new SqlCommand("SELECT * FROM UserTable WHERE username=@UName");
                select.Parameters.AddWithValue("@UName", username);
                select.Connection = connection;
                SqlDataReader reader = select.ExecuteReader();

                if (reader.Read()) {
                    // User with that username exists

                    string salt = Convert.ToString(reader["salt"]);
                    string storedPassword = Convert.ToString(reader["password"]);

                    // Generate a hash for the entered password with the salt
                    string inputPassword = HashUtil.GetPasswordHash(plainTextPassword, salt);

                    // Check if stored hash password matches the inputted password
                    if (inputPassword.Equals(storedPassword)) {
                        return true;
                    }

                } else {
                    return false;
                }
            }
            return false;
        }
    }
}