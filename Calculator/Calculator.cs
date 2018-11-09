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

        private void plus_Click(object sender, EventArgs e) {
            Operation_Button_Click("+");
        }

        private void minus_Click(object sender, EventArgs e) {
            Operation_Button_Click("-");
        }

        private void multiply_Click(object sender, EventArgs e) {
            Operation_Button_Click("*");
        }

        private void divide_Click(object sender, EventArgs e) {
            Operation_Button_Click("/");
        }

        private void dot_Click(object sender, EventArgs e) {
            Universal_Button_Click(".");
        }

        private void clear_Click(object sender, EventArgs e) {
            this.textBox1.Text = "";
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
        }

        private void Operation_Button_Click(string oper){
            operand1 = input;
            operation = oper;
            input = string.Empty;       
        }
        
        private void Universal_Button_Click(string num){
            this.textBox1.Text = "";
            input += num;
            this.textBox1.Text += input;
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
                    textBox1.Text = "DIV/Zero!";
                }
            }
        }
    }
}
