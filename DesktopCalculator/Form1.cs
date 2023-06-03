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
            if (sender is Button button)
            {
                var buttonText = button.Text; //Текст кнопки
                var resultText = inputRichTextBox.Text; //строка ввода

                if (resultText == "0" || (operationPressed))
                {
                    inputRichTextBox.Clear();
                    resultRichTextBox.Clear();
                    value = 0;
                }

                if (buttonText == ".")
                {
                    if (!resultText.Contains("."))
                    {
                        inputRichTextBox.Text += buttonText;
                        resultRichTextBox.Text += buttonText;
                    }
                }
                else
                {
                    inputRichTextBox.Text += buttonText;
                    resultRichTextBox.Text += buttonText;
                }
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
                value = double.Parse(resultRichTextBox.Text);
                operationPressed = true;
                inputRichTextBox.Text = value + " " + operation;
            }
        }

        private void EqualOperation(object? sender, EventArgs e)
        {
            operationPressed = false;
            inputRichTextBox.Text = "";
            switch (operation)
            {
                case "+":
                    resultRichTextBox.Text = (value + double.Parse(resultRichTextBox.Text)).ToString();  
                    break;
                case "-":

                    break;
                case "*":

                    break;
                case "/":

                    break;
                default:
                    break;
            }
        }
    }
}