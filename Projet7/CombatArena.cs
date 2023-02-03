using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projet7
{

    public class Arena
    {
        public static List<Option>? options { get; set; }
        public static List<Option>? options1 { get; set; }

        public static List<Option>? options2 { get; set; }
        public bool InventoryOpen { get; set; }
        public Pokemon WildPokemon { get; set; }

        public bool SelectedAttack { get; set; }

        public Arena(Pokemon pokemon)
        {
            WildPokemon = pokemon;
        }

        public void OpenInventory(ListConstruct inventory, Player player, Map _map)
        {
            AllBag allinventory = new AllBag();
            InventoryOpen = true;
            while (InventoryOpen)
            {
                InventoryOpen = allinventory.ItemListDisp(inventory, player.ListPokemonTeam, WildPokemon, _map);
                Console.Clear();
                if (_map.WildBattle || _map.TrainerBattle || _map.GymBattle)
                    ArenaFight(inventory, player, _map);

            }
            if (!_map.WildBattle || !_map.TrainerBattle || !_map.GymBattle)
            {
                Console.Clear();
                _map.ShowMap(player.PlayerPos);
            }

        }
        public void UseAttack(ListConstruct inventory, Player player, Map _map, int index)
        {
            int pokemonDead = 0;
            if (WildPokemon.Base["Speed"] < player.ListPokemonTeam.First().Base["Speed"])
            {
                WildPokemon = player.ListPokemonTeam.First().useAttack(player.ListPokemonTeam.First(), WildPokemon, index);
                if (WildPokemon.currentHp <= 0)
                {
                    player.ListPokemonTeam.First().WinXp(player.ListPokemonTeam.First(), WildPokemon);
                    _map.WildBattle = false;
                    _map.TrainerBattle = false;
                    _map.GymBattle = false;
                    Console.Clear();
                }
                Random id = new Random();
                int indexAttack = id.Next(0, 3);

                player.ListPokemonTeam.First().useAttack(WildPokemon, player.ListPokemonTeam.First(), indexAttack);

            }
            else
            {
                Random id = new Random();
                int indexAttack = id.Next(0, 3);

                player.ListPokemonTeam.First().useAttack(WildPokemon, player.ListPokemonTeam.First(), indexAttack);
                pokemonDead = 0;
                foreach (var item in player.ListPokemonTeam)
                {
                    if (item.currentHp == 0)
                    {
                        pokemonDead++;
                    }
                }
                if (player.ListPokemonTeam.Count == 1 && player.ListPokemonTeam.First().currentHp <= 0 || pokemonDead == player.ListPokemonTeam.Count)
                {
                    _map.WildBattle = false;
                    _map.TrainerBattle = false;
                    _map.BattleLost = true;
                    _map.GymBattle = false;
                    Console.Clear();
                }
                else if (player.ListPokemonTeam.First().currentHp <= 0 )
                {
                    OpenPokemonMenu(inventory, player, _map );
                }
                else
                {
                    player.ListPokemonTeam.First().useAttack(player.ListPokemonTeam.First(), WildPokemon, index);
                }

            }

            Console.Clear();
            SelectedAttack = false;
            pokemonDead=0;
            foreach (var item in player.ListPokemonTeam)
            {
                if(item.currentHp == 0)
                {
                    pokemonDead++;
                }
            }
            if (WildPokemon.currentHp <= 0)
            {
                if (player.ListPokemonTeam.Count > 1)
                {
                    player.ListPokemonTeam.First().WinXp(player.ListPokemonTeam.First(), WildPokemon);
                }
                else
                {
                    player.ListPokemonTeam.First().WinXp(player.ListPokemonTeam.First(), WildPokemon);
                }
                _map.WildBattle = false;
                _map.TrainerBattle = false;
                _map.GymBattle = false;
                Console.Clear();
            }
            else if (player.ListPokemonTeam.Count == 1 && player.ListPokemonTeam.First().currentHp <= 0 || pokemonDead == player.ListPokemonTeam.Count)
            {
                _map.WildBattle = false;
                _map.TrainerBattle = false;
                _map.BattleLost = true;
                _map.GymBattle = false;
                Console.Clear();
            }
            else if (player.ListPokemonTeam.Count != 1 && player.ListPokemonTeam.First().currentHp <= 0)
            {
                OpenPokemonMenu(inventory, player, _map);
            }
            else
            {
                ArenaFight(inventory, player, _map);
            }

        }

        static void WritePokemonMenu(List<Option> options, Option selectedOption, Map _map)
        {

            Console.Clear();
            int i = 0;
            int j = 0;
            Console.SetCursorPosition(0, 10);
            foreach (Option option in options)
            {
                if (i >= 9)
                {

                    Console.SetCursorPosition(40, 0 + j);
                    j += 3;
                }
                else
                {
                    Console.SetCursorPosition(0, 0 + i);
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
                i = i + 3;
            }
        }

        public void SwitchPokemon(ListConstruct inventory, string name, Map _map, Player player)
        {
            int pokemonToSwitch = 0;

            foreach (var item in options2)
            {
                if (item.Name == name)
                {
                    break;
                }
                pokemonToSwitch++;
            }
            if (player.ListPokemonTeam[pokemonToSwitch] == player.ListPokemonTeam.First() || player.ListPokemonTeam[pokemonToSwitch].currentHp == 0)
            {
                OpenPokemonMenu(inventory, player, _map);
            }
            else
            {
                Pokemon tempPokemonToSwitch = player.ListPokemonTeam[pokemonToSwitch];
                Pokemon tempPokemonSwitched = player.ListPokemonTeam.First();
                player.ListPokemonTeam.RemoveAt(pokemonToSwitch);
                player.ListPokemonTeam.Insert(pokemonToSwitch, tempPokemonSwitched);
                player.ListPokemonTeam.RemoveAt(0);
                player.ListPokemonTeam.Insert(0, tempPokemonToSwitch);
                SelectedAttack = false;
                ArenaFight(inventory, player, _map);
            }


        }

        public void OpenPokemonMenu(ListConstruct inventory, Player player, Map _map)
        {
            Console.Clear();
            options2 = new List<Option> { };
            int index = 0;
            foreach (Pokemon p in player.ListPokemonTeam)
            {
                options2.Add(new Option(p.name["english"] + " Level : " + p.level, () => SwitchPokemon(inventory, p.name["english"] + " Level : " + p.level, _map, player)));
            }
            WritePokemonMenu(options2, options2[index], _map);
            ConsoleKeyInfo menuNavigate;
            do
            {
                menuNavigate = Console.ReadKey();

                // Handle each key input (down arrow will write the menu again with a different selected item)
                if (menuNavigate.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < options2.Count)
                    {
                        index++;
                        WritePokemonMenu(options2, options2[index], _map);
                    }
                }
                if (menuNavigate.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WritePokemonMenu(options2, options2[index], _map);
                    }
                }
                // Handle different action for the option
                if (menuNavigate.Key == ConsoleKey.Enter)
                {
                    options2[index].Selected.Invoke();
                    index = 0;
                }
                if (menuNavigate.Key == ConsoleKey.X)
                {
                    _map.Pokemon = false;
                }

            }
            while (menuNavigate.Key != ConsoleKey.Enter);
        }
        public void SelectAttack(ListConstruct inventory, Player player, Map _map)
        {
            SelectedAttack = true;
            Console.Clear();
            ArenaFight(inventory, player, _map);
        }
        public void ArenaFight(ListConstruct inventory, Player player, Map _map)
        {

            StatDisplay stat = new StatDisplay(WildPokemon, player.ListPokemonTeam);
            stat.StatTab();
            stat.StatTabOpponent();

            int index = 0;

            options1 = new List<Option>
            {
                new Option(player.ListPokemonTeam.First().attack[0].ename + " " + player.ListPokemonTeam.First().attack[0].currentPp + " pp", () => UseAttack( inventory,player,_map, 0)),
                new Option(player.ListPokemonTeam.First().attack[1].ename + " " + player.ListPokemonTeam.First().attack[1].currentPp + " pp", () =>  UseAttack(inventory,player,_map, 1)),
                new Option(player.ListPokemonTeam.First().attack[2].ename + " " + player.ListPokemonTeam.First().attack[2].currentPp + " pp", () =>  UseAttack(inventory,player,_map, 2)),
                new Option(player.ListPokemonTeam.First().attack[3].ename + " " + player.ListPokemonTeam.First().attack[3].currentPp + " pp", () => UseAttack(inventory,player,_map, 3)),
            };

            options = new List<Option>
            {
                new Option("Attack", () => SelectAttack(inventory,player,_map)),
                new Option("Bag", () =>  OpenInventory(inventory,player,_map)),
                new Option("Pokemon", () =>  OpenPokemonMenu(inventory,player,_map)),
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
            while (_map.WildBattle || _map.TrainerBattle || _map.GymBattle);
        }

        static void WriteMenu(List<Option> options, Option selectedOption, StatDisplay stat)
        {

            Console.Clear();
            stat.StatTab();
            stat.StatTabOpponent();
            int i = 0;
            Console.SetCursorPosition(0, 10);
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
            Console.WriteLine("Exp : " + _allyPokemon.currentXp + " / " + _allyPokemon.XpMax);
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

