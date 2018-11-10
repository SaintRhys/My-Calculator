using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Calculator : Form {

        string input = string.Empty;        //string storing user input
        string operand1 = string.Empty;     //string storing first operand
        string operand2 = string.Empty;     //string storing second operand
        char operation;                     //char for operation
        double result = 0.0;                //calculated result
        List<char> operList = new List<char>() {'+', '-', '/', '*'};

        public Calculator() {
            InitializeComponent();
            this.KeyPreview = true;
            Console.WriteLine("Starting");
        }

        #region buttons
        private void button1_Click(object sender, EventArgs e) {
            Universal_Button_Click("1");
        }

        private void button2_Click(object sender, EventArgs e) {
            Universal_Button_Click("2");
        }

        private void button3_Click(object sender, EventArgs e) {
            Universal_Button_Click("3");
        }

        private void button4_Click(object sender, EventArgs e) {
            Universal_Button_Click("4");
        }

        private void button5_Click(object sender, EventArgs e) {
            Universal_Button_Click("5");
        }

        private void button6_Click(object sender, EventArgs e) {
            Universal_Button_Click("6");
        }

        private void button7_Click(object sender, EventArgs e) {
            Universal_Button_Click("7");
        }

        private void button8_Click(object sender, EventArgs e) {
            Universal_Button_Click("8");
        }

        private void button9_Click(object sender, EventArgs e) {
            Universal_Button_Click("9");
        }

        private void button0_Click(object sender, EventArgs e) {
            Universal_Button_Click("0");
        }

        private void buttonPlus_Click(object sender, EventArgs e) {
            Operation_Button_Click('+');
        }

        private void buttonMinus_Click(object sender, EventArgs e) {
            Operation_Button_Click('-');
        }

        private void buttonMultiply_Click(object sender, EventArgs e) {
            Operation_Button_Click('*');
        }

        private void buttonDivide_Click(object sender, EventArgs e) {
            Operation_Button_Click('/');
        }

        private void buttonDot_Click(object sender, EventArgs e) {
            Universal_Button_Click(".");
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            Clear();
        }

        private void buttonEquals_Click(object sender, EventArgs e) {
            Equals();
        }
        #endregion buttons

        private void Operation_Button_Click(char oper){
            if (operList.Contains(textBox1.Text[0])) {
                operation = oper;
                this.textBox1.Text = oper.ToString();
            } else {
                operand1 = input;
                this.textBox1.Text = oper.ToString();
                this.textBox2.Text = input;
                operation = oper;
                input = string.Empty;
            }
            switch (oper) {
                case '+':
                    Task waitPlus = WaitSomeTime("button", "Plus");
                    break;
                case '-':
                    Task waitMinus = WaitSomeTime("button", "Minus");
                    break;
                case '*':
                    Task waitMultiply = WaitSomeTime("button", "Multiply");
                    break;
                case '/':
                    Task waitDivide = WaitSomeTime("button", "Divide");
                    break;
                default:
                    break;
            }
        }
        
        private void Universal_Button_Click(string num){
            if (textBox1.TextLength > 0) {
                if (operList.Contains(textBox1.Text[0])) {
                    textBox2.Text = operand1 + " " + operation;
                    this.textBox1.Text = "";
                    input += num;
                    this.textBox1.Text += input;
                } else {
                    this.textBox1.Text = "";
                    input += num;
                    this.textBox1.Text += input;
                }
            } else {
                this.textBox1.Text = "";
                input += num;
                this.textBox1.Text += input;
            }
            Task wait = WaitSomeTime("button", num);
        }

        private void Clear() {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
            Task wait = WaitSomeTime("button", "Clear");
        }

        public async Task WaitSomeTime(string button, string num) {
            Button newButton = this.Controls.Find(button + num, true)[0] as Button;
            newButton.Enabled = false;
            await Task.Delay(50);
            newButton.Enabled = true;
        }

        private void Equals() {
            if (textBox2.TextLength > 0) {
                Console.WriteLine("Doing maths");
                operand2 = input;
                double num1, num2;
                double.TryParse(operand1, out num1);
                double.TryParse(operand2, out num2);

                if (operation == '+') {
                    result = num1 + num2;
                    textBox1.Text = result.ToString();
                } else if (operation == '-') {
                    result = num1 - num2;
                    textBox1.Text = result.ToString();
                } else if (operation == '*') {
                    result = num1 * num2;
                    textBox1.Text = result.ToString();
                } else if (operation == '/') {
                    if (num2 != 0) {
                        result = num1 / num2;
                        textBox1.Text = result.ToString();
                    } else {
                        textBox1.Text = "DIV/Zero!";
                    }
                }
                textBox2.Text = "";
                input = string.Empty;
                this.operand1 = string.Empty;
                this.operand2 = string.Empty;
            }
            Task wait = WaitSomeTime("button", "Equals");
            //nothing
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e) {
            int key;
            if (int.TryParse(e.KeyChar.ToString(), out key))
                Universal_Button_Click(key.ToString());
            else if(e.KeyChar == '+' || e.KeyChar == '-' || e.KeyChar == '/' || e.KeyChar == '*')
                Operation_Button_Click(e.KeyChar);
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    Equals();
                    break;
                case Keys.Delete:
                    Clear();
                    break;
                default:
                    break;
            }
        }
    }
}
