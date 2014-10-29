using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName, string teacherName, List<Student> courseStudents, string town)
            : base(courseName, teacherName, courseStudents)
        {
            Validation.ValidateStringInput(town);
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                Validation.ValidateStringInput(value);
                this.town = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Town: " + this.Town + " }";
        }

    }
}
