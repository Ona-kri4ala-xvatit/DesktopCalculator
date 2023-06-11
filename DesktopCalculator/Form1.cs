using System.Globalization;

namespace DesktopCalculator
{
    public partial class Form1 : Form
    {
        private double value = 0;
        private string operation = string.Empty;
        private bool operationPressed = false;

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

        private void ButtonClick(object? sender, EventArgs e)
        {
            if ((inputRichTextBox.Text == "0") || (operationPressed))
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
                    resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 1).ToString();
                    break;
                case "-":
                    resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 2).ToString();
                    break;
                case "*":
                    resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 3).ToString();
                    break;
                case "/":
                    try
                    {
                        resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 4).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), MessageBoxButtons.OK.ToString());
                        ButtonClear(this, null);
                        //resultRichTextBox.Text = ex.Message.ToString();
                    }
                    break;
                default:
                    break;
            }
        }

    }
}