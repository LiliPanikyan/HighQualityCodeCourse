using System;
using CohesionAndCoupling.Interfaces;

namespace CohesionAndCoupling.Shape.SpesialShapes.ThreeDemension
{
    class Figure3D : SpesialShapeBase, IDistancable3D
    {
        private double pointZ1;
        private double pointZ2;

        public Figure3D(
            double width, double height, double depth,
            double pointX1, double pointY1, 
            double pointX2, double pointY2, 
            double pointZ1, double pointZ2)
            : base(width, height, depth, pointX1, pointY1, pointX2, pointY2)
        {
            Validation.Validate3DPointsValue(
                this.PointX1, this.PointY1, 
                this.PointX2, this.PointY2, 
                this.PointZ1, this.PointZ2);
            
            this.PointZ1 = pointZ1;
            this.PointZ2 = pointZ2;
        }

        public double PointZ1 { get; set; }
        public double PointZ2 { get; set; }


        public double CalculateDistance3D()
        {
            Validation.Validate3DPointsValue(
                this.PointX1, this.PointY1, this.PointX2, this.PointY2, this.PointZ1, this.PointZ2);

            double distance = GetDistance3D(this.PointX1, this.PointY1, this.PointX2, this.PointY2, this.PointZ1, this.PointZ2);
            return distance;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = GetDistance3D(0, 0, 0, Width, Height, Depth);
            return distance;
        }

        private static double GetDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public override string ToString()
        {
            string output = String.Format("\r\nDistance in the 3D space = {0:f2}\r\n", this.CalculateDistance3D());
            output += String.Format("DiagonalXYZ = {0:f2}\r\n", this.CalcDiagonalXYZ());

            return base.ToString() + output + "\r\n";
        }
    }
}
