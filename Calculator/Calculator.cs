using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator {
    public partial class Calculator : Form {

        string input = string.Empty;        //string storing user input
        string operand1 = string.Empty;     //string storing first operand
        string operand2 = string.Empty;     //string storing second operand
        char operation;                     //char for operation
        double result = 0.0;                //calculated result

        public Calculator() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "1";
            this.textBox1.Text += input;
        }

        private void button2_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "2";
            this.textBox1.Text += input;
        }

        private void button3_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "3";
            this.textBox1.Text += input;
        }

        private void button4_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "4";
            this.textBox1.Text += input;
        }

        private void button5_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "5";
            this.textBox1.Text += input;
        }

        private void button6_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "6";
            this.textBox1.Text += input;
        }

        private void button7_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "7";
            this.textBox1.Text += input;
        }

        private void button8_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "8";
            this.textBox1.Text += input;
        }

        private void button9_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "9";
            this.textBox1.Text += input;
        }

        private void button0_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += "0";
            this.textBox1.Text += input;
        }

        private void plus_Click(object sender, EventArgs e) {
            operand1 = input;
            operation = '+';
            input = string.Empty;
        }

        private void minus_Click(object sender, EventArgs e) {
            operand1 = input;
            operation = '-';
            input = string.Empty;
        }

        private void multiply_Click(object sender, EventArgs e) {
            operand1 = input;
            operation = '*';
            input = string.Empty;
        }

        private void divide_Click(object sender, EventArgs e) {
            operand1 = input;
            operation = '/';
            input = string.Empty;
        }

        private void dot_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            input += ".";
            this.textBox1.Text += input;
        }

        private void clear_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
        }

        private void equals_Click(object sender, EventArgs e) {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            if (operation == '+'){
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
                    textBox1.Text = "DIV/Zerp!";
                }
            }
        }
    }
}
