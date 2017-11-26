using ChM_Methods.Models;
using Interpolation_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_Methods.Classes
{
    public class NewtonBackNonEquidistantMethod : IInterpolationMethod
    {
        public double Calculate(MethodContext context)
        {
            List<Tuple<double, double>> nodes = this.GetInterpolationNodes(context);

            double res = CalculateResult(nodes, context.Node);

            return res;
        }

        private double CalculateResult(List<Tuple<double, double>> nodes, double node)
        {
            int n = nodes.Count;

            double res = nodes[n - 1].Item2;
            double t = 1;

            for (int i = 1; i < nodes.Count; ++i)
            {
                t *= (node - nodes[n - i].Item1);
                res += t * f(n - i - 1, n - 1, nodes);
            }

            return res;
        }

        private double f(int i, int k, List<Tuple<double, double>> x)
        {
            if (k - i == 1)
            {
                return (x[k].Item2 - x[i].Item2) / (x[k].Item1 - x[i].Item1);
            }
            else
            {
                return (f(i + 1, k, x) - f(i, k - 1, x)) / (x[k].Item1 - x[i].Item1);
            }

            //double res = 0;

            //for (int j = i; j <= k; ++j)
            //{
            //    double temp = x[j].Item2;

            //    for (int l = i; l <= k && l != j; ++l)
            //    {
            //        temp *= 1 / (x[j].Item1 - x[l].Item1);
            //    }

            //    res += temp;
            //}

            // return res;
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
