using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InheritanceAndPolymorphism
{
    public class Validation
    {
        public static void ValidateName(string input)
        {
            if(String.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input", "Name can't be empty!");
            }
            else if (!Regex.Match(input, "^[a-zA-Z]*$").Success)
            {
                throw new ArgumentException("Invalid name! Allowed chars [a-zA-Z]");
            }
            else if(input.Length < 3)
            {
                throw new ArgumentOutOfRangeException("input", "Invalid name! Name lenght should be > 3!");
            }
        }

        public static void ValidateStringInput(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input", "String value can't be empty!");
            }
            else if (!Regex.Match(input, "^[a-zA-Z]*$").Success)
            {
                throw new ArgumentException("Invalid string value! Allowed chars [a-zA-Z]");
            }
        }

    }
}
