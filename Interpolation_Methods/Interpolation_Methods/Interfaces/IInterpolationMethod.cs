using Interpolation_Methods.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_Methods.Interfaces
{
    public interface IInterpolationMethod
    {
        double Calculate(MethodContext context);
    }
}
