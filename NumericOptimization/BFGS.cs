using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public class BFGS : IMinimizer
    {
        public double[] Minimize(double[] initialPoint, Func<double[], double> funcEvaluator, Func<double[], double[]> gradientEvalutor)
        {
            return initialPoint;
        }
    }
}
