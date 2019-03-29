using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiLearn_MarielMartinez.BusinessLogic.Entities {
    public class RegistrationRequest {

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
        /// <param name="registrationUser">The user that made the request</param>
        /// <param name="registrationCourse">The course that the student wants to register for</param>
        /// <param name="registrationStatus">The status of the registration. </param>
        public RegistrationRequest(User registrationUser, Course registrationCourse, Status registrationStatus) {
            RegistrationUser = registrationUser;
            RegistrationCourse = registrationCourse;
            RegistrationStatus = RegistrationStatus;
        }
        
    }
}