using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling.Shape.SpesialShapes
{
    class SpesialShapeBase :Shape
    {
        private double pointX1;
        private double pointY1;
        private double pointX2;
        private double pointY2;

        public SpesialShapeBase(double width, double height, double depth, 
            double pointX1, double pointY1, double pointX2, double pointY2)
            : base(width, height, depth)
        {
            Validation.Validate2DPointsValue(pointX1, pointY1, pointX2, pointY2);

            this.PointX1 = pointX1;
            this.PointY1 = pointY1;
            this.PointX2 = pointX2;
            this.PointY2 = pointY2;
        }

        public double PointX1 { get; set; }
        public double PointY1 { get; set; }
        public double PointX2 { get; set; }
        public double PointY2 { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
