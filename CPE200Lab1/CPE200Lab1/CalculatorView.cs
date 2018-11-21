using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class CalculatorView : Form, View
    {
        Model model;
        Controller controller;
        
        public CalculatorView()
        {
            InitializeComponent();
            model = new CalculatorModel();
            model.AttachObserver(this);
            controller = new CalculatorController();
            controller.AddModel(model);
        }

        public void Notify(Model m)
        {
            CalculatorModel cm = (CalculatorModel)m;
            switch (cm.showResult)
            {
                case "E":
                    lblDisplay.Text = "Error";
                    break;
                default:
                    if (cm.showResult.Length > 8)
                    {
                        lblDisplay.Text = "Error";
                        break;
                    }
                    lblDisplay.Text = cm.showResult;
                    break;
            }
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string digit = ((Button)sender).Text;
            controller.ActionPerformed(CalculatorController.NUMBER,"",digit);
        }

        private void btnUnaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string operate = ((Button)sender).Text;
            string firstOperand = lblDisplay.Text;
            controller.ActionPerformed(CalculatorController.UNARY_OPERATOR,operate,firstOperand);
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string operate = ((Button)sender).Text;
            string operand = lblDisplay.Text;
            controller.ActionPerformed(CalculatorController.OPERATOR, operate, operand);
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            controller.ActionPerformed(CalculatorController.EQUAL);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            controller.ActionPerformed(CalculatorController.DOT);
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            controller.ActionPerformed(CalculatorController.SIGN);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(CalculatorController.CLEAR);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            controller.ActionPerformed(CalculatorController.BACK);
        }
        
        private void btnMP_Click(object sender, EventArgs e)
        {
           /* if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;*/
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
           // memory = 0;
        }

        private void btnMM_Click(object sender, EventArgs e)
        {
            /*if(lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;*/
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            /*if(lblDisplay.Text is "error")
            {
                return;
            }
            lblDisplay.Text = memory.ToString();*/
        }
        
    }
}
