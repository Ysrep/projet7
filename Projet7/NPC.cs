using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projet7
{
    public class NPC
    {
        public int PNJ;
        public static NPC CreateNPC()
        {
            Random rMoney = new Random();
            int moneyWin = rMoney.Next(75, 250);

            Console.WriteLine("Trainer");
            Console.WriteLine("Pokédollar : " + moneyWin);
            NPC n = new NPC();
            n.PNJ = moneyWin;
            return n;
        }
    }
}