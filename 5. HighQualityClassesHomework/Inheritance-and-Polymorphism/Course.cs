using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Course
    {
        private string courseName;
        private string teacherName;
        private List<Student> courseStudents;

        public Course(string courseName, string teacherName, List<Student> courseStudents)
        {
            Validation.ValidateName(courseName);
            Validation.ValidateName(teacherName);
            
            this.CourseName = courseName;          
            this.TeacherName = teacherName;
            this.CourseStudents = courseStudents;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                Validation.ValidateName(value);
                this.courseName = value;
            }
        }
        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                Validation.ValidateName(value);
                this.teacherName = value;
            }
        }

        public List<Student> CourseStudents { get; set; }

        private string GetStudentsAsString()
        {
            if (this.CourseStudents == null || this.CourseStudents.Count == 0)
            {
                return "There is no data for this course students!";
            }
            else
            {
                return "{ " + string.Join(", ", this.CourseStudents) + " }";
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(this.GetType().Name);
            result.AppendLine("{ Name: " + this.CourseName);
            result.AppendLine("Course Teacher: " + this.TeacherName);
            result.AppendLine("Course Students: " + this.GetStudentsAsString());

            return result.ToString();
        }
    }
}
