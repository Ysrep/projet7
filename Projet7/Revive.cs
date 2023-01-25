using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Revive
    {
        public string? reviveName { get; set; }
        public int? reviveTotal { get; set; }
        public int reviveId { get; set; }

        public bool Equals(Revive? other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "ID: " + reviveId + "   Name: " + reviveName + "  Total: " + reviveTotal;
        }
    }

    public class ReviveList
    {
        public int _revive = 15;
        public int _reviveMax = 10;

        public void ReviveListDisp()
        {
            List<Revive> ReviveListing = new List<Revive>()
            {
                new Revive() { reviveName = "Revive", reviveId = 1, reviveTotal = _revive },
                new Revive() { reviveName = "Max Revive", reviveId = 2, reviveTotal = _reviveMax },
            };

            foreach (Revive aRevive in ReviveListing)
            {
                Console.WriteLine("Remaining Revives:  " + aRevive);
            }

        AskPlayerAgain:
            Console.WriteLine();
            Console.WriteLine("Which Revive ID will you choose ?");
            ConsoleKey playerInputRevive;
            playerInputRevive = Console.ReadKey().Key;
            Console.WriteLine();

            switch (playerInputRevive)
            {
                case ConsoleKey.NumPad1:

                    _revive--;
                    Console.WriteLine("Total revives = " + _revive);

                    if (_revive == 0 || _revive < 0)
                    {
                        Console.WriteLine("You have no more revive");
                        goto AskPlayerAgain;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You revived your pokemon with half it's HP!");

                        goto AskPlayerAgain;
                    }


                case ConsoleKey.NumPad2:
                    _reviveMax--;
                    Console.WriteLine("Total Max Revives = " + _reviveMax);

                    if (_reviveMax == 0 || _reviveMax < 0)
                    {
                        Console.WriteLine("You have no more Max Revive");
                        goto AskPlayerAgain;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("You revived your pokemon with full health !");

                        goto AskPlayerAgain;
                    }

                default:


                    break;
            }
        }
    }
}