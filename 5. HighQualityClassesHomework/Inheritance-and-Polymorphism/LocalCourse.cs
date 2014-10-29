using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName, string teacherName, List<Student> courseStudents, string lab)
            : base(courseName, teacherName, courseStudents)
        {
            Validation.ValidateStringInput(lab);
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {

                Validation.ValidateStringInput(value);
                this.lab = value;

            }
        }

        public override string ToString()
        {
            return base.ToString() + "Lab: " + this.Lab + " }";
        }
    }
}
