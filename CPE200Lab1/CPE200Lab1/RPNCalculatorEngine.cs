using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        private bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }

        private bool isOperator(string str)
        {
            switch (str)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }

        public string Process(string str)
        {
            string[] part = str.Split(' ');
            if (part.Length < 2) return "E";
            Stack<string> oper = new Stack<string>();
            int i = 0;
            while (i<part.Length)
            {
                if (isNumber(part[i]))
                {
                    oper.Push(part[i]);
                }
                if (isOperator(part[i]))
                {
                    if (i == 0) return "E";
                    string firstOperand;
                    string secondOperand;
                    if (oper.Count >= 2)
                    {
                        secondOperand = oper.Pop();
                        firstOperand = oper.Pop();
                        oper.Push(calculate(part[i], firstOperand, secondOperand, 4));
                    }
                    else return "E";
                }
                i++;
            }
            if (oper.Count > 1) return "E";
            return oper.Pop();
        }
    }
}
