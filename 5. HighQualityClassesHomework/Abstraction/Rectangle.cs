using System;

namespace Abstraction
{
    class Rectangle : Figure
    {
        
        public Rectangle(double width, double height)           
        {
            this.Width = width;
            this.Height = height;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
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
