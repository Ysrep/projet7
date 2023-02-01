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

            NPC.CreateNPC();
            PokemonTeam.CreateTeam();

            Map map = new Map();
            Player player = new Player(63,218);
            AllBag allinventory = new AllBag();
            ListConstruct inventory = new ListConstruct();
            Menu menu = new Menu();
            inventory.List();
            map.Init();
            menu.ShowMenu();
            while (map.Menu)
            {
                map.Menu = menu.Selection();
            }
            map.ShowMap(player.PlayerPos);
            while (!map.Menu && !map.Inventory)
            {
               player.Inputs(map);
            }
            while (!map.Menu && map.Inventory)
            {
               allinventory.ItemListDisp(inventory);
            }
        }
    }
}