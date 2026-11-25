using System;

namespace Gizatullina_BPI_24_01_LR2
{
    public class FormulaCalculator
    {
        public string Source { get; set; }

        public FormulaCalculator(string source)
        {
            Source = source;
        }

        public virtual double Calculate()
        {
            return 0;
        }
    }
}