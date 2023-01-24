using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Pokemon
    {
        public string? Name { get; set; }
        
        public string? Type { get; set; }

        public int Hp { get; set; }

        public int Level { get; set; }

        Attacks[] Attack = new Attacks[4];

        public Attacks getAttack(int i)
        {
            return Attack[i];
        }

        public void setAttack(Attacks A, int i)
        {
            Attack[i] = A;
        }

        Stats[] Stat = new Stats[6]; //0 PV; 1 Att; 2 Def; 3 SpeAtt; 4 SpeDeff; 5 Speed

        public Stats getStat(int i)
        {
            return Stat[i];
        }

        public void setStat(Stats S, int i)
        {
            Stat[i] = S;
        }

        public int damageStep(Attacks A, Pokemon P1, Pokemon P2)
        {
            int Att;
            int Def;
            if(A.Category == "physical")
            {
                Att = P1.Stat[1].Stat;
                Def = P2.Stat[2].Stat;
            }
            else
            {
                Att = P1.Stat[3].Stat;
                Def = P2.Stat[4].Stat;
            }
            int STAB;
            if(P1.Type == A.Type) { STAB = 2; }
            else { STAB = 1; }
            Random r = new Random();
            int a = r.Next(217, 256);
            int rand = (a * 100) / 255;
            int damage = ((((P1.Level * 2 / 5) + 2) * A.Damage * Att / 50 / Def) + 2) * rand / 100 * STAB; //Manque Type1, Type2, CC, mod1, mod2, mod3
            return damage;
        }

        public Pokemon useAttack(Pokemon P1,Pokemon P2)
        {
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(P1.Attack[i].Name + " : " + P1.Attack[i].Type);
            }
            Console.WriteLine("Choose the attack you want to use");
            askAttack :
            ConsoleKey Key = Console.ReadKey().Key;
            if(Key!=ConsoleKey.NumPad1 && Key != ConsoleKey.NumPad2 && Key != ConsoleKey.NumPad3 && Key != ConsoleKey.NumPad4)
            {
                Console.Write("Choose the attack you want to use");
                goto askAttack;
            }
            int attackSelect = (int)Key;
            int damage = damageStep(P1.Attack[attackSelect], P1, P2);
            P2.Hp = Math.Max(0, P2.Hp - damage);
            return P2;
        }
    }
}