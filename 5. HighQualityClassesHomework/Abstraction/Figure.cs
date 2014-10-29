using System;

namespace Abstraction
{
    abstract class Figure : ICalculatable
    {
        private double width;
        private double height;
        private double radius;

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

        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        public override string ToString()
        {
            return "I am a " + this.GetType().Name + ". ";                
        }
    }
}
