using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace netetst
{
    public static class GameEnvironment {
        public static int difficulty = 0;
        public const int fps = 30;
        public static bool end_game = false;
        public static Sanake player = new Sanake();
        public static int points = 0;
        public static int fuit_x = 30;
        public static int fuit_y = 20;
        public static Random randy = new Random();
        public static List<int> body_x = new List<int>();
        public static List<int> body_y = new List<int>();
        public static Stack<State> state_stack = new Stack<State>();
        public static State[] game_states = new State[2];
        public static int state = 0;
        public static bool exit = false;
        public static int[] hi = new int[3];

        public static void gotoState(int i)
        {
            state = i;
            game_states[0] = new MenuState();
            game_states[1] = new GameState();
            game_states[state].init();
        }
    }

    public class Game
    {

        public void stateMachine() {


            //GameEnvironment.state_stack.Peek().init();
            GameEnvironment.game_states[GameEnvironment.state].init();
            
            while (!GameEnvironment.exit){
                /*if (GameEnvironment.state_stack.Peek().isTerminated() && GameEnvironment.state_stack.Count > 1) {
                    Console.Clear();
                    GameEnvironment.state_stack.Pop();
                    //renders = new Thread(new ThreadStart(GameEnvironment.state_stack.Peek().render));
                    GameEnvironment.state_stack.Peek().init();
                }

                GameEnvironment.state_stack.Peek().update();
                GameEnvironment.state_stack.Peek().render();*/

                GameEnvironment.game_states[GameEnvironment.state].update();
                
                GameEnvironment.game_states[GameEnvironment.state].render();
                Thread.Sleep(1000 / GameEnvironment.fps);

            }
        }
    }
}
