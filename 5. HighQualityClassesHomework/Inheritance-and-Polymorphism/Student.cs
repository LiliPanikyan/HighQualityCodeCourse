using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Student
    {
        private string studentName;

        public Student(string name)
        {
            Validation.ValidateName(name);
            this.StudentName = name;
        }

        public string StudentName
        {
            get
            {
                return this.studentName;
            }
            set
            {
                Validation.ValidateName(value);
                this.studentName = value;
            }
        }

        public override string ToString()
        {
            return this.StudentName.ToString();
        }
    }
}
