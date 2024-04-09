using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    internal class Xgenerate
    {
        public double leftx, rightx, stepx;
        public Xgenerate(double leftx, double rightx, double stepx) {
            this.leftx = leftx;
            this.rightx = rightx;
            this.stepx = stepx;
        }
        public class ZeroStepExeption : Exception
        {
            // Конструктор для передачи сообщения об ошибке базовому классу Exception
            public ZeroStepExeption(string message) : base(message)
            {
            }
        }


        public double[] Xgen(double leftx, double rightx, double stepx)
        {
            if (stepx == 0)
            {
                throw new ZeroStepExeption("Выберите шаг отличный от нуля!");

            }
            int lenofmas = 0;
            if (leftx < 0 || rightx < 0)
            {
                lenofmas = (int)((Math.Abs(leftx) + rightx) / stepx) + 1;
            }
            else
            {
                lenofmas = (int)((rightx - leftx) / stepx) + 1;
            }

            double[] x = new double[lenofmas];
            int i = 0;
            while (i < x.Length)
            {
                x[i] = leftx + i * stepx;
                i++;
            }          
            return x;
        }
        
    }
    
    
}
