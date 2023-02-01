using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projet7
{
    public class NPC
    {
        public static NPC CreateNPC()
        {
            Random rMoney = new Random();
            int moneyWin = rMoney.Next(75, 250);

            Console.WriteLine("Trainer");
            Console.WriteLine("Pokédollar : " + moneyWin);
            return null;
        }
    }
}