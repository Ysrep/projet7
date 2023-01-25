using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet7
{
    class Bag
    { 
        public void OpenBag()
        {
            ConsoleKey playerInputOpenBag;
            playerInputOpenBag = Console.ReadKey().Key;
            ConsoleKey bagNavigate;

            var rvl = new ReviveList();
            var ptl = new PotionList();
            var pbl = new PokeballList();

            switch (playerInputOpenBag)
            {
                case ConsoleKey.B:

                    Console.WriteLine("You opened the bag");
                    Console.WriteLine("Select a compartiment, or exit the bag");
                    Console.WriteLine("Potion : P | Revive : R | Pokeballs : O");
                    bagNavigate = Console.ReadKey().Key;
                    switch (bagNavigate)
                    {
                        case ConsoleKey.P:

                            ptl?.PotionListDisp();

                            break;

                        case ConsoleKey.R:

                            rvl?.ReviveListDisp();

                            break;

                        case ConsoleKey.O:

                            pbl?.PokeballListDisp();

                            break;

                        default: break;
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
