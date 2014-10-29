using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling.Interfaces
{
    interface IDistancable3D
    {
        double CalculateDistance3D();
        double CalcDiagonalXYZ();
    }
}
