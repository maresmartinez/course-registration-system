﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiLearn_MarielMartinez.BusinessLogic.Entities {
    public class RegistrationRequest {

        /// <summary>
        /// The id of the user
        /// </summary>
        int id;
        /// <summary>
        /// The id of the user
        /// </summary>
        public int ID {
            get { return id; }
            set {
                if (value < 1) {
                    throw new ArgumentException("ID must be a positive value");
                }
                id = value;
            }
        }

        /// <summary>
        /// The user that submitted the request
        /// </summary>
        public User RegistrationUser { get; set; }

        /// <summary>
        /// The course that the student wants to register for
        /// </summary>
        public Course RegistrationCourse { get; set; }

        /// <summary>
        /// The status of the registration. 
        /// </summary>
        public Status RegistrationStatus { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">ID of the registration request</param>
        /// <param name="registrationUser">The user that made the request</param>
        /// <param name="registrationCourse">The course that the student wants to register for</param>
        /// <param name="registrationStatus">The status of the registration. </param>
        public RegistrationRequest(int id, User registrationUser, Course registrationCourse, Status registrationStatus) {
            ID = id;
            RegistrationUser = registrationUser;
            RegistrationCourse = registrationCourse;
            RegistrationStatus = registrationStatus;
        }

        /// <summary>
        /// Constructor without ID given. Since ID is generated by database identity, 
        /// this is for RegistrationRequests that have yet to be added to the database
        /// </summary>
        /// <param name="registrationUser">The user that made the request</param>
        /// <param name="registrationCourse">The course that the student wants to register for</param>
        /// <param name="registrationStatus">The status of the registration. </param>
        public RegistrationRequest(User registrationUser, Course registrationCourse, Status registrationStatus) {
            RegistrationUser = registrationUser;
            RegistrationCourse = registrationCourse;
            RegistrationStatus = registrationStatus;
        }

    }
}