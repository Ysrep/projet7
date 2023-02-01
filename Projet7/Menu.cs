using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Projet7
{
    public class Menu
    {
        public static List<Option>? options { get; set; }
        public void ShowStartMenu()
        {

            int index = 0;
            
            options = new List<Option>
            {
               new Option("Play", () => ),
                new Option("Options", () =>  WriteTemporaryMessage("")),
                new Option("Exit", () =>  Environment.Exit(0)),
            };
            WriteMenu(options, options[index]);
            ConsoleKeyInfo menuNavigate;
            do
            {
                menuNavigate = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (menuNavigate.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options.Count)
                    {
                        index++;
                        WriteMenu(options, options[index]);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }

            }
            while (menuNavigate.Key != ConsoleKey.X);
        }

        static void WriteTemporaryMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3);
            WriteMenu(options, options.First());
        }


        static void WriteMenu(List<Option> options, Option selectedOption)
        {

            Console.Clear();
            Console.SetCursorPosition(52, 5);
            Console.Write("Pokemon Salty");
            int i = 0;
            Console.SetCursorPosition(56, 10);
            foreach (Option option in options)
            {
                if(i == 5)
                {
                    Console.SetCursorPosition(55, 10 + i);
                }
                else
                {
                    Console.SetCursorPosition(56, 10 + i);
                }
               
                if (option == selectedOption)
                {
                    Console.Write(">  ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
                i= i+5;
            }
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