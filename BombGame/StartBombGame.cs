using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombGame
{
    class StartBombGame
    {
        static void Main(string[] args)
        {
            
            Console.WindowHeight = 16;
            Console.WindowWidth = 45;
            
            Console.SetBufferSize(45,16);

            //
            bool play = true;
            GameCore game = new GameCore();
            while (play == true)
            {
                game.Draw();
                Console.WriteLine();
                Console.WriteLine("to restart the game type \"restart\"");
                Console.WriteLine("give me something like /A1/: ");

                string reader = Console.ReadLine();



                reader = reader.Trim();
               

                if (reader == "restart")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("REBOOTED");
                        Console.ForegroundColor = ConsoleColor.White;
                        game.LoadGrounds();

                    }
                    else
                    {
                        try
                        {
                            game.ValidateInput(reader);
                        }
                        catch (Exception fee)
                        {
                            if (fee.Message == "Invalid input, try again")
                            {
                                PrintInvalidInput();
                                continue;

                            }
                            else
                            {
                                throw fee;
                            }
                        }
                        try
                        {
                            game.Checker(reader);
                        }
                  
                        catch (Exception fe)
                        {
                            if (fe.Message == "Invalid input, try again")
                            {
                                PrintInvalidInput();
                            }
                            else
                            {
                                throw fe;
                            }

                        }

                    }
                }


            }

        private static void PrintInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input try again");
            Console.ForegroundColor = ConsoleColor.White;
        }
        }
    }

