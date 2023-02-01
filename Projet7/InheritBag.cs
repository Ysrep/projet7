using Projet7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projet7
{
    public class Item
    {
        public string? itemName;

        public virtual int AmountInStorage
        {
            get; set;
        }
        public virtual int ID
        {
            get => 0;
        }
    }

    public class Potion : Item
    {
        public override string ToString()
        {
            return itemName = "Potion";
        }
        public virtual int AmountOfHP { get => 200; }
        public override int AmountInStorage
        {
            get; set;
        }

        public override int ID
        {
            get => 1;
        }
    }

    public class SuperPotion : Potion
    {
        public override string ToString()
        {
            return itemName = "Super Potion";
        }
        public override int AmountOfHP { get => 400; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 2;
        }

    }

    public class HyperPotion : Potion
    {
        public override string ToString()
        {
            return itemName = "Hyper Potion";
        }
        public override int AmountOfHP { get => 800; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 3;
        }

    }

    public class PokeBall : Item
    {
        public override string ToString()
        {
            return itemName = "Pokeball";
        }
        public virtual int CatchRate { get => 40; }
        public override int AmountInStorage
        {
            get; set;
        }

        public override int ID
        {
            get => 4;
        }
    }

    public class SuperBall : PokeBall
    {
        public override string ToString()
        {
            return itemName = "Superball";
        }
        public override int CatchRate { get => 60; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 5;
        }
    }

    public class HyperBall : PokeBall
    {
        public override string ToString()
        {
            return itemName = "Hyperball";
        }
        public override int CatchRate { get => 80; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 6;
        }
    }

    public class MasterBall : PokeBall
    {
        public override string ToString()
        {
            return itemName = "Masterball";
        }
        public override int CatchRate { get => 100; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 7;
        }
    }

    public class Revive : Item
    {
        public override string ToString()
        {
            return itemName = "Revive";
        }
        public virtual int PercentHPRevive { get => 50; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 8;
        }
    }

    public class MaxRevive : Revive
    {
        public override string ToString()
        {
            return itemName = "Max Revive";
        }
        public override int PercentHPRevive { get => 100; }
        public override int AmountInStorage
        {
            get; set;
        }
        public override int ID
        {
            get => 9;
        }
    }

    public class AllBagInit : IEquatable<AllBagInit>
    {
        public string? itemName { get; }
        public int ID { get; set; }
        public bool Equals(AllBagInit? other)
        {
            throw new NotImplementedException();
        }
    }

    public class ListConstruct
    {

        public List<Item> inventory { get; set; }

        public void List()
        {

            int PotStore = 15;
            int SupStore = 10;
            int HypStore = 5;
            int PokeStore = 20;
            int SupPokeStore = 15;
            int HypPokeStore = 10;
            int MastPokeStore = 1;
            int RevStore = 15;
            int MaxRevStore = 5;


            inventory = new List<Item>{
        new Potion() { itemName = "Potion", AmountInStorage = PotStore},
        new SuperPotion() { itemName = "Super Potion", AmountInStorage = SupStore},
        new HyperPotion() { itemName = "Hyper Potion", AmountInStorage = HypStore},
        new PokeBall() { itemName = "Pokeball", AmountInStorage = PokeStore},
        new SuperBall() { itemName = "Superball", AmountInStorage = SupPokeStore},
        new HyperBall() { itemName = "Hyperball", AmountInStorage = HypPokeStore},
        new MasterBall() { itemName = "Masterball", AmountInStorage = MastPokeStore},
        new Revive() { itemName = "Revive", AmountInStorage = RevStore},
        new MaxRevive() { itemName = "Max Revive", AmountInStorage = MaxRevStore}
            };
        }
    }

    public class AllBag
    {
        public void ItemListDisp(ListConstruct inventory)
        {
            ConsoleKey PlayerOpenInventory;
            PlayerOpenInventory = Console.ReadKey(intercept: true).Key;

            switch (PlayerOpenInventory)
            {
                case ConsoleKey.I:
                    Console.Clear();
                    retryInventory :
                    Console.WriteLine("You opened your inventory ! Here's what you have :");
                    Console.WriteLine();

                    foreach (Item item in inventory.inventory)
                    {
                        Console.WriteLine("Name :" + item.itemName + "     Amount in inventory :             " + item.AmountInStorage);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Open bag for Potion : P | Revive : R | Pokeball : O. Or exit with X");

                    ConsoleKey PlayerMoveInInventory;
                    PlayerMoveInInventory = Console.ReadKey(intercept: true).Key;

                    switch (PlayerMoveInInventory)
                    {
                        case ConsoleKey.P:
                        retryPot:
                            Console.WriteLine("Select the wanted potion");
                            Console.WriteLine("Potion : P | Super Potion : S | Hyper Potion : H | Exit the inventory : X");

                            ConsoleKey PlayerMoveInPotion;
                            PlayerMoveInPotion = Console.ReadKey(intercept: true).Key;
                            switch (PlayerMoveInPotion)
                            {

                                case ConsoleKey.P:
                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Potion" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPot;
                                        }

                                        if (item.itemName == "Potion" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage +" "+ item.itemName + " left.");
                                            Console.WriteLine();
                                            goto retryPot;
                                        }
                                    }
                                    break;

                                case ConsoleKey.S:
                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Super Potion" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPot;
                                        }

                                        if (item.itemName == "Super Potion" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();
                                            goto retryPot;
                                        }
                                    }
                                    break;

                                case ConsoleKey.H:
                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Hyper Potion" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPot;
                                        }

                                        if (item.itemName == "Hyper Potion" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();
                                            goto retryPot;
                                        }
                                    }
                                    break;


                                case ConsoleKey.X:
                                    Console.Clear();
                                    goto retryInventory;

                                default:
                                    Console.WriteLine("Choose a viable option.");
                                    goto retryPot;
                            }
                            break;

                        case ConsoleKey.R:
                        retryRevive:
                            Console.WriteLine("Select the wanted potion");
                            Console.WriteLine("Revive : R | Max Revive : M | Exit the inventory : X");

                            ConsoleKey PlayerMoveInRevive;
                            PlayerMoveInRevive = Console.ReadKey(intercept: true).Key;
                            switch (PlayerMoveInRevive)
                            {
                                case ConsoleKey.R:
                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Revive" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryRevive;
                                        }

                                        if (item.itemName == "Revive" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName +" left.");
                                            Console.WriteLine();
                                            goto retryRevive;
                                        }
                                       
                                    }
                                    break;


                                case ConsoleKey.M:

                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Max Revive" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryRevive;
                                        }

                                        if (item.itemName == "Max Revive" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();
                                            goto retryRevive;
                                        }
                                    }
                                    break;


                                case ConsoleKey.X:
                                    Console.Clear();
                                    goto retryInventory;

                                default:
                                    Console.WriteLine("Choose a viable option.");
                                    goto retryPot;
                            }
                            break;

                        case ConsoleKey.O:
                        retryPokeball:

                            Random catchProb = new Random();
                            int didICatchIt = catchProb.Next(0, 101);

                            Console.WriteLine("Select the wanted pokeball");
                            Console.WriteLine("Pokeball : P | Superball : S | Hyperball : H | Masterball : M | Exit the inventory : X");

                            ConsoleKey PlayerMoveInPokeball;
                            PlayerMoveInPokeball = Console.ReadKey(intercept: true).Key;
                            switch (PlayerMoveInPokeball)
                            {
                                case ConsoleKey.P:

                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Pokeball" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPokeball;
                                        }

                                        if (item.itemName == "Pokeball" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();

                                            if (didICatchIt <= 40)
                                            {
                                                Console.Clear() ;
                                                Console.WriteLine("You catched the pokemon !");
                                                goto retryInventory;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You did not catch the pokemon D:");
                                                goto retryPokeball;
                                            }
                                        }
                                    }
                                 break;

                                case ConsoleKey.S:

                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Superball" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPokeball;
                                        }

                                        if (item.itemName == "Superball" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();

                                            if (didICatchIt <= 60)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You catched the pokemon !");
                                                Console.WriteLine();
                                                goto retryInventory;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You did not catch the pokemon D:");
                                                Console.WriteLine();
                                                goto retryPokeball;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.H:

                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Hyperball" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPokeball;
                                        }

                                        if (item.itemName == "Hyperball" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();

                                            if (didICatchIt <= 80)
                                            {
                                                Console.Clear() ;
                                                Console.WriteLine("You catched the pokemon !");
                                                Console.WriteLine();
                                                goto retryInventory;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You did not catch the pokemon D:");
                                                Console.WriteLine();
                                                goto retryPokeball;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.M:

                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Masterball" && item.AmountInStorage == 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have 0 " + item.itemName + " left.");
                                            Console.WriteLine("You can't use : " + item.itemName + " if there is 0 in your inventory.");
                                            Console.WriteLine();
                                            goto retryPokeball;
                                        }

                                        if (item.itemName == "Masterball" && item.AmountInStorage >= 1)
                                        {
                                            Console.Clear();
                                            item.AmountInStorage--;
                                            Console.WriteLine("You used a " + item.itemName);
                                            Console.WriteLine();
                                            Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                            Console.WriteLine();

                                            if (didICatchIt <= 100)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("You catched the pokemon !");
                                                Console.WriteLine();
                                                goto retryInventory;
                                            }
                                            else
                                            {
                                                Console.Clear() ;
                                                Console.WriteLine("You did not catch the pokemon D:");
                                                Console.WriteLine();
                                                goto retryPokeball;
                                            }
                                        }
                                    }
                                    break;

                                case ConsoleKey.X:
                                    Console.Clear();
                                    goto retryInventory;


                                default:
                                    Console.Clear();
                                    Console.WriteLine("Choose a viable option.");
                                    goto retryPokeball;

                            }
                            break;

                        case ConsoleKey.X:
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Choose a viable option.");
                            goto retryInventory;
                    }
                    break;
            }
        }
    }
}