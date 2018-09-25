using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : TheCalculatorEngine
    {
        protected Stack<string> myStack;

        public string calculate(string oper)
        {
            string[] part = oper.Split(' ');
            myStack = new Stack<string>();
            for(int i=0;i<part.Length;i++)
            {
                if (isNumber(part[i]))
                {
                    myStack.Push(part[i]);
                }
                if (isOperator(part[i]))
                {
                    string firstOperand;
                    string secondOperand;
                    try
                    {
                        secondOperand = myStack.Pop();
                        firstOperand = myStack.Pop();
                        
                    }catch(InvalidOperationException ex)
                    {
                        return "E";
                    }
                    myStack.Push(calculate(part[i], firstOperand, secondOperand, 4));
                }
            }
            if (myStack.Count > 1) return "E";
            return myStack.Pop();
        }
    }
}
