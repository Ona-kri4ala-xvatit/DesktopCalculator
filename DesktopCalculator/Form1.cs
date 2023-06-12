using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace DesktopCalculator
{
    public partial class Form1 : Form
    {
        private double value = 0;
        private string operation = string.Empty;
        private bool operationPressed = false;
        private string fileName = "logfile.txt";
        private List<string> logList = new List<string>();

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
            if ((toDoMathRichTextBox.Text == "0") || (operationPressed))
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
            toDoMathRichTextBox.Text = string.Empty;
            resultRichTextBox.Text = string.Empty;
        }

        private void SetOperation(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                operation = button.Text;
                value = double.Parse(resultRichTextBox.Text, CultureInfo.InvariantCulture.NumberFormat);
                operationPressed = true;
                toDoMathRichTextBox.Text = value + " " + operation;
            }
        }

        private void EqualOperation(object? sender, EventArgs e)
        {
            string toDoMathText = value + " " + operation + " " + resultRichTextBox.Text;
            toDoMathRichTextBox.Text = toDoMathText;
            logFileListBox.Items.Add(toDoMathText);
            logList.Add(toDoMathText);

            switch (operation)
            {
                case "+":
                    resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 1).ToString();     
                    File.AppendAllLines(fileName, logList);
                    break;
                case "-":
                    resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 2).ToString();
                    File.AppendAllLines(fileName, logList);
                    break;
                case "*":
                    resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 3).ToString();
                    File.AppendAllLines(fileName, logList);
                    break;
                case "/":
                    try
                    {
                        resultRichTextBox.Text = MathOperation.Operations(value, resultRichTextBox.Text, 4).ToString();
                        File.AppendAllLines(fileName, logList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), MessageBoxIcon.Warning.ToString());
                        ButtonClear(this, null);
                    }
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var text = File.ReadAllLines(fileName);

            foreach (var item in text)
            {
                logFileListBox.Items.Add(item);
            }
        }
    }
}