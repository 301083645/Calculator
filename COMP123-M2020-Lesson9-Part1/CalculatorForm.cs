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
        // Public Properties
        public double Operand1{get; set;}
        public double Operand2 { get; set; }

        public string ActiveOperation { get; set; }
        public double Result { get; set; }

        // Constructor(s)
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorButton_Click(object sender, EventArgs e)
        {
            Button calculatorButton = sender as Button;

            if(calculatorButton.Tag.ToString() == "Operand")
            {
                FilterOperandInput(calculatorButton);

            }
            else if(calculatorButton.Tag.ToString() == "Operator")
            {
                ApplyOperator(calculatorButton);
            }
        }

        private void ApplyOperator(Button calculatorButton)
        {
            
            switch (calculatorButton.Name)
            {
                case "ClearButton":
                    ResultLabel.Text = "0";
                    ResultLabel.Font = new Font("Microsoft Sans Serif", 40.0f);
                    Operand1 = 0.0;
                    Operand2 = 0.0;
                    Result = 0.0;
                    ActiveOperation = "None";
                    break;
                case "BackspaceButton":

                    if (ResultLabel.Text != "0")
                    {
                        ResultLabel.Text = ResultLabel.Text.Remove(ResultLabel.Text.Length - 1);
                        if (ResultLabel.Text.Equals(String.Empty))
                        {
                            ResultLabel.Text = "0";
                        }
                    }

                    break;
                case "EqualsButton":
                    ComputeActiveOperation();
                    break;
                default:
                    
                    ActiveOperation = calculatorButton.Name;
                    
                    // if any operator is pressed
                    // some other Operator has been clicked
                    if ((Operand2 != 0.0) || (ActiveOperation == "EqualsButton"))
                    {
                        // compute the operation 
                        ComputeActiveOperation();
                        Debug.WriteLine("computing operation");
                    }
                    else if(Operand1 != 0.0)
                    {
                        Operand2 = Convert.ToDouble(ResultLabel.Text);
                        Debug.WriteLine("Converted Operand2:" + Operand2);
                    }
                    else
                    {
                        Operand1 = Convert.ToDouble(ResultLabel.Text);
                        Debug.WriteLine("Converted Operand1:" + Operand1);

                        ResultLabel.Text = "0";
                    }
                    break;
            }
        }

        private void ComputeActiveOperation()
        {
            Debug.WriteLine("Computing...");
            switch (ActiveOperation)
            {
                case "PlusButton":
                    Result = Operand1 + Operand2;
                    break;
                case "MinusButton":
                    Result = Operand1 - Operand2;
                    break;
                case "MultiplyButton":
                    Result = Operand1 * Operand2;
                    break;
                case "DivideButton":
                    Result = Operand1 / Operand2;
                    break;
                default:
                    // case None
                    Result = Convert.ToDouble(ResultLabel.Text);

                    break;

            }

            ResultLabel.Text = Result.ToString();
        }

        private void FilterOperandInput(Button calculatorButton)
        {
            if (ResultLabel.Text.Length > 7)
            {
                ResultLabel.Font = new Font("Microsoft Sans Serif", 26.0f);
            }
            else
            {
                ResultLabel.Font = new Font("Microsoft Sans Serif", 40.0f);
            }

            if(Operand1 != 0.0)
            {
                ResultLabel.Text = "0";
            }

            if (ResultLabel.Text == "0")
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

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
