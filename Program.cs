using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace netetst
{
    class Program
    {

        static void Main(string[] args)
        {
            var game = new Game();
            //game.start();
            //GameEnvironment.state_stack.Push(new TestState());
            GameEnvironment.state_stack.Push(new GameState());
            GameEnvironment.state_stack.Push(new MenuState());
            GameEnvironment.game_states[0] = new MenuState();
            GameEnvironment.game_states[1] = new GameState();
            //FileManager.save(2, 4, 5);
            FileManager.load();
            game.stateMachine();
            
        }
    }
}
