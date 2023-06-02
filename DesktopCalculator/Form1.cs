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
            clearButton.Click += ButtonClick;
            addButton.Click += ButtonClick;
            subButton.Click += ButtonClick;
            multButton.Click += ButtonClick;
            divButton.Click += ButtonClick;
            #endregion
        }

        private void ButtonClick(object? sender, EventArgs e)
        {
            double firstNumber = 0;
            double secondNumber = 0;

            if (sender is Button button)
            {
                var inputText = button.Text; //Текст кнопки
                string str = inputRichTextBox.Text; //строка ввода

                if (inputText == "C")
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        return;
                    }
                    else
                    {
                        inputRichTextBox.Text = str.Remove(str.Length - 1);
                    }
                }
                else
                {
                    inputRichTextBox.Text += inputText;
                    firstNumber = double.Parse(inputText);
                }

                if (inputText == "+")
                {
                    solveRichTextBox.Text += inputRichTextBox.Text;
                    inputRichTextBox.Clear();
                }
            }
        }
    }
}