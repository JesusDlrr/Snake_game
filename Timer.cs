using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netetst
{
    class Timer
    {
        public int t;
        public int elapsed;
        public Timer(int time)
        {
            t = time;
            elapsed = time;
        }

        public bool eupdate() {
            elapsed--;
            if (elapsed <= 0)
            {
                elapsed = t;
                return true;
                
            }
            else
            {
                return false;
            }
        }
    }
}
