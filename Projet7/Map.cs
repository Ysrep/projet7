using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Projet7
{
    public class Map
    {
        char[,] _map;

        public bool Paused { get; set; }

        public char[,] GetMap() { return _map; }

        public void Init()
        {
            int l = 0;
            int col = 0;
            _map = new char[240, 240];

            string[] lines = System.IO.File.ReadAllLines(@"../../../map.txt");

            foreach (string line in lines)
            {
                foreach (char c in line)
                {
                    _map[l, col] = c;
                    col++;
                }
                col = 0;
                l++;
            }
        }
        public void ShowMap(int[] _playerPos)
        {
            int minPosY = Math.Max(0, _playerPos[1] - 15);
            int maxPosY = Math.Min(_map.GetLength(0) - 1, _playerPos[1] + 15);

            int minPosX = Math.Max(0, _playerPos[0] - 60);
            int maxPosX = Math.Min(_map.GetLength(1) - 1, _playerPos[0] + 60);


            Console.SetCursorPosition(0, 0);
            for (int i = minPosY ; i < maxPosY; i++)
            {
                if(i != minPosY)
                {
                    Console.WriteLine();
                }
                for (int j = minPosX; j < maxPosX; j++)
                {
                    switch (_map[i, j])
                    {
                        case '#':
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            break;
                        case '!':
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                            break;
                        case '~':
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Blue;
                            break;
                        case 'w':
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Green;
                            break;
                        case '-':
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Gray;
                            break;
                    }
                    if (i == _playerPos[1] && j == _playerPos[0])
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write('x');
                    }
                    else if (_map[i, j] == 'c')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write('_');
                    } 
                    else if (_map[i, j] == 'C')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(_map[i, j]);
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}