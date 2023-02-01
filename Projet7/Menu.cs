using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Menu
    {
        public void ShowStartMenu()
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

        public bool StartMenuSelection()
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
        public void ShowMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(52, 5);
            Console.Write("Pokemon");
            Console.SetCursorPosition(56, 10);
            Console.Write("Inventory");
            Console.SetCursorPosition(55, 15);
            Console.Write("Save");
        }
        public int MenuSelection()
        {
            int index = 0;
            ConsoleKey input = Console.ReadKey(true).Key;
            switch (input)
            {
                //case ConsoleKey.UpArrow:
                //    index--;
                //    if (index < 1)
                //        index = 3;
                //    break;
                //case ConsoleKey.DownArrow:
                //    index--;
                //    if (index > 3)
                //        index = 1;
                //    break;

                //case ConsoleKey.Enter:
                //    switch (index)
                //    {
                //        case 1:
                //            return 1;
                //        case 2:
                //            break;
                //        case 3:
                //            Console.Clear();
                //            Environment.Exit(0);
                //            break;
                //        default:
                //            break;
                //    }
                //    break;
                case ConsoleKey.Escape:
                    return 0;
                case ConsoleKey.NumPad1:
                    return 1;
                case ConsoleKey.NumPad2:
                    return 2;
                case ConsoleKey.NumPad3:
                    return 3;
                default:
                    break;
            }
            return -1;
        }

    }
}