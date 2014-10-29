using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling.Interfaces
{
    interface IDistancable2D
    {
        double CalculateDistance2D();

        double CalculateDiagonalXY();

        double CalculateDiagonalXZ();

        double CalculateDiagonalYZ();

    }
}
