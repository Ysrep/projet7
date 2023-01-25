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

            Player player = new Player();
            map.Init();
            player.Init();
            do
            {
                map.ShowMap(player.PlayerPos);
                player.Move(map.GetMap());
                //player.checkPlayerPos();
            } while (true);


            var rvl = new ReviveList();
            var ptl = new PotionList();
            var pbl = new PokeballList();

            Bag bag = new Bag();
            bag.OpenBag();

            

        }
    }
}