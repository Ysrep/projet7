using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Projet7
{
    public class Player
    {

        public int[] PlayerPos { get; set; }
        int _money;
        public PokemonTeam _pokemonTeam;
        public void Init()
        {
            PlayerPos = new int[2];
            PlayerPos[0] = 63;
            PlayerPos[1] = 218;
        }

        public void Inputs(Map _map)
        {
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 5; i++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - i] != '~')
                            {
                                continue;
                            }
                            else if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - i] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                                break;
                            }
                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[0] = PlayerPos[0] - (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] != '~')
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] - 1] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                            }
                            else
                            {
                                PlayerPos[0] = PlayerPos[0] - 1;
                            }

                        }
                    }
                    break;


                case ConsoleKey.UpArrow:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 5; i++)
                        {
                            if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '-' && _map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] != '~')
                            {
                                continue;
                            }
                            else if (_map.GetMap()[PlayerPos[1] - i, PlayerPos[0]] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                                break;
                            }
                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[1] = PlayerPos[1] - (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '-' && _map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] != '~')
                        {
                            if (_map.GetMap()[PlayerPos[1] - 1, PlayerPos[0]] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                            }
                            else
                            {
                                PlayerPos[1] = PlayerPos[1] - 1;
                            }

                        }
                    }

                    break;

                case ConsoleKey.RightArrow:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 5; i++)
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + i] != '~')
                            {
                                continue;
                            }
                            else if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + i] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                                break;
                            }
                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[0] = PlayerPos[0] + (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '#' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '/' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '-' && _map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] != '~')
                        {
                            if (_map.GetMap()[PlayerPos[1], PlayerPos[0] + 1] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                            }
                            else
                            {
                                PlayerPos[0] = PlayerPos[0] + 1;
                            }

                        }
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (input.Modifiers == ConsoleModifiers.Shift)
                    {
                        int i;
                        for (i = 0; i <= 5; i++)
                        {
                            if (_map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '-' && _map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] != '~')
                            {
                                continue;
                            }
                            else if (_map.GetMap()[PlayerPos[1] + i, PlayerPos[0]] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                                break;
                            }
                            else
                            {
                                break;
                            }

                        }
                        PlayerPos[1] = PlayerPos[1] + (i - 1);
                    }
                    else
                    {
                        if (_map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '#' && _map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '/' && _map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] != '~')
                        {
                            if (_map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] == '-')
                            {
                                PlayerPos[1] = PlayerPos[1] + 2;
                            }
                            else if (_map.GetMap()[PlayerPos[1] + 1, PlayerPos[0]] == 'c')
                            {
                                Console.WriteLine();
                                Console.WriteLine("Vos pokemons ont été soigné");
                            }
                            else
                            {
                                PlayerPos[1] = PlayerPos[1] + 1;
                            }

                        }
                    }
                    break;
                case ConsoleKey.P:
                    if (!_map.Paused)
                    {
                        _map.Paused = true;
                        Console.Clear();
                    }
                    else
                    {
                        _map.Paused = false;
                        _map.ShowMap(PlayerPos);
                    }
                    break;

                default:
                    break;
            }
            if (_map.GetMap()[PlayerPos[1], PlayerPos[0]] == 'w')
            {
                Random rand = new Random();
                int wildEncounter = rand.Next(5);
                if (wildEncounter == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("A wild pokemon appeared");
                }
            }
            if (!_map.Paused)
            {
                _map.ShowMap(PlayerPos);
            }

        }
    }
}