namespace prac5RMP
{
    public partial class MainPage : ContentPage
    {
        private double _firstNumber;
        private double _secondNumber;
        private string _operation;
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            string text = button.Text;

            if (double.TryParse(text, out double number))
            {
                ResultLabel.Text += text; // Добавляем цифру на экран
            }
            else if (text == "=")
            {
                // Вычисляем результат
                _secondNumber = double.Parse(ResultLabel.Text);
                double result = PerformCalculation();
                ResultLabel.Text = result.ToString();
                _firstNumber = 0;
                _secondNumber = 0;
                _operation = string.Empty;
            }
            else
            {
                // Запоминаем первую цифру и операцию
                _firstNumber = double.Parse(ResultLabel.Text);
                _operation = text;
                ResultLabel.Text = string.Empty;
            }
        }

        private double PerformCalculation()
        {
            return _operation switch
            {
                "+" => _firstNumber + _secondNumber,
                "-" => _firstNumber - _secondNumber,
                "*" => _firstNumber * _secondNumber,
                "/" => _firstNumber / _secondNumber,
                _ => 0,
            };
        }
    }
}
