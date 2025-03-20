using Microsoft.Maui.Controls;
using System;

namespace HesapMakine2
{
    public partial class ScientificPage : ContentPage
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double firstNumber, secondNumber;

        public ScientificPage()
        {
            InitializeComponent();
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            currentInput += button.Text;
            Display.Text = currentInput;
        }

        private void OnOperatorClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                Display.Text = "Hata: Geçersiz giriş";
                return;
            }

            var button = (Button)sender;
            currentOperator = button.Text;
            firstNumber = double.Parse(currentInput);
            currentInput = "";
        }

        private void OnLogClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double number) && number > 0)
            {
                double result = Math.Log10(number);
                Display.Text = result.ToString();
                currentInput = result.ToString();
            }
            else
            {
                Display.Text = "Hata: Geçersiz giriş";
            }
        }

        private void OnSquareClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double number))
            {
                double result = Math.Pow(number, 2);
                Display.Text = result.ToString();
                currentInput = result.ToString();
            }
        }

        private void OnSinClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double number))
            {
                double result = Math.Sin(number * Math.PI / 180); // Derece cinsinden
                Display.Text = result.ToString();
                currentInput = result.ToString();
            }
        }

        private void OnCosClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double number))
            {
                double result = Math.Cos(number * Math.PI / 180); // Derece cinsinden
                Display.Text = result.ToString();
                currentInput = result.ToString();
            }
        }

        private void OnLnClicked(object sender, EventArgs e)
        {
            if (double.TryParse(currentInput, out double number) && number > 0)
            {
                double result = Math.Log(number);
                Display.Text = result.ToString();
                currentInput = result.ToString();
            }
            else
            {
                Display.Text = "Hata: Geçersiz giriş";
            }
        }

        private void OnPiClicked(object sender, EventArgs e)
        {
            Display.Text = Math.PI.ToString();
            currentInput = Math.PI.ToString();
        }

        private void OnEClicked(object sender, EventArgs e)
        {
            Display.Text = Math.E.ToString();
            currentInput = Math.E.ToString();
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentInput = "";
            Display.Text = "";
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                Display.Text = "Hata: Geçersiz giriş";
                return;
            }

            secondNumber = double.Parse(currentInput);
            double result = 0;

            switch (currentOperator)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        Display.Text = "Hata: Sıfıra bölme";
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }

            Display.Text = result.ToString();
            currentInput = result.ToString();
        }
    }
}