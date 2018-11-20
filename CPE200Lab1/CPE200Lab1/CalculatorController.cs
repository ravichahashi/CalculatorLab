using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    class CalculatorController : Controller
    {
        public override void ActionPerformed(int action)
        {
            foreach (TwoZeroFourEightModel m in mList)
            {
                switch (action)
                {
                    case LEFT:
                        m.PerformLeft();
                        break;
                    case RIGHT:
                        m.PerformRight();
                        break;
                    case UP:
                        m.PerformUp();
                        break;
                    case DOWN:
                        m.PerformDown();
                        break;
                }

            }
        }
    }
}
