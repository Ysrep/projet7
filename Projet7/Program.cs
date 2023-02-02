using Newtonsoft.Json;
using System.Drawing;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Projet7
{
    internal class Program
    {

        public int ShortHealth { get; set; }

        //Math.Max(0,_health-amount);
        //Math.Min(_maxHealth,_health+amount);
        static void Main(string[] args)
        {

            NPC.CreateNPC();
            //PokemonTeam.CreateTeam();
            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All,
            };

            string path = @"player.json";

            Player player = new Player();
            ListConstruct inventory = new ListConstruct();
            string path1 = @"inventory.json";
            string path2 = @"playerPokemonTeam.json";
            Map map = new Map();
            if (File.Exists(path))
            {
                string fileName = "player.json";
                var jsonString = File.ReadAllText(fileName);
                player = JsonSerializer.Deserialize<Player>(jsonString)!;

                if (File.Exists(path2))
                {
                    string fileName1 = "playerPokemonTeam.json";
                    var jsonString1 = File.ReadAllText(fileName1);
                    player.ListPokemonTeam = JsonConvert.DeserializeObject<List<Pokemon>>(jsonString1, setting)!;
                }
            }
            else
            {
                player.InitWIthoutJSon(63, 218);
            }

            if (File.Exists(path1))
            {
                string fileName = "inventory.json";
                var jsonString = File.ReadAllText(fileName);
                inventory.inventory = JsonConvert.DeserializeObject<List<Item>>(jsonString, setting)!;
            }
            else
            {
                inventory.InitWithoutJSon();
            }
            AllBag allinventory = new AllBag();
            Menu menu = new Menu();
            map.Init();
            menu.ShowStartMenu(map);
            map.ShowMap(player.PlayerPos);
            while (!map.StartMenu)
            {
            Menu:
                while (map.Menu)
                {

                    menu.ShowMenu(map, player.PlayerPos);
                }
                if (map.Save)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    string fileName = "player.json";
                    var jsonString = JsonSerializer.Serialize<Player>(player);
                    File.WriteAllText(fileName, jsonString);


                    if (File.Exists(path2))
                    {
                        File.Delete(path2);
                    }
                    fileName = "playerPokemonTeam.json";
                    jsonString = JsonConvert.SerializeObject(player.ListPokemonTeam, setting);
                    File.WriteAllText(fileName, jsonString);


                    if (File.Exists(path1))
                    {
                        File.Delete(path1);
                    }

                    fileName = "inventory.json";
                    jsonString = JsonConvert.SerializeObject(inventory.inventory, setting);
                    File.WriteAllText(fileName, jsonString);
                    Console.Clear();
                    Console.WriteLine("Votre partie à bien été sauvegardé");
                    ConsoleKey input = Console.ReadKey().Key;
                    if (input == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        map.Save = false;
                        map.Menu = true;
                        goto Menu;
                    }
                }
                while (map.Inventory)
                {
                    map.Inventory = allinventory.ItemListDisp(inventory);
                    Console.Clear();
                    map.ShowMap(player.PlayerPos);
                }
                while (map.Pokemon)
                {
                    player.printPokemonTeam(); 
                }

                if (map.WildBattle)
                {
                    Console.Clear();
                    Arena battle = new Arena();
                    battle.ArenaFight(player.ListPokemonTeam);
                }

                player.Inputs(map);
            }
        }
    }
}