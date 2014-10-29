using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public class Validation
    {
        public static void CheckForNegativeOrZeroValue(double value)
        {
            if(value <= 0)
            {
                throw new IndexOutOfRangeException ("Value can't be negative or equal to zero!");
            }
            
            
        }
    }
}
