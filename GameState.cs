using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netetst
{
    class GameState : State
    {
        public Timer move;
        public bool highscore = false;
        //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"c:\Users\Yisus\Desktop\snake.wav");
        //System.Media.SoundPlayer inc = new System.Media.SoundPlayer(@"c:\Users\Yisus\Desktop\increase.wav");
        public override void init()
        {
            highscore = false;
            GameEnvironment.body_x.Clear();
            GameEnvironment.body_y.Clear();
            GameEnvironment.player.lenght = 5;
            GameEnvironment.end_game = false;
            GameEnvironment.player.facing = 3;
            GameEnvironment.player.x = 39;
            GameEnvironment.player.y = 12;
            GameEnvironment.points = 0;
            if(GameEnvironment.difficulty == 2)
            {
                GameEnvironment.player.lenght = 20;
            }
            if(GameEnvironment.difficulty == 0)
            {
                move = new Timer(5);
            }
            if (GameEnvironment.difficulty == 1)
            {
                move = new Timer(3);
            }
            if (GameEnvironment.difficulty == 2)
            {
                move = new Timer(1);
            }
            for (int i = 0; i < GameEnvironment.player.lenght; i++)
            {
                GameEnvironment.body_x.Add(GameEnvironment.player.x);
                GameEnvironment.body_y.Add(GameEnvironment.player.y);
            }
            replaceDollar();
            //ThreadStart update_thread_ref = new ThreadStart(update);
            //Thread update_thread = new Thread(update_thread_ref);
            //replaceDollar();
            
            
            //player.PlayLooping();
        }
        public override void update() {
            if (!GameEnvironment.end_game)
            {

                //make timer
  
                if (move.eupdate())
                {
                    if (KeyboardHandler.isPressed(KeyCode.Right) && GameEnvironment.player.facing != 2)
                    {
                        GameEnvironment.player.facing = 0;
                    }
                    else if (KeyboardHandler.isPressed(KeyCode.Down) && GameEnvironment.player.facing != 3)
                    {
                        GameEnvironment.player.facing = 1;
                    }
                    else if (KeyboardHandler.isPressed(KeyCode.Left) && GameEnvironment.player.facing != 0)
                    {
                        GameEnvironment.player.facing = 2;
                    }
                    else if (KeyboardHandler.isPressed(KeyCode.Up) && GameEnvironment.player.facing != 1)
                    {
                        GameEnvironment.player.facing = 3;
                    }

                    switch (GameEnvironment.player.facing)
                    {
                        case 0: //right
                            GameEnvironment.player.x = (GameEnvironment.player.x + 1) % 80;
                            break;
                        case 1: //down
                            GameEnvironment.player.y = 2 + ((GameEnvironment.player.y - 1) % 22);
                            break;
                        case 2: //left
                            GameEnvironment.player.x = ((GameEnvironment.player.x - 1)+80) % 80;
                            break;
                        case 3: //up
                            GameEnvironment.player.y = 2 + (((GameEnvironment.player.y - 3)+22) % 22);
                            break;
                    }

                    for (int i = 0; i < GameEnvironment.player.lenght; i++)
                    {
                        if (GameEnvironment.player.x == GameEnvironment.body_x[i] && GameEnvironment.player.y == GameEnvironment.body_y[i])
                        {
                            GameEnvironment.end_game = true;
                            if(GameEnvironment.points > GameEnvironment.hi[GameEnvironment.difficulty])
                            {
                                highscore = true;
                                GameEnvironment.hi[GameEnvironment.difficulty] = GameEnvironment.points;
                                FileManager.save();
                            }
                        }
                    }
                    for (int i = 0; i < GameEnvironment.player.lenght; i++)
                    {
                        if (i == GameEnvironment.player.lenght - 1)
                        {
                            GameEnvironment.body_x[i] = GameEnvironment.player.x;
                            GameEnvironment.body_y[i] = GameEnvironment.player.y;
                        }
                        else
                        {
                            GameEnvironment.body_x[i] = GameEnvironment.body_x[i + 1];
                            GameEnvironment.body_y[i] = GameEnvironment.body_y[i + 1];
                        }
                    }
                }



                if (GameEnvironment.player.x == GameEnvironment.fuit_x && GameEnvironment.player.y == GameEnvironment.fuit_y)
                {
                    replaceDollar();
                    //inc.Play();
                    //player.Play();
                    if (GameEnvironment.difficulty == 3)
                    {
                        if (GameEnvironment.points % 10 == 0)
                        {

                        }
                    }
                    else
                    {
                        GameEnvironment.points++;
                        GameEnvironment.player.lenght++;
                        GameEnvironment.body_x.Add(GameEnvironment.player.x);
                        GameEnvironment.body_y.Add(GameEnvironment.player.y);
                    }
                }
            }
            else if (KeyboardHandler.isPressed(KeyCode.Enter))
            {
                init();
            }
            if (KeyboardHandler.isPressed(KeyCode.Scape))
            {
                GameEnvironment.gotoState(0);
                //terminate = true;
            }
            //render();
            //Thread.Sleep(1000 / GameEnvironment.fps);
        }
        public override void render()
        {
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("<ESC> = Exit");
            if (!GameEnvironment.end_game)
            {
                Console.WriteLine("                    ══ Dollars: " + GameEnvironment.points + " ══");
            }
            else
            {
                Console.WriteLine("                ══ Game Over (total: " + GameEnvironment.points + ") ══");
            }
            Console.WriteLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
            for (int i = 0; i < GameEnvironment.player.lenght - 1; i++)
            {
                Console.SetCursorPosition(GameEnvironment.body_x[i], GameEnvironment.body_y[i]);
                Console.WriteLine("■");
            }

            Console.SetCursorPosition(GameEnvironment.player.x, GameEnvironment.player.y);
            Console.WriteLine("O");

            Console.SetCursorPosition(GameEnvironment.fuit_x, GameEnvironment.fuit_y);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("$");

            if (GameEnvironment.end_game)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (highscore)
                {
                    Console.SetCursorPosition(32, 9);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("<< NEW HIGHSCORE >>");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(27, 11);
                Console.WriteLine("press <ENTER> to fail again");
            }

        }

        public static void replaceDollar()
        {
            GameEnvironment.fuit_x = GameEnvironment.randy.Next(0, 80);
            GameEnvironment.fuit_y = GameEnvironment.randy.Next(3, 24);
            for (int i = 0; i < GameEnvironment.player.lenght; i++)
            {
                if (GameEnvironment.fuit_x == GameEnvironment.body_x[i] && GameEnvironment.fuit_y == GameEnvironment.body_y[i])
                {
                    replaceDollar();
                }
            }
        }
    }
}
