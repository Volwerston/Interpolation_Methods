using Interpolation_Methods.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation_Methods.Classes
{
    public static class InterpolationService
    {
        public static IInterpolationMethod GetInterpolationMethod(string title)
        {
            switch (title)
            {
                case "Лагранжа":
                    return new LaGrangeInterpolationMethod();
                case "Ньютона - вперед - нерівновіддалені":
                    return new NewtonFrontNonEquidistantMethod();
                case "Ньютона - назад - нерівновіддалені":
                    return new NewtonBackNonEquidistantMethod();
                case "Ньютона - вперед - рівновіддалені":
                    return new NewtonFrontEquidistantMethod();
                case "Ньютона - назад - рівновіддалені":
                    return new NewtonBackEquidistantMethod();
                default:
                    throw new NotImplementedException("Методу з такою назвою не знайдено");
            }
        }
    }
}
