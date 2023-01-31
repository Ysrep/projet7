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
            PlayerOpenInventory = Console.ReadKey().Key;

            switch (PlayerOpenInventory)
            {
                case ConsoleKey.I:
                    Console.Clear();
                    retryInventory :
                    Console.WriteLine("You opened your inventory ! Here's what you have :");
                    Console.WriteLine();

                    foreach (Item item in inventory.inventory)
                    {
                        Console.WriteLine("Name :" + item.itemName + "         Amount in inventory : " + item.AmountInStorage);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Open bag for Potion : P | Revive : R | Pokeball : O. Or exit with X");

                    ConsoleKey PlayerMoveInInventory;
                    PlayerMoveInInventory = Console.ReadKey().Key;

                    switch (PlayerMoveInInventory)
                    {
                        case ConsoleKey.P:
                        retryPot:
                            Console.WriteLine("Select the wanted potion");
                            Console.WriteLine("Potion : P | Super Potion : S | Hyper Potion : H | Exit the inventory : X");

                            ConsoleKey PlayerMoveInPotion;
                            PlayerMoveInPotion = Console.ReadKey().Key;
                            switch (PlayerMoveInPotion)
                            {
                                case ConsoleKey.P:

                                    Console.WriteLine();
                                    Console.WriteLine("You used a Potion to heal your pokemon by 200HP !");
                                    foreach (Item item in inventory.inventory)
                                    {
                                        if (item.itemName == "Potion")
                                        {
                                            item.AmountInStorage--;
                                            Console.WriteLine(item.AmountInStorage);
                                            break;
                                        }
                                    }
                                    goto retryPot;

                                case ConsoleKey.S:
                                    Console.WriteLine();
                                    Console.WriteLine("You used a Potion to heal your pokemon by 600HP !");
                                    foreach (Item item in inventory.inventory)
                                    {
                                        if(item.itemName == "Super Potion")
                                        {
                                            item.AmountInStorage--;
                                            Console.WriteLine(item.AmountInStorage);
                                            break;
                                        }
                                    }
                                    goto retryPot;

                                case ConsoleKey.H:
                                    Console.WriteLine();
                                    Console.WriteLine("You used a Potion to heal your pokemon by 1000HP !");
                                    foreach (HyperPotion item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryPot;


                                case ConsoleKey.X:
                                    break;

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
                            PlayerMoveInRevive = Console.ReadKey().Key;
                            switch (PlayerMoveInRevive)
                            {
                                case ConsoleKey.R:
                                    Console.WriteLine();
                                    Console.WriteLine("You used Revive to revive your pokemon at 50% of it's max HP !");
                                    foreach (Revive item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryRevive;

                                case ConsoleKey.M:

                                    Console.WriteLine();
                                    Console.WriteLine("You used Revive to revive your pokemon at 50% of it's max HP !");
                                    foreach (MaxRevive item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryRevive;


                                case ConsoleKey.X:
                                    break;

                                default:
                                    Console.WriteLine("Choose a viable option.");
                                    goto retryPot;
                            }
                            break;

                        case ConsoleKey.O:
                        retryPokeball:
                            Console.WriteLine("Select the wanted pokeball");
                            Console.WriteLine("Pokeball : P | Superball : S | Hyperball : H | Masterball : M | Exit the inventory : X");

                            ConsoleKey PlayerMoveInPokeball;
                            PlayerMoveInPokeball = Console.ReadKey().Key;
                            switch (PlayerMoveInPokeball)
                            {
                                case ConsoleKey.P:
                                    Console.WriteLine();
                                    Console.WriteLine("You used a pokeball");
                                    foreach (PokeBall item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryRevive;

                                case ConsoleKey.S:

                                    Console.WriteLine();
                                    Console.WriteLine("You used a superball");
                                    foreach (SuperBall item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryRevive;

                                case ConsoleKey.H:

                                    Console.WriteLine();
                                    Console.WriteLine("You used a Hyperball");
                                    foreach (HyperBall item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryPokeball;

                                case ConsoleKey.M:

                                    Console.WriteLine();
                                    Console.WriteLine("You used a Hyperball");
                                    foreach (MasterBall item in inventory.inventory)
                                    {
                                        item.AmountInStorage--;
                                        Console.WriteLine(item.AmountInStorage);
                                        break;
                                    }
                                    goto retryPokeball;
                                
                                case ConsoleKey.X:
                                    break;

                                default:
                                    Console.WriteLine("Choose a viable option.");
                                    goto retryPokeball;

                            }
                            break;

                        default:
                            Console.WriteLine("Choose a viable option.");
                            goto retryInventory;
                    }
                    break;
            }
        }
    }
}