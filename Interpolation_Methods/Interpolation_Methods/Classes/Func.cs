using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChM_Methods.Models
{
    public class Func
    {
        private readonly string prototype;

        public string Prorotype
        {
            get
            {
                return prototype;
            }
        }

        public Func(string _p)
        {
            prototype = _p;
        }

        public double Evaluate(double arg)
        {
            Argument x = new Argument("x");
            Expression exp = new Expression(prototype, x);
            x.setArgumentValue(arg);

            return exp.calculate();
        }

        public Func Derivative()
        {
            Expression exp = new Expression("der(" + Prorotype + ",x)");
            return new Func(exp.getExpressionString());
        }
    }
}