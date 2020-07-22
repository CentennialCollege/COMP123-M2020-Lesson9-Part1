using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP123_M2020_Lesson9_Part1
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is a shared event handler for all Buttons on the Calculator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            // create a Button object in memory from the sender object
            Button calculatorButton = sender as Button;

            if(calculatorButton.Tag.ToString() == "Operand")
            {
                if(ResultLabel.Text.Length > 7)
                {
                    ResultLabel.Font = new Font("Microsoft Sans Serif", 26.0f);
                }
                else
                {
                    ResultLabel.Font = new Font("Microsoft Sans Serif", 40.0f);
                }

                if(ResultLabel.Text == "0")
                {
                    if (calculatorButton.Text == ".")
                    {
                       ResultLabel.Text += calculatorButton.Text;
                    }
                    else
                    {
                        ResultLabel.Text = calculatorButton.Text;
                    }
                }
                else
                {
                    if (calculatorButton.Text == ".")
                    {
                        if (!ResultLabel.Text.Contains("."))
                        {
                            ResultLabel.Text += calculatorButton.Text;
                        } 
                    }
                    else
                    {
                        ResultLabel.Text += calculatorButton.Text;
                    }
                }
                
            }
            else if(calculatorButton.Tag.ToString() == "Operator")
            {
                switch (calculatorButton.Name)
                {
                    case "ClearButton":
                        ResultLabel.Text = "0";
                        ResultLabel.Font = new Font("Microsoft Sans Serif", 40.0f);
                        break;
                    case "BackspaceButton":

                        if(ResultLabel.Text != "0")
                        {
                            ResultLabel.Text = ResultLabel.Text.Remove(ResultLabel.Text.Length - 1);
                            if(ResultLabel.Text.Equals(String.Empty))
                            {
                                ResultLabel.Text = "0";
                            }
                        }
           
                        break;
                }
            }
        }
    }
}
