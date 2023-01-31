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
            Map map = new Map();

            Player player = new Player(63,218);
            AllBag allinventory = new AllBag();
            ListConstruct inventory = new ListConstruct();
            inventory.List();
            map.Init();
            map.ShowMap(player.PlayerPos);
            
            while (true)
            {
                map.ShowMap(player.PlayerPos);
                player.Move(map.GetMap());
                //player.checkPlayerPos();

               allinventory.ItemListDisp(inventory);

            } while (true);
        }
    }
}