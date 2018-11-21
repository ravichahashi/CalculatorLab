using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorModel : Model
    {
        private bool hasDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;

        private string firstOperand;
        private string operate;

        protected double _firstOperand;
        protected double _secondOperand;

        public string showResult;
        public double memory;

        public CalculatorModel()
        {
            memory = 0;
            resetAll();
            NotifyAll();
        }

        private void resetAll()
        {
            showResult = "0";
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }

        public void PerformNumber(string digit)
        {
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                showResult = "0";
            }
            if(showResult.Length is 8)
            {
                NotifyAll();
                return;
            }
            isAllowBack = true;
            if (showResult is "0")
            {
                showResult = "";
            }
            showResult += digit;
            isAfterOperater = false;
            NotifyAll();
        }

        public void PerformUnaryOperator(string operate, string operand, int maxOutputSize = 8)
        {
            this.operate = operate;
            this.firstOperand = operand;
            if (isAfterOperater)
            {
                return;
            }

            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            showResult = "E";
                            break;
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        //        return result.ToString();
                        if (parts.Length > 1)
                        {
                            if (parts[1].Length < remainLength) remainLength = parts[1].Length;
                        }
                        else remainLength = 0;
                        showResult = result.ToString("N" + remainLength);
                        break;
                    }
                case "1/x":
                    if (operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            showResult = "E";
                            break;
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        if (parts.Length > 1)
                        {
                            if (parts[1].Length < remainLength) remainLength = parts[1].Length;
                        }
                        else remainLength = 0;
                        // trim the fractional part gracefully. =
                        //         return result.ToString();
                        showResult = result.ToString("N" + remainLength);
                        break;
                    }
                    break;
                default:
                    showResult = "E";
                    break;
            }
            NotifyAll();
        }

        public void PerformOperator(string operate, string operand)
        {
            if (isAfterOperater)
            {
                return;
            }
            if (firstOperand != null)
            {
                string secondOperand = operand;
                calculate(operate, operand);
            }
            this.operate = operate;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    this.firstOperand = operand;
                    isAfterOperater = true;
                    break;
                case "%":
                    // your code here
                    break;
            }
            isAllowBack = false;
            NotifyAll();
        }

        public void PerformEqual()
        {
            string secondOperand = showResult;
            calculate(operate, secondOperand);
            isAfterEqual = true;
            NotifyAll();
        }

        public void PerformDot()
        {
            if (isAfterEqual)
            {
                resetAll();
            }
            if (showResult.Length is 8)
            {
                return;
            }
            if (!hasDot)
            {
                showResult = showResult+".";
                hasDot = true;
            }
            NotifyAll();
        }

        public void PerformSign()
        {
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (showResult.Length is 8)
            {
                NotifyAll();
                return;
            }
            if (showResult[0] is '-')
            {
                showResult = showResult.Substring(1, showResult.Length - 1);
            }
            else
            {
                showResult = "-" + showResult;
            }
            NotifyAll();
        }

        public void PerformClear()
        {
            resetAll();
            NotifyAll();
        }

        public void PerformBack()
        {
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if (showResult != "0")
            {
                string current = showResult;
                char rightMost = current[current.Length - 1];
                if (rightMost is '.')
                {
                    hasDot = false;
                }
                showResult = current.Substring(0, current.Length - 1);
                if (showResult is "" || showResult is "-")
                {
                    showResult = "0";
                }
            }
            NotifyAll();
        }

        public void calculate(string operate, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    showResult = (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                    break;
                case "-":
                    showResult = (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                    break;
                case "X":
                    showResult = (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                    break;
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            showResult = "E";
                            break;
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        if (parts.Length > 1)
                        {
                            if (parts[1].Length < remainLength) remainLength = parts[1].Length;
                        }
                        else remainLength = 0;
                        // trim the fractional part gracefully. =
                        //      return result.ToString();
                        showResult = result.ToString("N" + remainLength);
                        break;
                    }
                    break;
                case "%":
                    //your code here
                    showResult = (Convert.ToDouble(secondOperand) * Convert.ToDouble(firstOperand) / 100).ToString();
                    break;
                default:
                    showResult = "E";
                    break;
            }
        }
    }
}
