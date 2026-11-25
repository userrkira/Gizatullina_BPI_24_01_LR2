using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Gizatullina_BPI_24_01_LR2
{
    public partial class MainWindow : Window
    {
        private int selectedFormula = 0;

        public string SelectedValue { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 1; i <= 20; i++)
            {
                NComboBox.Items.Add(i);
                KComboBox.Items.Add(i);

                Formula1FComboBox.Items.Add(i);
                Formula2FComboBox.Items.Add(i);
                Formula3CComboBox.Items.Add(i);
                Formula3DComboBox.Items.Add(i);
            }

            NComboBox.SelectedIndex = 0;
            KComboBox.SelectedIndex = 0;

            Formula1FComboBox.SelectedIndex = 0;
            Formula2FComboBox.SelectedIndex = 0;
            Formula3CComboBox.SelectedIndex = 0;
            Formula3DComboBox.SelectedIndex = 0;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                selectedFormula = Convert.ToInt32(item.Tag);

                SelectedValue = item.Content?.ToString()
                    ?? "Формула " + selectedFormula;
            }
        }

        private void CalculateButton_Click(
            object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = "";

            if (selectedFormula == 0)
            {
                ErrorTextBlock.Text = "Выберите формулу.";
                return;
            }

            switch (selectedFormula)
            {
                case 1:
                    CalculateFormula1();
                    break;

                case 2:
                    CalculateFormula2();
                    break;

                case 3:
                    CalculateFormula3();
                    break;

                case 4:
                    CalculateFormula4();
                    break;
            }
        }

        private void CalculateFormula1()
        {
            double a;

            if (!TryParseDouble(Formula1ATextBox.Text, out a))
            {
                ErrorTextBlock.Text = "Введите корректное значение A.";
                return;
            }

            if (Formula1FComboBox.SelectedItem == null)
            {
                ErrorTextBlock.Text = "Выберите значение F.";
                return;
            }

            Formula1Calculator calculator =
                new Formula1Calculator(
                    "pack://application:,,,/Resources/Formula1.png");

            calculator.FormulaNumber = 1;
            calculator.A = a;
            calculator.F = Convert.ToInt32(
                Formula1FComboBox.SelectedItem);

            ShowCalculation(calculator);
        }

        private void CalculateFormula2()
        {
            double a;
            double b;

            if (!TryParseDouble(Formula2ATextBox.Text, out a))
            {
                ErrorTextBlock.Text = "Введите корректное значение A.";
                return;
            }

            if (!TryParseDouble(Formula2BTextBox.Text, out b))
            {
                ErrorTextBlock.Text = "Введите корректное значение B.";
                return;
            }

            if (Formula2FComboBox.SelectedItem == null)
            {
                ErrorTextBlock.Text = "Выберите значение F.";
                return;
            }

            Formula1Calculator calculator =
                new Formula1Calculator(
                    "pack://application:,,,/Resources/Formula2.png");

            calculator.FormulaNumber = 2;
            calculator.A = a;
            calculator.B = b;
            calculator.F = Convert.ToInt32(
                Formula2FComboBox.SelectedItem);

            ShowCalculation(calculator);
        }

        private void CalculateFormula3()
        {
            double a;
            double b;

            if (!TryParseDouble(Formula3ATextBox.Text, out a))
            {
                ErrorTextBlock.Text = "Введите корректное значение A.";
                return;
            }

            if (!TryParseDouble(Formula3BTextBox.Text, out b))
            {
                ErrorTextBlock.Text = "Введите корректное значение B.";
                return;
            }

            if (Formula3CComboBox.SelectedItem == null ||
                Formula3DComboBox.SelectedItem == null)
            {
                ErrorTextBlock.Text = "Выберите значения C и D.";
                return;
            }

            Formula1Calculator calculator =
                new Formula1Calculator(
                    "pack://application:,,,/Resources/Formula3.png");

            calculator.FormulaNumber = 3;
            calculator.A = a;
            calculator.B = b;
            calculator.C = Convert.ToInt32(
                Formula3CComboBox.SelectedItem);
            calculator.D = Convert.ToInt32(
                Formula3DComboBox.SelectedItem);

            ShowCalculation(calculator);
        }

        private void CalculateFormula4()
        {
            double t;
            double x;
            double f;
            double y;

            if (NComboBox.SelectedItem == null ||
                KComboBox.SelectedItem == null)
            {
                ErrorTextBlock.Text = "Выберите значения N и K.";
                return;
            }

            if (!TryParseDouble(TTextBox.Text, out t))
            {
                ErrorTextBlock.Text = "Введите корректное значение t.";
                return;
            }

            if (!TryParseDouble(XTextBox.Text, out x))
            {
                ErrorTextBlock.Text = "Введите корректное значение x.";
                return;
            }

            if (!TryParseDouble(FTextBox.Text, out f))
            {
                ErrorTextBlock.Text = "Введите корректное значение f.";
                return;
            }

            if (!TryParseDouble(YTextBox.Text, out y))
            {
                ErrorTextBlock.Text = "Введите корректное значение y.";
                return;
            }

            if (t == 0)
            {
                ErrorTextBlock.Text = "t не может быть равно 0.";
                return;
            }

            Formula2Calculator calculator =
                new Formula2Calculator(
                    "pack://application:,,,/Resources/Formula4.png");

            calculator.N = Convert.ToInt32(NComboBox.SelectedItem);
            calculator.K = Convert.ToInt32(KComboBox.SelectedItem);
            calculator.T = t;
            calculator.X = x;
            calculator.F = f;
            calculator.Y = y;

            ShowCalculation(calculator);
        }

        private void ShowCalculation(FormulaCalculator calculator)
        {
            try
            {
                CalculationWindow window =
                    new CalculationWindow(calculator);

                window.Owner = this;
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text =
                    "Не удалось выполнить расчёт: " + ex.Message;
            }
        }

        private bool TryParseDouble(string text, out double value)
        {
            text = (text ?? "").Trim().Replace(',', '.');

            return double.TryParse(
                text,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out value);
        }
    }
}
