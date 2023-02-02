using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projet7
{

    public class Arena
    {
        public static List<Option>? options { get; set; }
        public static List<Option>? options1 { get; set; }
        public bool InventoryOpen { get; set; }
        public Pokemon WildPokemon { get; set; }

        public bool SelectedAttack { get; set; }

        public Arena()
        {
            Random rId = new Random();
            int PokemonId = rId.Next(1, 613);
            Random rlvl = new Random();
            int PokemonLvl = rlvl.Next(2, 5);
            WildPokemon = Pokemon.GetPokemon(PokemonId, PokemonLvl);
        }

        public void OpenInventory(ListConstruct inventory, List<Pokemon> allyPokemon, Map _map)
        {
            AllBag allinventory = new AllBag();
            InventoryOpen = true;
            while (InventoryOpen)
            {
                InventoryOpen = allinventory.ItemListDisp(inventory);
                Console.Clear();
                ArenaFight(inventory, allyPokemon, _map);
            }
        }
        public void UseAttack(ListConstruct inventory,List<Pokemon> allyPokemon, Map _map, int index)
        {
            WildPokemon = allyPokemon.First().useAttack(allyPokemon.First(), WildPokemon, index);
            Console.Clear();
            SelectedAttack = false;
            if(WildPokemon.currentHp <= 0)
            {
                _map.WildBattle = false;
                Console.Clear();
            }
            else
            {
                ArenaFight(inventory, allyPokemon, _map);
            }
            
        }
        public void SelectAttack(ListConstruct inventory, List<Pokemon> allyPokemon, Map _map)
        {
            SelectedAttack = true;
            Console.Clear();
            ArenaFight(inventory, allyPokemon, _map);
        }
        public void ArenaFight(ListConstruct inventory, List<Pokemon> allyPokemon, Map _map)
        {

            StatDisplay stat = new StatDisplay(WildPokemon, allyPokemon);
            stat.StatTab();
            stat.StatTabOpponent();

            int index = 0;

            options1 = new List<Option>
            {
                new Option(allyPokemon.First().attack[0].ename + " " + allyPokemon.First().attack[0].currentPp + " pp", () => UseAttack( inventory,allyPokemon,_map, 0)),
                new Option(allyPokemon.First().attack[1].ename + " " + allyPokemon.First().attack[1].currentPp + " pp", () =>  UseAttack(inventory,allyPokemon,_map, 1)),
                new Option(allyPokemon.First().attack[2].ename + " " + allyPokemon.First().attack[2].currentPp + " pp", () =>  UseAttack(inventory,allyPokemon,_map, 2)),
                new Option(allyPokemon.First().attack[3].ename + " " + allyPokemon.First().attack[3].currentPp + " pp", () => UseAttack(inventory,allyPokemon,_map, 3)),
            };

            options = new List<Option>
            {
                new Option("Attack", () => SelectAttack(inventory,allyPokemon,_map)),
                new Option("Bag", () =>  OpenInventory(inventory,allyPokemon,_map)),
                new Option("Pokemon", () =>  WriteTemporaryMessage("", stat)),
                new Option("Flee", () => _map.WildBattle = false),
            };
            if (SelectedAttack)
            {
                WriteMenu(options1, options1[index], stat);
            }
            else
            {
                WriteMenu(options, options[index], stat);
            }

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

                        if (SelectedAttack)
                        {
                            WriteMenu(options1, options1[index], stat);
                        }
                        else
                        {
                            WriteMenu(options, options[index], stat);
                        }
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        if (SelectedAttack)
                        {
                            WriteMenu(options1, options1[index], stat);
                        }
                        else
                        {
                            WriteMenu(options, options[index], stat);
                        }
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    if (SelectedAttack)
                    {
                        options1[index].Selected.Invoke();
                    }
                    else
                    {
                        options[index].Selected.Invoke();
                    }

                    index = 0;
                }

            }
            while (_map.WildBattle);
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
            Console.SetCursorPosition(0,10);
            foreach (Option option in options)
            {
                Console.SetCursorPosition(0, 10 + i);
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
            Console.WriteLine("NAME : " + _allyPokemon.name["english"]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Level : " + _allyPokemon.level);
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exp : " + _allyPokemon.currentXp);
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
            Console.WriteLine("NAME : " + _wildPokemon.name["english"]);
            Console.SetCursorPosition(90, 6);
            Console.WriteLine("---------------------------");
            Console.SetCursorPosition(90, 7);
            Console.WriteLine("Level : " + _wildPokemon.level);
            Console.SetCursorPosition(90, 8);
            Console.WriteLine("---------------------------");
        }
    }
}

