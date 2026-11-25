using System;

namespace Gizatullina_BPI_24_01_LR2
{
    public class Formula2Calculator : FormulaCalculator
    {
        public int N { get; set; }
        public int K { get; set; }
        public double T { get; set; }
        public double X { get; set; }
        public double F { get; set; }
        public double Y { get; set; }


        public Formula2Calculator(string source)
            : base(source)
        {
        }


        public override double Calculate()
        {
            if (N <= 0)
                throw new ArgumentException(
                    "N должно быть больше нуля.");

            if (K <= 0)
                throw new ArgumentException(
                    "K должно быть больше нуля.");

            double result = 0;


            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    double numerator =
                        i * Math.Pow(X, i)
                        + Math.Pow(F, j) * Math.Pow(Y, j);

                    double denominator =
                        T * i - j;


                    if (denominator == 0)
                    {
                        throw new ArgumentException(
                            "Знаменатель выражения не может быть равен нулю.");
                    }


                    result += numerator / denominator;
                }
            }


            return result;
        }
    }
}