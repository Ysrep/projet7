using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Potion
    {
        public string? potionName { get; set; }
        public int? potionTotal { get; set; }
        public int potionId { get; set; }

        public bool Equals(Potion? other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "ID: " + potionId + "   Name: " + potionName + "  Total: " + potionTotal;
        }
    }

    public class PotionList
    {
        public int _potion = 15;
        public int _superPotion = 10;
        public int _hyperPotion = 5;

        public void PotionListDisp()
        {
            List<Potion> PotionListing = new List<Potion>()
            {
                new Potion() { potionName = "Potion", potionId = 1, potionTotal = _potion },
                new Potion() { potionName = "Super Potion", potionId = 2, potionTotal = _superPotion },
                new Potion() { potionName = "Hyper Potion", potionId = 3, potionTotal = _hyperPotion },
            };

            foreach (Potion aPotion in PotionListing)
            {
                Console.WriteLine("Remaining Potions:  " + aPotion);
            }

            AskPlayerAgain:
            Console.WriteLine();
            Console.WriteLine("Which Potion ID will you choose ?");
            ConsoleKey playerInputPotions;
            playerInputPotions = Console.ReadKey().Key;
            Console.WriteLine();
            ConsoleKey playerSelectYorN;

            switch (playerInputPotions)
            {
                case ConsoleKey.NumPad1:
                    _potion--;
                    Console.WriteLine("Total potion = " + _potion);    

                    if (_potion == 0 || _potion < 0)
                    {
                        Console.WriteLine("You have no more potion");
                        goto AskPlayerAgain;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You healed your pokemon for 200HP !");
                        UseAnotherPot1:
                        Console.WriteLine("Use another potion Y or N?");

                        playerSelectYorN = Console.ReadKey().Key;
                        if (playerSelectYorN == ConsoleKey.Y)
                        {
                            Console.Clear();
                            goto AskPlayerAgain;
                        }
                        else if (playerSelectYorN == ConsoleKey.N)
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Console.WriteLine("Dang bro poor pokemon");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Console.WriteLine("You can't do that");
                            goto UseAnotherPot1;
                        }
                        goto AskPlayerAgain;
                    }

                case ConsoleKey.NumPad2:

                    _superPotion--;
                    Console.WriteLine("Total Super potion = " + _superPotion);

                    if (_superPotion == 0 || _superPotion < 0)
                    {
                        Console.WriteLine("You have no more Super potion");
                        goto AskPlayerAgain;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You healed your pokemon for 600HP !");
                    UseAnotherPot2:
                        Console.WriteLine("Use another potion Y or N?");

                        playerSelectYorN = Console.ReadKey().Key;
                        if (playerSelectYorN == ConsoleKey.Y)
                        {
                            Console.Clear();
                            goto AskPlayerAgain;
                        }
                        else if (playerSelectYorN == ConsoleKey.N)
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Console.WriteLine("Dang bro poor pokemon");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Console.WriteLine("You can't do that");
                            goto UseAnotherPot2;

                        }
                        goto AskPlayerAgain;
                    }
               

                case ConsoleKey.NumPad3:

                    _hyperPotion--;
                    Console.WriteLine("Total Hyper potion = " + _hyperPotion);

                    if (_hyperPotion == 0 || _hyperPotion < 0)
                    {
                        Console.WriteLine("You have no more Hyper potion");
                        goto AskPlayerAgain;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You healed your pokemon for 1000HP !");
                        UseAnotherPot3:
                        Console.WriteLine("Use another potion Y or N?");

                        playerSelectYorN = Console.ReadKey().Key;
                        if (playerSelectYorN == ConsoleKey.Y)
                        {
                            Console.Clear();
                            goto AskPlayerAgain;
                        }
                        else if (playerSelectYorN == ConsoleKey.N)
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Console.WriteLine("Dang bro poor pokemon");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.Clear();
                            Console.WriteLine("You can't do that");
                            goto UseAnotherPot3;
                        }
                        break;
                    }

                default:
                    Console.Clear();
                    Console.WriteLine("You can't do that");
                    goto AskPlayerAgain;
            }
        }
    }
}
