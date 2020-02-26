using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int currentState = 1;
        public string mathOperator;
        public double firstNumber;
        public double secondNumber;
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnSelectNumber(object sender, EventArgs e)
        {
            var buttonClicked = (Button)sender;
            var pressed = double.Parse(buttonClicked.Text);
            if(this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if(currentState < 0)
                {
                    currentState *= -1;
                }
                this.resultText.Text += pressed;

               if(currentState == 1)
                {
                    firstNumber = pressed;
                }
                else
                {
                    secondNumber = pressed;
                }
            }
        }
        public void OnSelectOperator(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            currentState = -2;
            string pressed = btn.Text;
            resultText.Text += pressed;
            mathOperator = pressed;
                

        }
        public void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }
        public void OnCalculate(object sender, EventArgs e)
        {
            switch (mathOperator)
            {
                case "+":
                    resultText.Text = (firstNumber + secondNumber).ToString();
                    break;

                case "-":
                    resultText.Text = (firstNumber - secondNumber).ToString();
                    break;

                case "X":
                    resultText.Text = (firstNumber * secondNumber).ToString();
                    break;

                case "/":
                    resultText.Text = (firstNumber / secondNumber).ToString();
                    break;
            }
            currentState = -1;
                
            
        }
    }
}
