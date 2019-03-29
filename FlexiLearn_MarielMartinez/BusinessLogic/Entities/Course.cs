using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlexiLearn_MarielMartinez.BusinessLogic.Entities {
    public class Course {

        /// <summary>
        /// Course identifier
        /// </summary>
        string courseCode;
        /// <summary>
        /// Course identifier
        /// </summary>
        public string CourseCode {
            get { return courseCode; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Course Code must have a value");
                }
                courseCode = value;
            }
        }

        /// <summary>
        /// Name of the course
        /// </summary>
        string title;
        /// <summary>
        /// Name of the course
        /// </summary>
        public string Title {
            get { return title; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Title must have a value");
                }
                title = value;
            }
        }

        /// <summary>
        /// Description of the subject of the course
        /// </summary>
        string subject;
        /// <summary>
        /// Description of the subject of the course
        /// </summary>
        public string Subject {
            get { return subject; }
            set {
                if (string.IsNullOrEmpty(value)) {
                    throw new ArgumentException("Subject must have a value");
                }
                subject = value;
            }
        }

        /// <summary>
        /// The amount of hours the course will take to complete
        /// </summary>
        float duration;
        /// <summary>
        /// The amount of hours the course will take to complete
        /// </summary>
        public float Duration {
            get { return duration; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Duration must be a positive value");
                }
                duration = value;
            }
        }

        /// <summary>
        /// The price to take the course
        /// </summary>
        float fee;
        /// <summary>
        /// The price to take the course
        /// </summary>
        public float Fee {
            get { return fee; }
            set {
                if (value < 0) {
                    throw new ArgumentException("Fee must have a value");
                }
                fee = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Name of the course</param>
        /// <param name="subject">Description of the subject of the course</param>
        /// <param name="duration">The amount of hours the course will take to complete</param>
        /// <param name="fee">The price to take the course</param>
        public Course(string code, string title, string subject, float duration, float fee) {
            CourseCode = code;
            Title = title;
            Subject = subject;
            Duration = duration;
            Fee = fee;
        }
    }
}