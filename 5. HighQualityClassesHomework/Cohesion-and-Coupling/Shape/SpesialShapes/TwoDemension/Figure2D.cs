using System;
using CohesionAndCoupling.Interfaces;

namespace CohesionAndCoupling.Shape.SpesialShapes.TwoDemension
{
    class Figure2D : SpesialShapeBase, IDistancable2D
    {
        public Figure2D(
            double width, double height, double depth,
            double pointX1, double pointY1, 
            double pointX2, double pointY2)
            : base(width, height, depth, pointX1, pointY1, pointX2, pointY2) { }


        public double CalculateDistance2D()
        {
            Validation.Validate2DPointsValue(this.PointX1, this.PointY1, this.PointX2, this.PointY2);

            double distance = GetDistance2D(this.PointX1, this.PointY1, this.PointX2, this.PointY2);

            return distance;
        }

        public  double CalculateDiagonalXY()
        {
            double diagonalXY = GetDistance2D(0, 0, this.Width, this.Height);

            return diagonalXY;
        }

        public double CalculateDiagonalXZ()
        {
            double diagonalXZ = GetDistance2D(0, 0, this.Width, this.Depth);

            return diagonalXZ;
        }

        public double CalculateDiagonalYZ()
        {
            double diagonalYZ = GetDistance2D(0, 0, this.Height, this.Depth);

            return diagonalYZ;
        }

        private static double GetDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        public override string ToString()
        {
            string output = String.Format("\r\nDistance in the 2D space = {0:f2}\r\n", this.CalculateDistance2D());
            output += String.Format("DiagonalXY = {0:f2}\r\n", this.CalculateDiagonalXY());
            output += String.Format("DiagonalXZ = {0:f2}\r\n", this.CalculateDiagonalXZ());
            output += String.Format("DiagonalYZ = {0:f2}\r\n", this.CalculateDiagonalYZ());

            return base.ToString() + output+ "\r\n";
        }

    }
}
