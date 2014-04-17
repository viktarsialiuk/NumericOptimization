using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Program
    {
        static void OnIteration(int i, double value, double diff, double[] point)
        {
            Console.WriteLine("Iteration={0}\tValue={1:E}\tDiff={2:E}", i, value, diff);
        }

        static void Main(string[] args)
        {
            double[] initial = new double[] { 0 };
            var minimum = new GradientDescent(0.1, 1000, 1e-12)
                .Minimize(initial,
                          x => (x[0] - 500) * (x[0] - 500),             //f(x) = (x - 500)^2
                          x => new double[] { 2 * x[0] - 2 * 500 });    //f'(x) = 2x - 1000


            Console.WriteLine("Minimized value {0}", minimum[0]);
        }
    }
}
