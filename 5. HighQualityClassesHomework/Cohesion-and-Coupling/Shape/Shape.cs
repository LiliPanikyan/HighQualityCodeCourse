using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling.Shape
{
    class Shape
    {
        private double width;
        private double height;
        private double depth;

        public Shape(double width, double height, double depth)
        {
            Validation.CheckForNegativeOrZeroValue(width);
            Validation.CheckForNegativeOrZeroValue(height);
            Validation.CheckForNegativeOrZeroValue(depth);

            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                Validation.CheckForNegativeOrZeroValue(value);
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                Validation.CheckForNegativeOrZeroValue(value);
                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                Validation.CheckForNegativeOrZeroValue(value);
                this.depth = value;
            }
        }

        public override string ToString()
        {
            return "I am "+ this.GetType().Name;
        }       
    }
}
