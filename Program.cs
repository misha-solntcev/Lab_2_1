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
            double Gradus = 10;
            Console.WriteLine($"Синус {Gradus} градусов = {Sinus_01(Radian(Gradus), 0.0001)}");
            Console.WriteLine(Sinus_02(Radian(10), 0.0001));
            
            Console.ReadKey();
        }

        // Функция расчета синуса с использованием разложения в ряд Маклорена.
        static double Sinus_01 (double Z, double E)
        {
            int degree = 1;         // Степень
            double numerator;       // Числитель
            double denominator = 1; // Знаменатель
            double fraction = 1;    // Дробь (текущее слагаемое полинома)
            double sum = Z;         // Текущая сумма 
            while (Math.Abs(fraction) > E)
            {
                degree += 2;
                numerator = Math.Pow(Z, degree);
                denominator = - denominator * degree * (degree - 1);
                fraction = numerator / denominator;
                sum += fraction;                             
            }
            return sum;
        }

        // Функция расчета синуса (Второй способ).
        static double Sinus_02 (double Z, double E)
        {
            double sum = Z;
            double den = 1;
            for (int k = 2; k < 1000000; k++)
            {
                int K = (int) Math.Pow(-1, (k + 1));    // Знак слагаемого. 
                double num = Math.Pow(Z, (2 * k - 1));  // Числитель.
                den = den * (2 * k - 1) * (2 * k - 2);  // Знаменатель(факториал).
                sum += K * num / den;                   // Текущая сумма.
                if (Math.Abs(K * num / den) < E)
                    break;                
            }            
            return sum;
        }

        // Функция перевода градусов в радианы
        static double Radian (double Z)
        {
            double result = Z * Math.PI / 180;
            return result;
        }
    }
}
