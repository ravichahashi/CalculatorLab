using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorController : Controller
    {
        public const int NUMBER = 0;
        public const int UNARY_OPERATOR = 1;
        public const int OPERATOR = 2;
        public const int EQUAL = 3;
        public const int DOT = 4;
        public const int SIGN = 5;
        public const int CLEAR = 6;
        public const int BACK = 7;

        public CalculatorController()
        {

        }

        public override void ActionPerformed(int action, string operate="", string firstOperand="", string secondOperand="")
        {
            foreach (CalculatorModel m in mList)
            {
                switch (action)
                {
                    case NUMBER:
                        m.PerformNumber(firstOperand);
                        break;
                    case UNARY_OPERATOR:
                        m.PerformUnaryOperator(operate,firstOperand);
                        break;
                    case OPERATOR:
                        m.PerformOperator(operate,firstOperand);
                        break;
                    case EQUAL:
                        m.PerformEqual();
                        break;
                    case DOT:
                        m.PerformDot();
                        break;
                    case SIGN:
                        m.PerformSign();
                        break;
                    case CLEAR:
                        m.PerformClear();
                        break;
                    case BACK:
                        m.PerformBack();
                        break;

                }

            }
        }
    }
}
