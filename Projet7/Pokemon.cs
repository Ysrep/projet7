using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Pokemon
    {
        public string? name { get; set; }

        public int? hp { get; set; }

        Attacks[] attack = new Attacks[4];

        public Attacks getAttack(int i)
        {
            return attack[i];
        }

        public void setAttack(Attacks A, int i)
        {
            attack[i] = A;
        }

        public void useAttack(Pokemon P1,Pokemon P2)
        {
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(P1.attack[i].name + " : " + P1.attack[i].type);
            }
            Console.WriteLine("Choose the attack you want to use");
            int a = int.Parse(Console.ReadLine());
            //int damage = 
        }
    }
}