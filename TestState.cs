using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netetst
{
    public class TestState : State
    {
        public override void init() {
            Console.WriteLine("THIS IS TEST STATE");
            Console.ReadKey();
        }

        public override void update()
        {
            base.update();
        }

        public override void render()
        {
            base.render();
        }
    }
}
