using System.Drawing;

namespace Projet7
{
    internal class Program
    {

        public int ShortHealth { get; set; }

        //Math.Max(0,_health-amount);
        //Math.Min(_maxHealth,_health+amount);

        static void Main(string[] args)
        {

            char[,] _map;

            void Init()
            {
                _map = new char[240, 240];
                for (int i = 0; i < _map.GetLength(0); i++)
                {
                    for (int j = 0; j < _map.GetLength(1); j++)
                    {
                        if (i <= 1 || i == _map.GetLength(0) - 1 || j == 0 || j == _map.GetLength(1) - 1)
                        {
                            _map[i, j] = '#';
                        }
                        else
                        {
                            _map[i, j] = ' ';
                        }
                    }
                }
            }
            void ShowMap()
            {

                for (int i = 0; i < 30; i++)
                {
                    for (int j = 0; j < 120; j++)
                    {
                        switch (_map[i, j])
                        {
                            case '#':
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 'x':
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Write(_map[i, j]);
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
            }
            Init();
            ShowMap();


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            var pbl = new PokeballList();
            pbl.PokeballListDisp();

        }
    }
}