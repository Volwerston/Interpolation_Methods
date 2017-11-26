using ChM_Methods.Models;
using Interpolation_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_Methods.Classes
{
    public class NewtonBackEquidistantMethod : IInterpolationMethod
    {
        public double Calculate(MethodContext context)
        {
            List<Tuple<double, double>> nodes = this.GetInterpolationNodes(context);

            double res = this.CalculateResult(nodes, context.Node, context.Delta);

            return res;
        }

        private double CalculateResult(List<Tuple<double, double>> nodes, double node, double h)
        {
            int n = nodes.Count;
            double res = nodes[n-1].Item2;
            double fact = 1;
            double s = (node - nodes[n-1].Item1) / h;
            double t = 1;

            for (int i = 1; i < n; ++i)
            {
                fact *= i;
                t *= (s + i - 1);

                res += (Numerator(i, n-i-1, nodes) * t) / fact;
            }

            return res;
        }

        private double C(int k, int n)
        {
            return fact(n) / (fact(k) * fact(n - k));
        }

        private double fact(int i)
        {
            double res = 1;

            for (int j = 2; j <= i; ++j)
            {
                res *= j;
            }

            return res;
        }

        public double Numerator(int k, int i, List<Tuple<double, double>> x)
        {
            double res = 0;

            for (int j = 0; j <= k; ++j)
            {
                res += Math.Pow(-1, k - j) * C(j, k) * x[i + j].Item2;
            }

            return res;
        }

        private List<Tuple<double, double>> GetInterpolationNodes(MethodContext context)
        {
            List<Tuple<double, double>> nodes = new List<Tuple<double, double>>();

            Func f = new Func(context.Function);

            nodes.Add(new Tuple<double, double>(context.A, f.Evaluate(context.A)));

            context.Delta = (context.B - context.A) / 30;
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
