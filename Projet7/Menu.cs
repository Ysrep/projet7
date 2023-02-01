using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Menu
    {
        public void ShowMenu()
        {
            Console.SetCursorPosition(52, 5);
            Console.Write("Pokemon Salty");
            Console.SetCursorPosition(56, 10);
            Console.Write("Play");
            Console.SetCursorPosition(55, 15);
            Console.Write("Options");
            Console.SetCursorPosition(56, 20);
            Console.Write("Exit");
        }

        public bool Selection()
        {
            int index = 0;
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 1)
                        index = 3;
                    break;
                case ConsoleKey.DownArrow:
                    index--;
                    if (index > 3)
                        index = 1;
                    break;

                case ConsoleKey.Enter:
                    switch (index)
                    {
                        case 1:
                            return false;
                        case 2:
                            break;
                        case 3:
                            Console.Clear();
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                    break;
                case ConsoleKey.NumPad1:
                    return false;
                case ConsoleKey.NumPad2:

                    break;
                case ConsoleKey.NumPad3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            return true;
        }

    }
}