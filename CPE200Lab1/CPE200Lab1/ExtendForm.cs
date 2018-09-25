﻿using System;
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
    public partial class ExtendForm : Form
    {
        private bool isNumberPart = false;
        private bool isContainDot = false;
        private bool isSpaceAllowed = false;
        private CalculatorEngine engine;
        private RPNCalculatorEngine rpnEngine;
        private string memoData;

        public ExtendForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            rpnEngine = new RPNCalculatorEngine();
        }

        private bool isOperator(char ch)
        {
            switch(ch) {
                case '+':
                case '-':
                case 'X':
                case '÷':
                    return true;
            }
            return false;
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            if (!isNumberPart)
            {
                isNumberPart = true;
                isContainDot = false;
            }
            lblDisplay.Text += ((Button)sender).Text;
            isSpaceAllowed = true;
        }

        private void btnBinaryOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            isNumberPart = false;
            isContainDot = false;
            string current = lblDisplay.Text;
            if (current[current.Length - 1] != ' ' || isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text += " " + ((Button)sender).Text + " ";
                isSpaceAllowed = false;
            }
        }

        private void btnUnary_Click(object sender, EventArgs e)
        {
            string[] parts = lblDisplay.Text.Split(' ');
            switch (((Button)sender).Text)
            {
                case "1/x":
                case "√":
                    parts[parts.Length - 1] = engine.calculate(((Button)sender).Text, parts[parts.Length - 1]);
                    break;
                case "%":
                    if (parts.Length == 2)
                    {
                        parts[1] = engine.calculate(((Button)sender).Text, parts[0], parts[1]);
                    } else
                    {
                        lblDisplay.Text = "Error";
                        return ;
                    }
                    break;
            }
            lblDisplay.Text = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                lblDisplay.Text += " " + parts[i];
            }
            
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            string[] parts = lblDisplay.Text.Split(' ');
            parts[parts.Length - 1] = engine.calculate(((Button)sender).Text, parts[parts.Length - 1]);
            lblDisplay.Text = parts[0];
            for (int i = 1; i < parts.Length; i++)
            {
                lblDisplay.Text += " " + parts[i];
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            // check if the last one is operator
            string current = lblDisplay.Text;
            if (current[current.Length - 1] is ' ' && current.Length > 2 && isOperator(current[current.Length - 2]))
            {
                lblDisplay.Text = current.Substring(0, current.Length - 3);
            } else
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
            }
            if (lblDisplay.Text is "")
            {
                lblDisplay.Text = "0";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private void btnClearEmpty_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            isContainDot = false;
            isNumberPart = false;
            isSpaceAllowed = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            string result = rpnEngine.calculate(lblDisplay.Text);
            if (result is "E")
            {
                lblDisplay.Text = "Error";
            } else
            {
                lblDisplay.Text = result;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isNumberPart)
            {
                return;
            }
            string current = lblDisplay.Text;
            if (current is "0")
            {
                lblDisplay.Text = "-";
            } else if (current[current.Length - 1] is '-')
            {
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if (lblDisplay.Text is "")
                {
                    lblDisplay.Text = "0";
                }
            } else
            {
                lblDisplay.Text = current + "-";
            }
            isSpaceAllowed = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if(!isContainDot)
            {
                isContainDot = true;
                lblDisplay.Text += ".";
                isSpaceAllowed = false;
            }
        }

        private void btnSpace_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text is "Error")
            {
                return;
            }
            if(isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
        }
        /*
        private void btnMemoeyFunc(object sender, EventArgs e)
        {
            string[] parts = lblDisplay.Text.Split(' ');
            if (parts.Length == 1 && engine.isNumber(parts[0]))
            {
                memoData = lblDisplay.Text;
            }
            else lblDisplay.Text = "Error";
            switch (((Button)sender).Text)
            {
                case "MC":
                    memoData = "0";
                    break;
                case "MR":
                    lblDisplay.Text += memoData;
                    break;
                case "MS":
                case "M+":
                case "M-":
                    string[] parts = lblDisplay.Text.Split(' ');
                    if (parts.Length == 1 && engine.isNumber(parts[0]))
                    {
                        memoData = lblDisplay.Text;
                    }
                    else lblDisplay.Text = "Error";
            }
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isSpaceAllowed)
            {
                lblDisplay.Text += " ";
                isSpaceAllowed = false;
            }
        }*/
    }
}
