using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Calculator {
    public partial class calculator : Form {

        public Queue ScreenBuffer = new Queue();   //This queue stores what needs to be printed to screen
        double num1, num2, answer;
        static int numStatus;
        char operation ;

        public calculator() {
            this.Text = "Calculator";
            InitializeComponent();
            num1 = 0.0; num2 = 0.0; answer = 0; numStatus = 1; operation = ' ';
        }

        private void Form1_Load(object sender, EventArgs e) {
            basicSelector.Checked = true;
            this.Text = "Calculator";
        }

        public String ContentsInScreen() { //returns what currently is in calculator's screen as string
            String toDisplay = "";
            foreach ( char a in ScreenBuffer ) {
                toDisplay = toDisplay + a;
            }
            if ( toDisplay.Length == 0 ) return "0";
            else return toDisplay;
        }

        public void displayMathError() {
            ScreenBuffer.Clear();
            screen.Text = "MATH ERROR";
            num1 = 0;
        }

       private void changeScreen() { //refreshes the contents to be displayed in screen
            screen.Text = ContentsInScreen();
        }

  
        //Entry buttons group
        private void button_1_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('1');
            changeScreen();
        }
        private void button_2_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('2');
            changeScreen();
        }
        private void button_3_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('3');
            changeScreen();
        }
        private void button_4_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('4');
            changeScreen();
        }
        private void button_5_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('5');
            changeScreen();
        }
        private void button_6_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('6');
            changeScreen();
        }
        private void button_7_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('7');
            changeScreen();
        }
        private void button_8_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('8');
            changeScreen();
        }
        private void button_9_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('9');
            changeScreen();
        }
        private void button_0_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('0');
            changeScreen();
        }
        private void dot_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('.');
            changeScreen();
        }
        private void powerten_Click(object sender, EventArgs e) {
            ScreenBuffer.Enqueue('E');
            changeScreen();
        }
        private void negative_Click(object sender, EventArgs e) {
            if (ContentsInScreen() == "0") {
                ScreenBuffer.Clear();
                ScreenBuffer.Enqueue('-');
                changeScreen();
            } else screen.Text = "Error. Format: (-)XXXX";
        }
        //End of entry button group

        //Operator buttons group
        private void button_plus_Click(object sender, EventArgs e) {
            switch ( numStatus ) {
                case 1: num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
                default: num1 += Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
            }
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            operation = '+';
            ScreenBuffer.Clear();
            changeScreen();
        }
        private void button_minus_Click(object sender, EventArgs e) {
            switch (numStatus) {
                case 1:
                    num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
                default:
                    num1 -= Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
            }
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            operation = '-';
            ScreenBuffer.Clear();
            changeScreen();
        }
        private void button_multiply_Click(object sender, EventArgs e) {
            switch (numStatus) {
                case 1:
                    num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
                default:
                    num1 *= Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
            }
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            operation = '*';
            ScreenBuffer.Clear();
            changeScreen();
        }
        private void button_divide_Click(object sender, EventArgs e) {
            switch (numStatus) {
                case 1:
                    num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
                default:
                    num1 /= Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
            }
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            operation = '/';
            ScreenBuffer.Clear();
            changeScreen();
        }
        private void powern_Click(object sender, EventArgs e) {
            switch (numStatus) {
                case 1:
                    num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                    break;
                default:
                    num1 = Math.Pow(num1, Convert.ToDouble(Convert.ToInt32(ContentsInScreen())));
                    break;
            }
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            operation = '^';
            ScreenBuffer.Clear();
            changeScreen();
        }
        private void equals_Click(object sender, EventArgs e) {
            switch (operation) {
                    case '+':
                        try {
                            if (numStatus != 3) num2 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                            num1 = num1 + num2;
                        } catch (Exception) {
                            screen.Text = "ERROR";
                            changeScreen();
                        }
                        break;
                    case '-':
                        if (numStatus != 3) num2 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                        num1 = num1 - num2;
                        break;
                    case '*':
                        if (numStatus != 3) num2 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                        num1 = num1 * num2;
                        break;
                    case '/':
                        if (numStatus != 3) num2 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                        num1 = num1 / num2;
                        break;
                    case '^':
                        if (numStatus != 3) num2 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
                        num1 = Math.Pow(num1, num2);
                        break;
                    default:
                        num1 = Convert.ToDouble((ContentsInScreen()));
                        break;
            }
            ScreenBuffer.Clear();
            answer = num1;
            String temp = num1.ToString();
            foreach ( char c in temp ) {
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        //End of operator buttons group

        //Control Buttons
        private void clear_Click(object sender, EventArgs e) {
            num1 = 0.0; num2 = 0.0;
            numStatus = 1;
            operation = ' ';
            ScreenBuffer.Clear();
            changeScreen();
        }
        private void backspace_Click(object sender, EventArgs e) {
            ScreenBuffer.Dequeue();
            changeScreen();
        }
        private void ans_Click(object sender, EventArgs e) {
            String temp;
            temp = answer.ToString();
            if (numStatus == 1) {
                foreach (char c in temp) {
                    ScreenBuffer.Enqueue(c);
                }
                screen.Text = temp;
                numStatus = 2;
            } else {
                num2 = Convert.ToDouble(temp);
                screen.Text = temp;
                numStatus = 3;
            }
        }
        //End of Control Buttons

        //Scientific Panel
        private void scientificPanel_Paint(object sender, PaintEventArgs e) { }
        private void basicSelector_CheckedChanged(object sender, EventArgs e) { //do this when Basic mode is selected
            this.Height = 320;
            scientificPanel.Enabled = true;
            scientificPanel.Visible = false;
        }
        private void scientificSelector_CheckedChanged(object sender, EventArgs e) { //do this when Scientific mode is selected
            this.Height = 450;
            scientificPanel.Enabled = true;
            scientificPanel.Visible = true;
        }
        //End of Scientific Panel

        bool isOddNumber(double a) {
            if (a % 1 != 0) return false;
            else if (a % 2 == 0) return false;
            else return true;
        }

        //Mathematic functions
        private void sine_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 = Math.Sin(num1*(Math.PI/180.0));
            ScreenBuffer.Clear();
            answer = Math.Round(num1,12);
            String temp = answer.ToString();
            foreach (char c in temp){
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        private void cosine_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 = Math.Cos(num1 * (Math.PI / 180.0));
            ScreenBuffer.Clear();
            answer = Math.Round(num1, 12);
            String temp = answer.ToString();
            foreach (char c in temp) {
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        private void tangent_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            if(isOddNumber((num1/90.0))) displayMathError(); //if the number provided is odd multiple of 90 degree, then tangent is infinite
            else{
                num1 = Math.Tan(num1 * (Math.PI / 180.0));
                ScreenBuffer.Clear();
                answer = Math.Round(num1, 12);
                String temp = answer.ToString();
                foreach (char c in temp) {
                    ScreenBuffer.Enqueue(c);
                }
                changeScreen();
            }
            operation = ' ';
        }
        private void square_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 *= num1;
            ScreenBuffer.Clear();
            answer = num1;
            String temp = num1.ToString();
            foreach (char c in temp) {
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        private void squareRoot_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 = Math.Pow(num1,0.5);
            ScreenBuffer.Clear();
            answer = num1;
            String temp = num1.ToString();
            foreach (char c in temp){
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        private void log_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            if (num1>0) { //only for positive non zero numbers
                num1 = Math.Log10(num1);
                ScreenBuffer.Clear();
                answer = Math.Round(num1, 12);
                String temp = answer.ToString();
                foreach (char c in temp) {
                    ScreenBuffer.Enqueue(c);
                }
                changeScreen();
            } else displayMathError();
            operation = ' ';
        }
        private void ln_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            if (num1 > 0) { //only for positive non zero numbers
                num1 = Math.Log(num1);
                ScreenBuffer.Clear();
                answer = Math.Round(num1, 12);
                String temp = answer.ToString();
                foreach (char c in temp) {
                    ScreenBuffer.Enqueue(c);
                }
                changeScreen();
            } else  displayMathError();
            operation = ' ';
        }      
        private void factorial_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            if (num1%1 == 0 && num1>=0 && num1<=20) { //only if the number is natural number less than 20
                long _temp = (factorialOf(Convert.ToInt32(num1)));
                num1 = (double)_temp;
                ScreenBuffer.Clear();
                String temp = num1.ToString();
                foreach (char c in temp) {
                    ScreenBuffer.Enqueue(c);
                }
                changeScreen();
            }else displayMathError();
            operation = ' ';
        }
        private void sinInverse_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 = Math.Asin(num1) * 180 / Math.PI;
            ScreenBuffer.Clear();
            answer = Math.Round(num1, 12);
            String temp = answer.ToString();
            foreach (char c in temp) {
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        private void cosInverse_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 = Math.Acos(num1) * 180 / Math.PI;
            ScreenBuffer.Clear();
            answer = Math.Round(num1, 12);
            String temp = answer.ToString();
            foreach (char c in temp) {
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        private void tanInverse_Click(object sender, EventArgs e) {
            num1 = Convert.ToDouble(Convert.ToInt32(ContentsInScreen()));
            num1 = Math.Atan(num1) * 180 / Math.PI;
            ScreenBuffer.Clear();
            answer = Math.Round(num1, 12);
            String temp = answer.ToString();
            foreach (char c in temp) {
                ScreenBuffer.Enqueue(c);
            }
            changeScreen();
            operation = ' ';
        }
        //End of Mathematical Functions

        public long factorialOf(int a) {
            if (a == 0 || a == 1) return 1;
            long fact = 1;
            for (int i = 1; i <= a; i++) {
                fact *= i;
            }
            return fact;
        }

        //Mathematical Constants
        private void pi_Click(object sender, EventArgs e) {
            if (ContentsInScreen() != "0") ScreenBuffer.Clear();
            String temp = (Math.PI).ToString();
            foreach (char a in temp) {
                ScreenBuffer.Enqueue(a);
            }
            changeScreen();
        }
        private void euler_Click(object sender, EventArgs e) {
            if (ContentsInScreen() != "0") ScreenBuffer.Clear();
            String temp = (Math.E).ToString();
            foreach (char a in temp) {
                ScreenBuffer.Enqueue(a);
            }
            changeScreen();
        }
        //Mathematical Constants
    }
}
