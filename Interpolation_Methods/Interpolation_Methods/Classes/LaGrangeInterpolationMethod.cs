using ChM_Methods.Models;
using Interpolation_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_Methods.Classes
{
    class LaGrangeInterpolationMethod : IInterpolationMethod
    {
        public double Calculate(MethodContext context)
        {
            List<Tuple<double, double>> nodes = this.GetInterpolationNodes(context);

            double res = this.CalculatePolynomial(nodes, context.Node);

            return res;
        }

        private double CalculatePolynomial(List<Tuple<double, double>> nodes, double node)
        {
            double res = 0;

            for(int i = 0; i < nodes.Count; ++i)
            {
                double temp = 1;

                for(int j = 0; j < nodes.Count; ++j)
                {
                    if(i != j)
                    {
                        temp *= (node - nodes[j].Item1) / (nodes[i].Item1 - nodes[j].Item1);
                    }
                }

                temp *= nodes[i].Item2;

                res += temp;
            }

            return res;
        }

        private List<Tuple<double, double>> GetInterpolationNodes(MethodContext context)
        {
            List<Tuple<double, double>> nodes = new List<Tuple<double, double>>();

            Func f = new Func(context.Function);

            nodes.Add(new Tuple<double, double>(context.A, f.Evaluate(context.A)));

            double delta = context.Delta;
            double temp = context.A + delta;

            while (temp < context.B)
            {
                nodes.Add(new Tuple<double, double>(temp, f.Evaluate(temp)));

                temp += delta;
            }

            nodes.Add(new Tuple<double, double>(context.B, f.Evaluate(context.B)));

            return nodes;
        }
    }
}
