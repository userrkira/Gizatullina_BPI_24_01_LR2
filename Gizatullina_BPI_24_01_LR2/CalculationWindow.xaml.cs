using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Gizatullina_BPI_24_01_LR2
{
    public partial class CalculationWindow : Window
    {
        private readonly FormulaCalculator _calculator;


        public CalculationWindow(FormulaCalculator calculator)
        {
            InitializeComponent();

            _calculator = calculator;

            ShowCalculation();
        }

        private void ShowCalculation()
        {
            FormulaImage.Source =
                new BitmapImage(
                    new Uri(_calculator.Source, UriKind.Absolute));

            if (_calculator is Formula1Calculator)
            {
                Formula1Calculator calculator =
                    (Formula1Calculator)_calculator;


                if (calculator.FormulaNumber == 1)
                {
                    InputDataTextBlock.Text =
                        "a = " + calculator.A +
                        "\nf = " + calculator.F;

                    CalculationTextBlock.Text =
                        "Вычисляется выражение:" +
                        "\n\n" +
                        "sin(f · a)";
                }


                if (calculator.FormulaNumber == 2)
                {
                    InputDataTextBlock.Text =
                        "a = " + calculator.A +
                        "\nb = " + calculator.B +
                        "\nf = " + calculator.F;

                    CalculationTextBlock.Text =
                        "Вычисляется выражение:" +
                        "\n\n" +
                        "cos(f · a) + sin(f · b)";
                }


                if (calculator.FormulaNumber == 3)
                {
                    InputDataTextBlock.Text =
                        "a = " + calculator.A +
                        "\nb = " + calculator.B +
                        "\nc = " + calculator.C +
                        "\nd = " + calculator.D;

                    CalculationTextBlock.Text =
                        "Вычисляется выражение:" +
                        "\n\n" +
                        "c · a² + d · b²";
                }
            }

            if (_calculator is Formula2Calculator)
            {
                Formula2Calculator calculator =
                    (Formula2Calculator)_calculator;


                InputDataTextBlock.Text =
                    "N = " + calculator.N +
                    "\nK = " + calculator.K +
                    "\nt = " + calculator.T +
                    "\nx = " + calculator.X +
                    "\nf = " + calculator.F +
                    "\ny = " + calculator.Y;


                CalculationTextBlock.Text =
                    "Выполняется двойная сумма:" +
                    "\n\n" +
                    "i изменяется от 1 до N = " +
                    calculator.N +
                    "\n" +
                    "j изменяется от 1 до K = " +
                    calculator.K +
                    "\n\n" +
                    "После сложения всех полученных членов суммы:";

            }
            double result = _calculator.Calculate();
            ResultTextBlock.Text =
                result.ToString("F4");
        }

        private void CloseButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            Close();
        }
    }
}