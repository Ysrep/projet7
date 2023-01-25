using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Pokeball : IEquatable<Pokeball>
    {
        public string? pokeballName { get; set; }
        public int? pokeballTotal { get; set; }
        public int pokeballId { get; set; }

        public bool Equals(Pokeball? other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "ID: " + pokeballId + "   Name: " + pokeballName + "  Total: " + pokeballTotal;
        }
    }

    public class PokeballList
    {
        public Random random = new Random();
        int isRandomed;
        public int _pokeBall = 20;
        public int _superBall = 15;
        public int _hyperBall = 10;
        public int _masterBall = 0;
        public int _pokeballId = 0;
        public bool isAbleToCatch = false;

        public void PokeballListDisp()
        {

            List<Pokeball> PokeballListing = new List<Pokeball>()
            {
                new Pokeball() { pokeballName = "Pokeball", pokeballId = 1, pokeballTotal = _pokeBall },
                new Pokeball() { pokeballName = "Super Ball", pokeballId = 2, pokeballTotal = _superBall },
                new Pokeball() { pokeballName = "Hyper Ball", pokeballId = 3, pokeballTotal = _hyperBall },
                new Pokeball() { pokeballName = "Master Ball", pokeballId = 4, pokeballTotal = _masterBall },
            };

            foreach (Pokeball aPokeball in PokeballListing)
            {
                Console.WriteLine("Remaining Pokeballs:  " + aPokeball);
            }

            askPlayerAgain :
            Console.WriteLine("Which Pokeball ID will you choose ?");
            ConsoleKey playerInputPokeballs;
            playerInputPokeballs = Console.ReadKey().Key;

            switch (playerInputPokeballs)
            {
                case ConsoleKey.NumPad1:
                    if (_pokeBall == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There is 0 Poke Ball in your inventory !");
                        goto askPlayerAgain;
                    }
                    else
                    {
                        _pokeBall--;
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("You selected : Poke balls");
                        Console.WriteLine("Remaining Poke balls:  " + _pokeBall);
                        isAbleToCatch = true;
                        isRandomed = random.Next(100);

                    }

                    if (isAbleToCatch == true && isRandomed < 40)
                    {
                        Console.WriteLine("You catched the pokemon !");
                        isAbleToCatch = false;

                    }
                    else
                    {
                        Console.WriteLine("The pokemon escaped the pokeball !");
                        isAbleToCatch = false;
                        goto askPlayerAgain;
                    }
                    break;

                case ConsoleKey.NumPad2:
                    if (_superBall == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There is 0 Super Ball in your inventory !");
                        goto askPlayerAgain;
                    }
                    else
                    {
                        _superBall--;
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("You selected : Super balls");
                        Console.WriteLine("Remaining Super balls:  " + _superBall);
                        isAbleToCatch = true;
                        isRandomed = random.Next(100);
                    }

                    if (isAbleToCatch == true && isRandomed < 60)
                    {
                        Console.WriteLine("You catched the pokemon !");
                        isAbleToCatch = false;

                    }
                    else
                    {
                        Console.WriteLine("The pokemon escaped the pokeball !");
                        isAbleToCatch = false;
                        goto askPlayerAgain;

                    }
                    break;

                case ConsoleKey.NumPad3:
                    if (_hyperBall == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There is 0 Hyper Ball in your inventory !");
                        goto askPlayerAgain;
                    }
                    else
                    {
                        _hyperBall--;
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("You selected : Hyper balls");
                        Console.WriteLine("Remaining Hyper balls:  " + _hyperBall);
                        isAbleToCatch = true;
                        isRandomed = random.Next(100);
                    }

                    if (isAbleToCatch == true && isRandomed < 80)
                    {
                        Console.WriteLine("You catched the pokemon !");
                        isAbleToCatch = false;

                    }
                    else
                    {
                        Console.WriteLine("The pokemon escaped the pokeball !");
                        isAbleToCatch = false;
                        goto askPlayerAgain;

                    }

                    break;

                case ConsoleKey.NumPad4:

                    if(_masterBall == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("There is 0 Master Ball in your inventory !");
                        goto askPlayerAgain;
                    }
                    else
                    {
                        _masterBall--;
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("You selected : Master balls");
                        Console.WriteLine("Remaining Master balls:  " + _masterBall);
                        isAbleToCatch = true;
                        isRandomed = random.Next(100);
                    }

                    if (isAbleToCatch == true && isRandomed < 101)
                    {
                        Console.WriteLine("You catched the pokemon !");
                        isAbleToCatch = false;
                    }

                    else
                    {
                        Console.WriteLine("The pokemon escaped the pokeball !");
                        isAbleToCatch = false;
                        goto askPlayerAgain;
                    }

                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("You can't do that");
                    goto askPlayerAgain;
            }
        }
    }
}