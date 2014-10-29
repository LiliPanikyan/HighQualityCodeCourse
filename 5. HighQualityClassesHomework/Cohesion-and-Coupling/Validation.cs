using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    public class Validation
    {
        public static void CheckForNegativeOrZeroValue(double value)
        {
            if (value <= 0)
            {
                throw new IndexOutOfRangeException("Value can't be negative or equal to zero!");
            }


        }

        public static void Validate2DPointsValue(double x1, double y1, double x2, double y2)
        {
            if (x1 == y1 && y1 == x2 && x2 == y2)
            {
                throw new IndexOutOfRangeException("Values can't be equals!");
            }            
        }
        public static void Validate3DPointsValue(double x1, double y1, double x2, double y2, double z1, double z2)
        {
            if (x1 == y1 && y1 == x2 && x2 == y2 && y2 == z1 && z1 == z2)
            {
                throw new IndexOutOfRangeException("Values can't be equals!");
            }
        }
        
    }
}
