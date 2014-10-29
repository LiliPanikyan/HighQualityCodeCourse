using System;

using CohesionAndCoupling.Interfaces;

namespace CohesionAndCoupling.Shape
{
    class SimpleFigure :Shape, IVolumeable
    {
        public SimpleFigure(double width, double height, double depth)
            : base(width, height, depth) { }
 
        public double CalculateVolume()
        {
            
            double volume = this.Width * this.Height * this.Depth;
            
            return volume;
        }

        public override string ToString()
        {
            return base.ToString() +
                String.Format(" with Volume = {0:f2}", this.CalculateVolume()+ "\r\n");
        }
    }
}
