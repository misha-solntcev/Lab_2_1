using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sinus(10, 0.0001));
            Console.ReadKey();
        }

        // Функция расчета синуса с использованием разложения в ряд Маклорена.
        static double Sinus (double Z, double E)
        {
            int degree = 1;
            double numerator;
            double denominator = 1;
            double fraction = 1;
            double sum = Z;
            while (Math.Abs(fraction) > E)
            {
                degree += 2;
                numerator = Math.Pow(Z, degree);
                denominator = - denominator * degree * (degree - 1);
                fraction = numerator / denominator;
                sum = sum + fraction;                             
            }
            return sum;
        }
    }
}
