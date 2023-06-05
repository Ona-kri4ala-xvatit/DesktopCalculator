using System.Globalization;

namespace DesktopCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            #region Events
            oneButton.Click += ButtonClick;
            twoButton.Click += ButtonClick;
            threeButton.Click += ButtonClick;
            fourButton.Click += ButtonClick;
            fiveButton.Click += ButtonClick;
            sixButton.Click += ButtonClick;
            sevenButton.Click += ButtonClick;
            eightButton.Click += ButtonClick;
            nineButton.Click += ButtonClick;
            zeroButton.Click += ButtonClick;
            pointButton.Click += ButtonClick;
            clearButton.Click += ButtonClear;
            addButton.Click += SetOperation;
            subButton.Click += SetOperation;
            multButton.Click += SetOperation;
            divButton.Click += SetOperation;
            equalMarkButton.Click += EqualOperation;
            #endregion
        }

        private double value = 0;
        private string operation = string.Empty;
        private bool operationPressed = false;

        private void ButtonClick(object? sender, EventArgs e)
        {
            var resultText = inputRichTextBox.Text; //строка ввода

            if ((resultText == "0") || (operationPressed))
            {
                resultRichTextBox.Clear();
            }

            operationPressed = false;

            if (sender is Button button)
            {
                var buttonText = button.Text; //Текст кнопки
                resultRichTextBox.Text += buttonText;
            }
        }

        private void ButtonClear(object? sender, EventArgs e)
        {
            inputRichTextBox.Text = string.Empty;
            resultRichTextBox.Text = string.Empty;
        }

        private void SetOperation(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                operation = button.Text;
                value = double.Parse(resultRichTextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                operationPressed = true;
                inputRichTextBox.Text = value + " " + operation;
            }
        }

        private void EqualOperation(object? sender, EventArgs e)
        {
            inputRichTextBox.Text = value + " " + operation + " " + resultRichTextBox.Text;

            switch (operation)
            {
                case "+":
                    resultRichTextBox.Text = (value + double.Parse(resultRichTextBox.Text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
                    break;
                case "-":
                    resultRichTextBox.Text = (value - double.Parse(resultRichTextBox.Text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
                    break;
                case "*":
                    resultRichTextBox.Text = (value * double.Parse(resultRichTextBox.Text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
                    break;
                case "/":
                    try
                    {
                        if (resultRichTextBox.Text == "0")
                        {
                            throw new DivideByZeroException("Divide by zero");
                        }
                        resultRichTextBox.Text = (value / double.Parse(resultRichTextBox.Text, CultureInfo.InvariantCulture.NumberFormat)).ToString();
                    }
                    catch (Exception ex)
                    {
                        resultRichTextBox.Text = ex.Message.ToString();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}