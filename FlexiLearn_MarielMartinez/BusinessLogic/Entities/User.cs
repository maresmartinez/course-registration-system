using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FlexiLearn_MarielMartinez.BusinessLogic.Entities {
    public class User {

        /// <summary>
        /// Name of user
        /// </summary>
        string name;
        /// <summary>
        /// Name of user
        /// </summary>
        public string Name {
            get { return name; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Name must have a value");
                }
                name = value;
            }
        }

        /// <summary>
        /// Email of user
        /// </summary>
        string email;
        /// <summary>
        /// Email of user
        /// </summary>
        public string Email {
            get { return email; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Email must have a value");
                }

                Regex emailReg = new Regex(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)");
                if (!emailReg.IsMatch(value)) {
                    throw new ArgumentException("Not a valid email format");
                }

                email = value;
            }
        }

        /// <summary>
        /// Phone number of user
        /// </summary>
        string phone;
        /// <summary>
        /// Phone number of user
        /// </summary>
        public string Phone {
            get { return phone; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    phone = value; // phone is optional, so can be null
                    return;
                }

                // If phone not null, ensure it is in the right format
                Regex phoneReg = new Regex(@"^\(?\d\d\d\)?\d\d\d\-?\d\d\d\d$");
                if (!phoneReg.IsMatch(value)) {
                    throw new ArgumentException("Phone must be in the format (555)555-5555");
                }
                phone = value;
            }
        }

        /// <summary>
        /// Level of education of user
        /// </summary>
        public EducationLevel Education { get; set; }

        /// <summary>
        /// Date of birth of user
        /// </summary>
        string birthday;
        /// <summary>
        /// Date of birth of user
        /// </summary>
        public string Birthday {
            get { return birthday; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Birthday must have a value");
                }

                Regex dateReg = new Regex(@"^\d\d\d\d\-?\d\d\-?\d\d$");
                if (!dateReg.IsMatch(value)) {
                    throw new ArgumentException("Birthday must be in the format yyyy-MM-dd");
                }

                birthday = value;
            }
        }

        /// <summary>
        /// Hashed and salted password of user
        /// </summary>
        string password;
        /// <summary>
        /// Hashed and salted password of user
        /// </summary>
        public string Password {
            get { return password; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Password must have a value");
                }

                password = value;
            }
        }

        /// <summary>
        /// Salt to hash password
        /// </summary>
        string salt;
        /// <summary>
        /// Salt to hash password
        /// </summary>
        public string Salt {
            get { return salt; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Salt must have a value");
                }

                salt = value;
            }
        }

        /// <summary>
        /// Date that the user was registered with FlexiLearn
        /// </summary>
        string registrationDate;
        /// <summary>
        /// Date that the user was registered with FlexiLearn
        /// </summary>
        public string RegistrationDate {
            get { return registrationDate; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Registration Date must have a value");
                }

                Regex dateReg = new Regex(@"^\d\d\d\d\-?\d\d\-?\d\d$");
                if (!dateReg.IsMatch(value)) {
                    throw new ArgumentException("Registration Date must be in the format yyyy-MM-dd");
                }

                registrationDate = value;
            }
        }

        /// <summary>
        /// Constructor for User object
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="education">Level of Education</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="plainTextPass">Password in plain-text</param>
        public User(string name, string email, EducationLevel education, 
            string birthday, string plainTextPass) {
            Name = name;
            Email = email;
            Education = education;
            Birthday = birthday;
            RegistrationDate = DateTime.UtcNow.Date.ToShortDateString();

            // Secure the password
            Salt = HashUtil.GetSalt();
            Password = HashUtil.GetPasswordHash(plainTextPass, Salt);
        }

        /// <summary>
        /// Constructor for User object
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="phone">Phone</param>
        /// <param name="education">Level of education</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="plainTextPass">Password in plain-text</param>
        public User(string name, string email, string phone, EducationLevel education,
            string birthday, string plainTextPass) {
            Name = name;
            Phone = phone;
            Email = email;
            Education = education;
            Birthday = birthday;
            RegistrationDate = DateTime.UtcNow.Date.ToShortDateString();

            // Secure the password
            Salt = HashUtil.GetSalt();
            Password = HashUtil.GetPasswordHash(plainTextPass, Salt);
        }

        /// <summary>
        /// Constructor for User object
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="education">Level of education</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="plainTextPass">Password in plain-text</param>
        /// <param name="registrationDate">The date the user registered</param>
        public User(string name, string email, EducationLevel education,
            string birthday, string plainTextPass, string registrationDate) {
            Name = name;
            Email = email;
            Education = education;
            Birthday = birthday;
            RegistrationDate = registrationDate;

            // Secure the password
            Salt = HashUtil.GetSalt();
            Password = HashUtil.GetPasswordHash(plainTextPass, Salt);
        }

        /// <summary>
        /// Constructor for User object
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="email">Email</param>
        /// <param name="phone">Phone</param>
        /// <param name="education">Level of education</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="plainTextPass">Password in plain-text</param>
        /// <param name="registrationDate">The date the user registered</param>
        public User(string name, string email, string phone, EducationLevel education,
            string birthday, string plainTextPass, string registrationDate) {
            Name = name;
            Phone = phone;
            Email = email;
            Education = education;
            Birthday = birthday;
            RegistrationDate = registrationDate;

            // Secure the password
            Salt = HashUtil.GetSalt();
            Password = HashUtil.GetPasswordHash(plainTextPass, Salt);
        }

    }
}