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
        public virtual int PercentHPRevive { get; }
        public virtual int CatchRate { get; }
        public virtual int AmountOfHP { get; }
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
        public override int AmountOfHP { get => 20; }
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
        public override int AmountOfHP { get => 60; }
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
        public override int AmountOfHP { get => 120; }
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
        public override int CatchRate { get => 40; }
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
        public override int PercentHPRevive { get => 50; }
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

        public void InitWithoutJSon()
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
        public bool ItemListDisp(ListConstruct inventory, List<Pokemon> pokemonTeam, Pokemon? wildPokemon, Map _map)
        {
            Console.Clear();
        retryInventory:
            Console.WriteLine("You opened your inventory ! Here's what you have :");
            Console.WriteLine();

            foreach (Item item in inventory.inventory)
            {
                Console.WriteLine("Name :" + item.itemName + "         Amount in inventory : " + item.AmountInStorage);
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
                                    foreach (var pokemon in pokemonTeam)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(pokemon.name["english"]);
                                        Console.WriteLine("Hp : " + pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                    }
                                ChoosePokemon:
                                    ConsoleKey ChoosePokemon;
                                    ChoosePokemon = Console.ReadKey(intercept: true).Key;
                                    switch (ChoosePokemon)
                                    {
                                        case ConsoleKey.NumPad1:
                                            if (pokemonTeam[0].currentHp == 0 || pokemonTeam[0].currentHp == pokemonTeam[0].Base["HP"])
                                            {
                                                Console.WriteLine();

                                                goto ChoosePokemon;

                                            }
                                            else
                                            {
                                                item.AmountInStorage--;
                                                Console.WriteLine("You used a " + item.itemName);
                                                Console.WriteLine();
                                                Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                Console.WriteLine();
                                                pokemonTeam[0].currentHp += item.AmountOfHP;
                                            }
                                            break;
                                        case ConsoleKey.NumPad2:
                                            if (pokemonTeam.Count > 1)
                                            {
                                                if (pokemonTeam[1].currentHp == 0 || pokemonTeam[1].currentHp == pokemonTeam[1].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[1].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad3:
                                            if (pokemonTeam.Count >= 3)
                                            {
                                                if (pokemonTeam[2].currentHp == 0 || pokemonTeam[2].currentHp == pokemonTeam[2].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[2].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad4:
                                            if (pokemonTeam.Count >= 4)
                                            {
                                                if (pokemonTeam[3].currentHp == 0 || pokemonTeam[3].currentHp == pokemonTeam[3].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[3].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad5:
                                            if (pokemonTeam.Count >= 5)
                                            {
                                                if (pokemonTeam[4].currentHp == 0 || pokemonTeam[4].currentHp == pokemonTeam[4].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[4].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad6:
                                            if (pokemonTeam.Count == 1)
                                            {
                                                if (pokemonTeam[5].currentHp == 0 || pokemonTeam[5].currentHp == pokemonTeam[5].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[5].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
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
                                    foreach (var pokemon in pokemonTeam)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(pokemon.name["english"]);
                                        Console.WriteLine("Hp : " + pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                    }
                                ChoosePokemon:
                                    ConsoleKey ChoosePokemon;
                                    ChoosePokemon = Console.ReadKey(intercept: true).Key;
                                    switch (ChoosePokemon)
                                    {
                                        case ConsoleKey.NumPad1:
                                            if (pokemonTeam[0].currentHp == 0 || pokemonTeam[0].currentHp == pokemonTeam[0].Base["HP"])
                                            {
                                                Console.WriteLine();

                                                goto ChoosePokemon;

                                            }
                                            else
                                            {
                                                item.AmountInStorage--;
                                                Console.WriteLine("You used a " + item.itemName);
                                                Console.WriteLine();
                                                Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                Console.WriteLine();
                                                pokemonTeam[0].currentHp += item.AmountOfHP;
                                            }
                                            break;
                                        case ConsoleKey.NumPad2:
                                            if (pokemonTeam.Count > 1)
                                            {
                                                if (pokemonTeam[1].currentHp == 0 || pokemonTeam[1].currentHp == pokemonTeam[1].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[1].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad3:
                                            if (pokemonTeam.Count >= 3)
                                            {
                                                if (pokemonTeam[2].currentHp == 0 || pokemonTeam[2].currentHp == pokemonTeam[2].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[2].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad4:
                                            if (pokemonTeam.Count >= 4)
                                            {
                                                if (pokemonTeam[3].currentHp == 0 || pokemonTeam[3].currentHp == pokemonTeam[3].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[3].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad5:
                                            if (pokemonTeam.Count >= 5)
                                            {
                                                if (pokemonTeam[4].currentHp == 0 || pokemonTeam[4].currentHp == pokemonTeam[4].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[4].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad6:
                                            if (pokemonTeam.Count == 1)
                                            {
                                                if (pokemonTeam[5].currentHp == 0 || pokemonTeam[5].currentHp == pokemonTeam[5].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[5].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
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
                                    foreach (var pokemon in pokemonTeam)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(pokemon.name["english"]);
                                        Console.WriteLine("Hp : " + pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                    }
                                ChoosePokemon:
                                    ConsoleKey ChoosePokemon;
                                    ChoosePokemon = Console.ReadKey(intercept: true).Key;
                                    switch (ChoosePokemon)
                                    {
                                        case ConsoleKey.NumPad1:
                                            if (pokemonTeam[0].currentHp == 0 || pokemonTeam[0].currentHp == pokemonTeam[0].Base["HP"])
                                            {
                                                Console.WriteLine();

                                                goto ChoosePokemon;

                                            }
                                            else
                                            {
                                                item.AmountInStorage--;
                                                Console.WriteLine("You used a " + item.itemName);
                                                Console.WriteLine();
                                                Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                Console.WriteLine();
                                                pokemonTeam[0].currentHp += item.AmountOfHP;
                                            }
                                            break;
                                        case ConsoleKey.NumPad2:
                                            if (pokemonTeam.Count > 1)
                                            {
                                                if (pokemonTeam[1].currentHp == 0 || pokemonTeam[1].currentHp == pokemonTeam[1].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[1].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad3:
                                            if (pokemonTeam.Count >= 3)
                                            {
                                                if (pokemonTeam[2].currentHp == 0 || pokemonTeam[2].currentHp == pokemonTeam[2].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[2].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad4:
                                            if (pokemonTeam.Count >= 4)
                                            {
                                                if (pokemonTeam[3].currentHp == 0 || pokemonTeam[3].currentHp == pokemonTeam[3].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[3].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad5:
                                            if (pokemonTeam.Count >= 5)
                                            {
                                                if (pokemonTeam[4].currentHp == 0 || pokemonTeam[4].currentHp == pokemonTeam[4].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[4].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad6:
                                            if (pokemonTeam.Count == 1)
                                            {
                                                if (pokemonTeam[5].currentHp == 0 || pokemonTeam[5].currentHp == pokemonTeam[5].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[5].currentHp += item.AmountOfHP;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
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
                                    foreach (var pokemon in pokemonTeam)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(pokemon.name["english"]);
                                        Console.WriteLine("Hp : " +pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                    }
                                ChoosePokemon:
                                    ConsoleKey ChoosePokemon;
                                    ChoosePokemon = Console.ReadKey(intercept: true).Key;
                                    switch (ChoosePokemon)
                                    {
                                        case ConsoleKey.NumPad1:
                                            if (pokemonTeam[0].currentHp != 0)
                                            {
                                                Console.WriteLine();
                                                goto ChoosePokemon;

                                            }
                                            else
                                            {
                                                item.AmountInStorage--;
                                                Console.WriteLine("You used a " + item.itemName);
                                                Console.WriteLine();
                                                Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                Console.WriteLine();
                                                pokemonTeam[0].currentHp += pokemonTeam[0].Base["HP"] / 2;
                                            }
                                            break;
                                        case ConsoleKey.NumPad2:
                                            if (pokemonTeam.Count > 1)
                                            {
                                                if (pokemonTeam[1].currentHp == 0 || pokemonTeam[1].currentHp == pokemonTeam[1].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[1].currentHp += pokemonTeam[0].Base["HP"] / 2;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad3:
                                            if (pokemonTeam.Count >= 3)
                                            {
                                                if (pokemonTeam[2].currentHp == 0 || pokemonTeam[2].currentHp == pokemonTeam[2].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[2].currentHp += pokemonTeam[0].Base["HP"] / 2;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad4:
                                            if (pokemonTeam.Count >= 4)
                                            {
                                                if (pokemonTeam[3].currentHp == 0 || pokemonTeam[3].currentHp == pokemonTeam[3].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[3].currentHp += pokemonTeam[0].Base["HP"] / 2;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad5:
                                            if (pokemonTeam.Count >= 5)
                                            {
                                                if (pokemonTeam[4].currentHp == 0 || pokemonTeam[4].currentHp == pokemonTeam[4].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[4].currentHp += pokemonTeam[0].Base["HP"] / 2;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad6:
                                            if (pokemonTeam.Count == 1)
                                            {
                                                if (pokemonTeam[5].currentHp == 0 || pokemonTeam[5].currentHp == pokemonTeam[5].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[5].currentHp += pokemonTeam[0].Base["HP"] / 2;
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
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
                                    foreach (var pokemon in pokemonTeam)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine(pokemon.name["english"]);
                                        Console.WriteLine("Hp : " + pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                    }
                                ChoosePokemon:
                                    ConsoleKey ChoosePokemon;
                                    ChoosePokemon = Console.ReadKey(intercept: true).Key;
                                    switch (ChoosePokemon)
                                    {
                                        case ConsoleKey.NumPad1:
                                            if (pokemonTeam[0].currentHp != 0)
                                            {
                                                Console.WriteLine();
                                                goto ChoosePokemon;

                                            }
                                            else
                                            {
                                                item.AmountInStorage--;
                                                Console.WriteLine("You used a " + item.itemName);
                                                Console.WriteLine();
                                                Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                Console.WriteLine();
                                                pokemonTeam[0].currentHp += pokemonTeam[0].Base["HP"];
                                            }
                                            break;
                                        case ConsoleKey.NumPad2:
                                            if (pokemonTeam.Count > 1)
                                            {
                                                if (pokemonTeam[1].currentHp == 0 || pokemonTeam[1].currentHp == pokemonTeam[1].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[1].currentHp += pokemonTeam[0].Base["HP"];
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad3:
                                            if (pokemonTeam.Count >= 3)
                                            {
                                                if (pokemonTeam[2].currentHp == 0 || pokemonTeam[2].currentHp == pokemonTeam[2].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[2].currentHp += pokemonTeam[0].Base["HP"];
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad4:
                                            if (pokemonTeam.Count >= 4)
                                            {
                                                if (pokemonTeam[3].currentHp == 0 || pokemonTeam[3].currentHp == pokemonTeam[3].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[3].currentHp += pokemonTeam[0].Base["HP"];
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad5:
                                            if (pokemonTeam.Count >= 5)
                                            {
                                                if (pokemonTeam[4].currentHp == 0 || pokemonTeam[4].currentHp == pokemonTeam[4].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[4].currentHp += pokemonTeam[0].Base["HP"];
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        case ConsoleKey.NumPad6:
                                            if (pokemonTeam.Count == 1)
                                            {
                                                if (pokemonTeam[5].currentHp == 0 || pokemonTeam[5].currentHp == pokemonTeam[5].Base["HP"])
                                                {
                                                    Console.WriteLine();
                                                }
                                                else
                                                {
                                                    item.AmountInStorage--;
                                                    Console.WriteLine("You used a " + item.itemName);
                                                    Console.WriteLine();
                                                    Console.WriteLine("You have : " + item.AmountInStorage + " " + item.itemName + " left.");
                                                    Console.WriteLine();
                                                    pokemonTeam[5].currentHp += pokemonTeam[0].Base["HP"];
                                                }
                                            }
                                            else
                                            {
                                                goto ChoosePokemon;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
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
                            if (wildPokemon != null && _map.WildBattle)
                            {
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
                                            Console.Clear();
                                            Console.WriteLine("You catched the pokemon !");
                                            if (pokemonTeam.Count == 6)
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                ConsoleKey key = Console.ReadKey(true).Key;
                                                switch(key){
                                                    case ConsoleKey.NumPad1:
                                                        break;
                                                    case ConsoleKey.NumPad2:
                                                        break;
                                                    case ConsoleKey.NumPad3:
                                                        break;
                                                    case ConsoleKey.NumPad4:
                                                        break;
                                                    case ConsoleKey.NumPad5:
                                                        break;
                                                    case ConsoleKey.NumPad6:
                                                        break;

                                                }
                                            }
                                            else
                                            {
                                                pokemonTeam.Add(wildPokemon);
                                            }
                                            _map.WildBattle = false;
                                            return false;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You did not catch the pokemon D:");
                                            goto retryPokeball;
                                        }
                                    }
                                }
                            }
                            break;

                        case ConsoleKey.S:
                            if (wildPokemon != null && _map.WildBattle)
                            {
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
                                            if (pokemonTeam.Count == 6)
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                foreach (var pokemon in pokemonTeam)
                                                {
                                                    Console.WriteLine(pokemon.name["english"] + " Level : " + pokemon.level);
                                                    Console.WriteLine(pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                                }
                                                ConsoleKey key = Console.ReadKey(true).Key;
                                                switch(key){
                                                    case ConsoleKey.NumPad1:
                                                        pokemonTeam.RemoveAt(0);
                                                        pokemonTeam.Insert(0,wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad2:
                                                        pokemonTeam.RemoveAt(1);
                                                        pokemonTeam.Insert(1, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad3:
                                                        pokemonTeam.RemoveAt(2);
                                                        pokemonTeam.Insert(2, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad4:
                                                        pokemonTeam.RemoveAt(3);
                                                        pokemonTeam.Insert(3, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad5:
                                                        pokemonTeam.RemoveAt(4);
                                                        pokemonTeam.Insert(4, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad6:
                                                        pokemonTeam.RemoveAt(5);
                                                        pokemonTeam.Insert(5, wildPokemon);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                pokemonTeam.Add(wildPokemon);
                                            }
                                            Console.WriteLine();
                                            _map.WildBattle = false;
                                            return false;
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
                            }
                            break;

                        case ConsoleKey.H:
                            if (wildPokemon != null && _map.WildBattle)
                            {
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
                                            Console.Clear();
                                            Console.WriteLine("You catched the pokemon !");
                                            if (pokemonTeam.Count == 6)
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                foreach (var pokemon in pokemonTeam)
                                                {
                                                    Console.WriteLine(pokemon.name["english"] + " Level : " + pokemon.level);
                                                    Console.WriteLine(pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                                }
                                                ConsoleKey key = Console.ReadKey(true).Key;
                                                switch (key)
                                                {
                                                    case ConsoleKey.NumPad1:
                                                        pokemonTeam.RemoveAt(0);
                                                        pokemonTeam.Insert(0, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad2:
                                                        pokemonTeam.RemoveAt(1);
                                                        pokemonTeam.Insert(1, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad3:
                                                        pokemonTeam.RemoveAt(2);
                                                        pokemonTeam.Insert(2, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad4:
                                                        pokemonTeam.RemoveAt(3);
                                                        pokemonTeam.Insert(3, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad5:
                                                        pokemonTeam.RemoveAt(4);
                                                        pokemonTeam.Insert(4, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad6:
                                                        pokemonTeam.RemoveAt(5);
                                                        pokemonTeam.Insert(5, wildPokemon);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                pokemonTeam.Add(wildPokemon);
                                            }
                                            Console.WriteLine();
                                            _map.WildBattle = false;
                                            return false;
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
                            }
                            break;

                        case ConsoleKey.M:
                            if (wildPokemon != null && _map.WildBattle)
                            {
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
                                            if (pokemonTeam.Count == 6)
                                            {
                                                Console.Clear();
                                                Console.WriteLine();
                                                foreach (var pokemon in pokemonTeam)
                                                {
                                                    Console.WriteLine(pokemon.name["english"] + " Level : " + pokemon.level);
                                                    Console.WriteLine(pokemon.currentHp + " / " + pokemon.Base["HP"]);
                                                }
                                                ConsoleKey key = Console.ReadKey(true).Key;
                                                switch (key)
                                                {
                                                    case ConsoleKey.NumPad1:
                                                        pokemonTeam.RemoveAt(0);
                                                        pokemonTeam.Insert(0, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad2:
                                                        pokemonTeam.RemoveAt(1);
                                                        pokemonTeam.Insert(1, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad3:
                                                        pokemonTeam.RemoveAt(2);
                                                        pokemonTeam.Insert(2, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad4:
                                                        pokemonTeam.RemoveAt(3);
                                                        pokemonTeam.Insert(3, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad5:
                                                        pokemonTeam.RemoveAt(4);
                                                        pokemonTeam.Insert(4, wildPokemon);
                                                        break;
                                                    case ConsoleKey.NumPad6:
                                                        pokemonTeam.RemoveAt(5);
                                                        pokemonTeam.Insert(5, wildPokemon);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                pokemonTeam.Add(wildPokemon);
                                            }
                                            Console.WriteLine();
                                            return false;
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
                    return false;

                default:
                    Console.Clear();
                    Console.WriteLine("Choose a viable option.");
                    goto retryInventory;
            }
            return true;
        }
    }
}