using System;

namespace Gizatullina_BPI_24_01_LR2
{
    public class Formula1Calculator : FormulaCalculator
    {
        public int FormulaNumber { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public int F { get; set; }

        public Formula1Calculator(string source)
            : base(source)
        {
        }

        public override double Calculate()
        {
            switch (FormulaNumber)
            {
                case 1:
                    return Math.Sin(F * A);

                case 2:
                    return Math.Cos(F * A)
                         + Math.Sin(F * B);

                case 3:
                    return C * A * A
                         + D * B * B;

                default:
                    throw new ArgumentException(
                        "Не выбрана формула.");
            }
        }
    }
}