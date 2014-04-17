using System;

namespace Optimization
{
    public interface IMinimizer
    {
        double[] Minimize(double[] initialPoint, Func<double[], double> funcEvaluator, Func<double[], double[]> gradientEvaluator);
    }
}
