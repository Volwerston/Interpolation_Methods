using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_Methods.Classes
{
    public class MethodContext
    {
        public string Function { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double Node { get; set; }

        public double Delta { get; set; }
    }
}
