using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace netetst
{
    public class MenuState : State
    {
        static int option = 0;

        static int height = 23;
        static int width = 78;
        public static char[][] frame = new char[height][];

        Dictionary<String, String> options = new Dictionary<String, String>();
        static string[] descriptions = new string[4];
        static bool hold = false;
        public override void init() {

            Console.buffe
            Console.CursorVisible = false;

            FileManager.load();


            for(int i = 0; i < frame.Length; i++)
            {
                frame[i] = new char[width];
            }


            options.Add("Easy mode    <HI: " + GameEnvironment.hi[0] + ">\n", "   (Also known as baby mode) very slow snake and money\n\n   everywhere! ooh boy... Ideal for noobs.");
            options.Add("Normal mode  <HI: " + GameEnvironment.hi[1] + ">\n", "   This difficulty is... OK, I guess. I won't say you\n\n   are a baby.");
            options.Add("Hard mode    <HI: " + GameEnvironment.hi[2] + ">\n", "   WOW! take it sssssslow man, this is hard mode so...\n\n   Super fast snake and some other stff will make you\n\n   cry your ass off. Also stars with a lenght of 40.");
            options.Add("Exit mode", "   Gonna Cry? Gonna Piss Your Pants Maybe?\n\n   Maybe shit and cum?");

            descriptions[0] = "   (Also known as baby mode) very slow snake and money\n\n   everywhere! ooh boy... ideal for noobs.";
            descriptions[1] = "   This difficulty is... OK, I guess. I won't say you\n\n   are a baby... but you are still a noob.";
            descriptions[2] = "   WOW! take it sssssslow man, this is hard mode so...\n\n   Super fast snake and some other stff will make you\n\n   cry your ass off. Also stars with a lenght of 20.";
            descriptions[3] = "   Gonna Cry? Gonna Piss Your Pants Maybe?\n\n   Maybe shit and cum?";
            //Console.WriteLine("THIS IS MENU STATE");
        }

        static void draw(int x, int y, char obj)
        {
            frame[x][y] = obj;
        }

        public override void update() {



            for (int i = 0; i < frame.Length; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    frame[i][j] = ' ';
                }
            }



            if (KeyboardHandler.isPressed(KeyCode.Up) && !hold)
            {
                option = ((option - 1) + 4) % 4;
                hold = true;
            }
            if(KeyboardHandler.isPressed(KeyCode.Down) && !hold)
            {
                option = (option + 1) % 4;
                hold = true;
            }
            if (KeyboardHandler.isPressed(KeyCode.Enter)) {
                if (option == 3)
                {
                    GameEnvironment.exit = true;
                }
                else
                {
                    GameEnvironment.difficulty = option;
                    GameEnvironment.state_stack.Push(new MenuState());
                    GameEnvironment.gotoState(1);
                }

            }
            if(!KeyboardHandler.isPressed(KeyCode.Up) && !KeyboardHandler.isPressed(KeyCode.Down))
            {
                hold = false;
            }
            //KeyboardHandler.pressed = false;
            draw(2, 4, 'd');
            draw(2, 24, 'S');
            draw(2, 26, 'S');
            draw(22, 22, 'S');
            draw(17, 24, 'S');
            draw(15, 24, 'S');

        }

        public override void render() {
            Console.Clear();
            for(int i = 0; i < height; i++)
            {
                Console.WriteLine(frame[i]);
            }
            /*for(int i = 0; i < options.Count; i++)
            {
                Console.WriteLine(options.ElementAt(i).Key);
            }
            //Console.Write(KeyboardHandler.pressed);
            Console.WriteLine("                             ══ CHOOSE YOUR FATE ══\n\n");
            if (option == 0) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("   Easy mode     <HI: " + GameEnvironment.hi[0] + ">\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (option == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("   Normal mode   <HI: " + GameEnvironment.hi[1] + ">\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (option == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("   Hard mode     <HI: " + GameEnvironment.hi[2] + ">\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (option == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("   Exit mode\n");
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(descriptions[option]);
            //Thread.Sleep(1000 / GameEnvironment.fps);*/
        }
    }
}
