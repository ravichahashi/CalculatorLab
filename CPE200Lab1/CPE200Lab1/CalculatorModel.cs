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
        private double memory;

        protected double _firstOperand;
        protected double _secondOperand;

        public bool reset;

        public CalculatorModel()
        {
            memory = 0;
            resetAll();
        }

        private void resetAll()
        {
            reset = true;
            isAllowBack = true;
            hasDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            firstOperand = null;
        }
    }
}
