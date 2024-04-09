using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class MyFunctions
    {
        public double[] x, y;
        public MyFunctions(double[] x, double[] y) {
            this.x = x;
            this.y = y;
        }

        public double func1(double x, double y)
        {
           
                return y / Math.Cos(1 / (x * x));
            
            
        }
    }
}
