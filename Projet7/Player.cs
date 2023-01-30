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
        public void Move(char[,] _map)
        {
            ConsoleKey ArrowKey = Console.ReadKey().Key;
            switch (ArrowKey)
            {
                case ConsoleKey.LeftArrow:
                    if (_map[PlayerPos[1], PlayerPos[0]-1] != '#' && _map[PlayerPos[1], PlayerPos[0] - 1] != '/' && _map[PlayerPos[1], PlayerPos[0] - 1] != '-' && _map[PlayerPos[1], PlayerPos[0] - 1] != '~')
                    {
                        PlayerPos[0] = PlayerPos[0] - 1;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (_map[PlayerPos[1]+1, PlayerPos[0]] != '#' && _map[PlayerPos[1]+1, PlayerPos[0]] != '/' && _map[PlayerPos[1]+1, PlayerPos[0]] != '-' && _map[PlayerPos[1] + 1, PlayerPos[0]] != '~')
                    {
                        PlayerPos[1] = PlayerPos[1] + 1;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (_map[PlayerPos[1], PlayerPos[0] + 1] != '#' && _map[PlayerPos[1], PlayerPos[0] + 1] != '/' && _map[PlayerPos[1], PlayerPos[0] + 1] != '-' && _map[PlayerPos[1], PlayerPos[0] + 1] != '~')
                    {
                        PlayerPos[0] = PlayerPos[0] + 1;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (_map[PlayerPos[1] - 1, PlayerPos[0]] != '#' && _map[PlayerPos[1] - 1, PlayerPos[0]] != '/' && _map[PlayerPos[1] - 1, PlayerPos[0]] != '~')
                    {
                        if (_map[PlayerPos[1] - 1, PlayerPos[0]] != '-')
                        {
                            PlayerPos[1] = PlayerPos[1] - 2;
                        }
                        PlayerPos[1] = PlayerPos[1] - 1;
                    }
                    break;

                default:
                    break;
            }
            if (_map[PlayerPos[1], PlayerPos[0]] == 'w')
            {
                Random rand = new Random();
                int wildEncounter = rand.Next(5);
                if (wildEncounter == 1)
                {
                    Console.WriteLine("A wild pokemon appeared");
                }
            }

        }

    }
}