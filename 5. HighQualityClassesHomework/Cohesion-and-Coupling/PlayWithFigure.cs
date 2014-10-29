using System;
using CohesionAndCoupling.Interfaces;
using CohesionAndCoupling.Shape;
using CohesionAndCoupling.Shape.SpesialShapes.TwoDemension;
using CohesionAndCoupling.Shape.SpesialShapes.ThreeDemension;

namespace CohesionAndCoupling
{
    class PlayWithFigure
    {
        static void Main()
        {
            SimpleFigure figure = new SimpleFigure(5.5, 5.6, 2.2);
            Console.WriteLine(figure);

            Figure2D twoPointFigure = new Figure2D(5.5, 5.6, 2.2, 1, -2, 3, 4);
            Console.WriteLine(twoPointFigure);

            Figure3D threePointFigure = new Figure3D(3, 4, 5, 5, 2, -1, 3, -6, 4);
            Console.WriteLine(threePointFigure);

            Console.ReadLine();
        }
    }
}
