using Microsoft.Maui.Controls;

namespace HesapMakine2
{
    public partial class MainPage : ContentPage
    {
        private string currentInput = "";
        private string currentOperator = "";
        private double firstNumber, secondNumber;

        public MainPage()
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

        private void OnClearClicked(object sender, EventArgs e)
        {
            currentInput = "";
            Display.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            currentOperator = "";
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