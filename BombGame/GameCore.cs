using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombGame
{
    class GameCore
    {
        // the field size + 1 for numbers and letters for the rows and cols
        static int fieldSize = 11;
        int counter = 0;
        string[,] readlGround = new string[fieldSize, fieldSize];
        string[,] fakelGround = new string[fieldSize, fieldSize];
        // the fake ground will be displayed
        public GameCore()
        {
            LoadGrounds();
        }
        public void LoadGrounds()
        {
            counter = 0;
            // we initialize the field with numbers and letter for the rows and cows
            for (int i = 0; i < fieldSize - 1; i++)
            {
                readlGround[0, i + 1] = (i + 1).ToString();
                fakelGround[0, i + 1] = (i + 1).ToString();
            }
            for (int i = 0; i < fieldSize - 1; i++)
            {
                readlGround[i + 1, 0] = ((char)(65 + i)).ToString();
                fakelGround[i + 1, 0] = ((char)(65 + i)).ToString();
            }
            // we initialize the rest
            Random random = new Random();
            for (int i = 1; i < fieldSize; i++)
            {
                for (int j = 1; j < fieldSize; j++)
                {
                    fakelGround[i, j] = "-";
                    if (random.Next(fieldSize / 2) == 3)
                    {
                        readlGround[i, j] = "*";
                    }
                    else
                    {
                        readlGround[i, j] = "-";
                    }
                }

            }
        }
            public void Draw ()
            {
               bool once = false;
                for (int i = 0; i < fieldSize; i++)
			    {
                    Console.WriteLine();
			        for (int j = 0; j < fieldSize; j++)
			          {
                          if (fakelGround[i, j] == "*")
                          {
                              Console.ForegroundColor = ConsoleColor.Red;
                              Console.Write(" "+fakelGround[i, j]);
                              Console.ForegroundColor = ConsoleColor.White;
                          }
                         else if (fakelGround[i, j] == "#")
                          {
                                  Console.ForegroundColor = ConsoleColor.DarkBlue;
                                  Console.Write(" {0}", fakelGround[i, j]);
                                  Console.ForegroundColor = ConsoleColor.White;
                          }
                          else
                          {
                              if (i == 0 && once == false)
                              {
                                  Console.Write("  ");
                                  once = true;
                              }
                              else
                              {
                                  
                                  Console.Write(" {0}", fakelGround[i, j]);
                              }
                             
                          }

                          if (j ==10 && i ==2)
                          {
                              Console.Write("     counter: {0}",counter);
                          }
		        	  }
                    
			    }
              
            }
        // here we will create the checker and the readers 
            public string Checker(string str)
            {
                if (readlGround[GetAlphabeticNumber(str),GetNumber(str)] == "*")
                {
                    fakelGround[GetAlphabeticNumber(str), GetNumber(str)] = "*";
                    counter++;
                    return "";
                }
                else
                {
                    fakelGround[GetAlphabeticNumber(str), GetNumber(str)] = "#";
                    return "Try Again";
                }
            }
         private int GetAlphabeticNumber(string str)
                {
             // using ascii dec here to read the letter and convert it 
                    char readed = str[0];
                   char[] reader = (readed.ToString().ToUpper()).ToCharArray();
              if (reader[0]-64 >fieldSize -1 )
             {
                 Exception except = new Exception("Invalid input, try again");
                 throw  except;
             }
                    return reader[0] - 64;
                }
         private int GetNumber(string str)
         {
             if (str.Length==3)
             {
                 StringBuilder strr = new StringBuilder();
                 strr.Append(str[1]);
                 strr.Append(str[2]);

                 string readed =strr.ToString();
                 // in positions 0 are writed the playground coordinates we do not wanna to play with them
                 if (readed == "00")
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 try
                 {
                     int.Parse(readed.ToString());
                 }
                 catch (ArgumentNullException)
                 {
                      Exception except = new Exception("Invalid input, try again");
                 throw  except;
                    
                 }
                 catch(FormatException)
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 catch (OverflowException)
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 if ((int.Parse(readed.ToString())> fieldSize -1))
                 {
                       Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
             return int.Parse(readed.ToString());
             }
             else
             {

                 char readed = str[1];
                 if (readed == '0')
                     // in positions 0 are writed the playground coordinates we do not wanna to play with them
                 {
                      Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 try
                 {
                     int.Parse(readed.ToString());
                 }
                 catch (ArgumentNullException)
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;

                 }
                 catch (FormatException)
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 catch (OverflowException)
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 if ((int.Parse(readed.ToString()) > fieldSize - 1))
                 {
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 }
                 return int.Parse(readed.ToString());
             }
             
         }


        public void ValidateInput(string str)
         {
             if (str.Length > 3 || str.Length <= 1)
             {
                 Exception except = new Exception("Invalid input, try again");
                 throw  except;
             }
            // using ascii dec to check for valid alphabet input
             if ((str[0] < 65 || str[0] > 90) && (str[0] < 97 || str[0] > 122))
             {
               
                     Exception except = new Exception("Invalid input, try again");
                     throw except;
                 
             }
         }
            
        }
    }
