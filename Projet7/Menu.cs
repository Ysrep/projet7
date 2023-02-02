using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Xml.Linq;

namespace Projet7
{
    public class Menu
    {
        public static List<Option>? options { get; set; }

        public void StartGame(Map _map)
        {
            _map.StartMenu = false;
        }
        public void ShowStartMenu(Map _map)
        {

            int index = 0;

            options = new List<Option>
            {
               new Option("Play", () => StartGame(_map)),
                new Option("Options", () =>  WriteTemporaryMessage("",_map)),
                new Option("Exit", () =>  Environment.Exit(0)),
            };
            WriteStartMenu(options, options[index], _map);
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
                        WriteStartMenu(options, options[index], _map);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteStartMenu(options, options[index], _map);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }

            }
            while (_map.StartMenu);
        }

        static void WriteTemporaryMessage(string message, Map _map)
        {
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3);
            WriteStartMenu(options, options.First(), _map);
        }


        static void WriteStartMenu(List<Option> options, Option selectedOption, Map _map)
        {

            Console.Clear();
            Console.SetCursorPosition(52, 5);
            Console.Write("Pokemon Salty");
            int i = 0;
            Console.SetCursorPosition(56, 10);
            foreach (Option option in options)
            {
                if (i == 5)
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
                i = i + 5;
            }
        }

        public void ShowInventory(Map _map)
        {
            _map.Menu = false;
            _map.Inventory = true;
        }

        public void Save(Map _map)
        {
            _map.Menu = false;
            _map.Save = true;
        }

        public void ExitMenu(Map _map, int[] playerPos)
        {
            _map.Menu = false;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            _map.ShowMap(playerPos);
        }

        public void ShowMenu(Map _map, int[] playerPos)
        {

            int index = 0;

            options = new List<Option>
            {
               new Option("Pokemon", () => Console.Write("")),
                new Option("Inventory", () =>  ShowInventory(_map)),
                new Option("Save", () =>  Save(_map)),
                new Option("ExitMenu", () =>  ExitMenu(_map,playerPos)),
            };
            WriteMenu(options, options[index], _map);
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
                        WriteMenu(options, options[index], _map);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index], _map);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }
            }
            while (_map.Menu);
        }

        static void WriteMenu(List<Option> options, Option selectedOption, Map _map)
        {

            Console.Clear();
            int i = 0;
            Console.SetCursorPosition(54, 5);
            foreach (Option option in options)
            {
                if (i == 5)
                {
                    Console.SetCursorPosition(56, 5 + i);
                }
                else
                {
                    Console.SetCursorPosition(55, 5 + i);
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
                i = i + 5;
            }
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