using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netetst
{
    public class State
    {
        public bool terminate = false;
        virtual public void init() {
            Console.WriteLine("Base state");
            Console.ReadKey();
        }
        virtual public void update() {

        }
        virtual public void render() {

        }
        public bool isTerminated() {
            return terminate;
        }
    }
}
