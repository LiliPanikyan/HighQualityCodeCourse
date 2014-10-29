using System;

namespace Abstraction
{
    class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                Validation.CheckForNegativeOrZeroValue(value);
                this.radius = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }

        public override string ToString()
        {            
            return base.ToString() + 
                String.Format("My perimeter is {0:f2}. My surface is {1:f2}.", 
                this.CalculatePerimeter(), this.CalculateSurface());
        }
    }
}
