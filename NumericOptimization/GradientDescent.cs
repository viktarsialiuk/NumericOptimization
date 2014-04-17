using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    public class GradientDescent : IMinimizer
    {
        private int _maxIteraions;
        private double _step;
        private double _convergence;

        public GradientDescent(double step, int maxIteraions, double convergence)
        {
            _step = step;
            _maxIteraions = maxIteraions;
            _convergence = convergence;
        }

        public double[] Minimize(double[] initialPoint, Func<double[], double> funcEvaluator, Func<double[], double[]> gradientEvaluator)
        {
            double prevValue = funcEvaluator(initialPoint);
            double[] point = new double[initialPoint.Length];
            Array.Copy(initialPoint, point, point.Length);

            for (int i = 0; i < _maxIteraions; ++i)
            {
                double[] gradient = gradientEvaluator(point);
                for (int j = 0; j < point.Length; ++j)
                {
                    point[j] -= _step * gradient[j];
                }

                double curValue = funcEvaluator(point);
                double diff = Math.Abs(curValue - prevValue);

                Console.WriteLine("Iteration = {0}\tValue = {1:E}\tDiff = {2:E}\tDiff {3} {4}\t{5}",
                    i,
                    curValue,
                    diff,
                    diff < _convergence ? "<" : ">",
                    _convergence,
                    diff < _convergence ? "STOP" : "CONTINUE");

                if (diff < _convergence)
                {
                    break;
                }

                prevValue = curValue;
            }
            return point;
        }
    }
}
