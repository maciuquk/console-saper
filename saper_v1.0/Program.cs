using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSwepperv1._0
{
    class Program
    {
        public static int minefieldWidth = 10;
        public static int minefieldHeight = 10;
        public static char[,] bombLocated = new char[minefieldWidth, minefieldHeight];  // bomb matrix
        public static int[,] bombLocated2 = new int[minefieldWidth, minefieldHeight]; // numbers matrix
        public static int[,] bombLocated3 = new int[minefieldWidth, minefieldHeight]; // third martix to show
        public static int numbersOfBombs = 5;
        static void Main(string[] args)
        {

            AllocateTheBombs();
            do
            {
                displayTheMinefield();
                playerMove();
                Console.Clear();
            } while (true);


        }

        public static void AllocateTheBombs()
        {
            int x = 0;
            int y = 0;
            Random rnd = new Random();
            for (int i = 0; i < numbersOfBombs; i++)
            {
                x = rnd.Next(0, minefieldWidth);
                y = rnd.Next(0, minefieldHeight);

                bombLocated[x, y] = 'B';
            }
                       
            // second matrix with numbers
            int count = 0;
            for (int x1 = 0; x1 < minefieldWidth; x1++)
            {
                for (int y1 = 0; y1 < minefieldHeight; y1++)
                {
                    // left & right + up & down check
                    if (x1 < minefieldHeight - 1 && bombLocated[x1 + 1,y1] == 'B')
                    {
                        count++;
                    }
                    if (x1 > 0  && bombLocated[x1 - 1, y1] == 'B')
                    {
                        count++;
                    }
                    if (y1 < minefieldWidth - 1 && bombLocated[x1, y1 + 1] == 'B')
                    {
                        count++;
                    }
                    if (y1 > 0 && bombLocated[x1, y1 - 1] == 'B')
                    {
                        count++;
                    }

                    // diagonally check
                    if (( x1 > 0 && y1 < minefieldWidth - 1 && y1 > 0) && (bombLocated[x1 - 1,y1 - 1] == 'B'))
                    {
                        count++;
                    }
                    if ((x1 < minefieldHeight - 1  && y1 < minefieldWidth - 1 ) && (bombLocated[x1 + 1, y1 + 1] == 'B'))
                    {
                        count++;
                    }
                    if ((x1 > 0 && y1 < minefieldWidth - 1 ) && (bombLocated[x1 - 1, y1 + 1] == 'B'))
                    {
                        count++;
                    }
                    if ((x1 < minefieldHeight - 1    && y1 > 0) && (bombLocated[x1 + 1, y1 - 1] == 'B'))
                    {
                        count++;
                    }

                    bombLocated2[x1, y1] = count;
                    count = 0;

                    // put 9 if there is a bomb
                    if (bombLocated[x1, y1] == 'B')
                    {
                        bombLocated2[x1, y1] = 9;
                    }

                    for (int xa = 0; xa < minefieldWidth; xa++)
                    {
                        for (int ya = 0; ya < minefieldHeight; ya++)
                        {
                            bombLocated3[xa, ya] = 11;
                        }
                    }
                }
            }

            // display the 2nd minefield - remove it from the last version
            Console.WriteLine();
            for (int xx1 = 0; xx1 < minefieldWidth; xx1++)
            {
                for (int yy1 = 0; yy1 < minefieldHeight; yy1++)
                {
                    if (bombLocated2[xx1,yy1] == 99)
                    {
                        Console.Write("F");
                    }

                    else

                    Console.Write(bombLocated2[xx1, yy1] + " ");
                }

                Console.WriteLine("|" + xx1);
            }
            Console.WriteLine("___________________");
            Console.WriteLine("0 1 2 3 4 5 6 7 8 9");
        }

        public static void clearTheMinefield()
        {
            for (int xx1 = 0; xx1 < minefieldWidth; xx1++)
            {
                for (int yy1 = 0; yy1 < minefieldHeight; yy1++)
                {
                    bombLocated[xx1, yy1] = ' ';
                }
            }
        }

        public static void displayTheMinefield()
        {
            Console.WriteLine();
            Console.WriteLine("      Gra Saper!");
            Console.WriteLine();
            for (int xx1 = 0; xx1 < minefieldWidth; xx1++)
            {
                for (int yy1 = 0; yy1 < minefieldHeight; yy1++)
                {

                    if (bombLocated3[xx1, yy1] == 99)
                    {
                        Console.Write("F ");
                    }

                    else if (bombLocated3[xx1,yy1] == 0)
                    {
                        Console.Write("- ");
                    }

                    else if (bombLocated3[xx1, yy1] == 11)
                    {
                        Console.Write("  ");
                    }

                    else
                    {
                        Console.Write(bombLocated3[xx1, yy1] + " ");
                    }

                }

                Console.WriteLine("|" + xx1);
            }
            Console.WriteLine("___________________");
            Console.WriteLine("0 1 2 3 4 5 6 7 8 9");
        }

        public static void playerMove()
        {
            Console.WriteLine("Czy chcesz oznaczyć flagę - F lub zaznaczyć pole - P lub wyjście - X?");

           
            var input = Console.ReadLine();
            if (input == "x" || input == "X")
            {
                Environment.Exit(0);
            }

            Console.WriteLine("Podaj pole x:");
            var inputX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj pole y:");
            var inputY = Convert.ToInt32(Console.ReadLine());

            if (input == "P" || input == "p")
            {
                if (bombLocated2[inputY, inputX] != 9)
                { bombLocated3[inputY, inputX] = bombLocated2[inputY, inputX]; }
                else
                {
                    Console.WriteLine("BUUUM!!");
                    Console.ReadKey();
                    Environment.Exit(0);

                }
            }

            else if (input == "f" || input =="F")
            {
                bombLocated3[inputY, inputX] = 99;
            }
 
        }
    }
}
