using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projet7
{

    public class Arena
    {
        public static List<Option>? options { get; set; }

        public Pokemon WildPokemon { get; set; }

        public Arena()
        {
            Random rId = new Random();
            int PokemonId = rId.Next(1, 613);
            Random rlvl = new Random();
            int PokemonLvl = rlvl.Next(2, 5);
            WildPokemon = Pokemon.GetPokemon(PokemonId, PokemonLvl);
        }
        public void ArenaFight(ListConstruct inventory, List<Pokemon> allyPokemon)
        {

            StatDisplay stat = new StatDisplay(WildPokemon, allyPokemon);
            stat.StatTab();
            stat.StatTabOpponent();

            int index = 0;
            bool inventoryOpen = false;
            AllBag allinventory = new AllBag();
            options = new List<Option>
            {
                new Option("Attack", () => WriteTemporaryMessage("", stat)),
                new Option("Bag", () =>  inventoryOpen = true),
                new Option("Pokemon", () =>  WriteTemporaryMessage("", stat)),
                new Option("Flee", () => Environment.Exit(0)),
            };

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
                        WriteMenu(options, options[index], stat);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index], stat);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    options[index].Selected.Invoke();
                    index = 0;
                }

                break;

            }
            while (menuNavigate.Key != ConsoleKey.X);
            while (inventoryOpen)
            {
                inventoryOpen = allinventory.ItemListDisp(inventory);
                Console.Clear();
            }
            Console.ReadKey();
        }



        // Default action of all the options. You can create more methods
        static void WriteTemporaryMessage(string message, StatDisplay stat)
        {
            stat.StatTab();
            stat.StatTabOpponent();
            Console.Clear();
            Console.WriteLine(message);
            Thread.Sleep(3);
            WriteMenu(options, options.First(), stat);
        }


        static void WriteMenu(List<Option> options, Option selectedOption, StatDisplay stat)
        {

            Console.Clear();
            stat.StatTab();
            stat.StatTabOpponent();
            int i = 0;
            Console.SetCursorPosition(0, 9);
            foreach (Option option in options)
            {
                Console.SetCursorPosition(0, 9 + i);
                if (option == selectedOption)
                {
                    Console.Write(">  ");
                }
                else
                {
                    Console.Write(" ");
                }

                Console.WriteLine(option.Name);
                i++;
            }
        }
    }
    public class Option
    {
        public string Name { get; set; }
        public Action Selected { get; }

        public Option(string name, Action selected)
        {
            Name = name;
            Selected = selected;
        }
    }

    public class StatDisplay
    {
        Pokemon _wildPokemon;
        Pokemon _allyPokemon;
        public StatDisplay(Pokemon WildPokemon, List<Pokemon> allyPokemon)
        {
            _wildPokemon = WildPokemon;
            _allyPokemon = allyPokemon.First();
        }
        public void StatTab()
        {
            Console.WriteLine();
            Console.WriteLine("--------- MY TEAM ---------");
            Console.WriteLine("---------------------------");
            Console.WriteLine("HP : " + _allyPokemon.currentHp + "  / " + _allyPokemon.Base["HP"]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("NAME : " + _allyPokemon.name["french"]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Level : " + _allyPokemon.level);
            Console.WriteLine("---------------------------");
        }

        public void StatTabOpponent()
        {

            Console.SetCursorPosition(90, 1);
            Console.WriteLine("----- OPPONENT'S TEAM -----");
            Console.SetCursorPosition(90, 2);
            Console.WriteLine("---------------------------");
            Console.SetCursorPosition(90, 3);
            Console.WriteLine("HP : " + _wildPokemon.currentHp + " / " + _wildPokemon.Base["HP"]);
            Console.SetCursorPosition(90, 4);
            Console.WriteLine("---------------------------");
            Console.SetCursorPosition(90, 5);
            Console.WriteLine("NAME : " + _wildPokemon.name["french"]);
            Console.SetCursorPosition(90, 6);
            Console.WriteLine("---------------------------");
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("Level : " + _wildPokemon.level);
            Console.SetCursorPosition(90, 8);
            Console.WriteLine("---------------------------");
        }
    }
}

