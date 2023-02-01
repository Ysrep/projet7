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
            Arena arena = new Arena();
            inventory.List();
            map.Init();
            //map.ShowMap(player.PlayerPos);
            
            while (true)
            {
                StatDisplay stat = new StatDisplay();
                //stat.StatTab();
                //stat.StatTabOpponent();
                map.ShowMap(player.PlayerPos);
                //player.Move(map.GetMap());
                //player.checkPlayerPos();

                allinventory.ItemListDisp(inventory);
               //arena.ArenaFight();

            } while (true);
        }
    }
}