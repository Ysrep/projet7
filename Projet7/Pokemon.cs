using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projet7
{
    [Serializable]
    public class Pokedex
    {
        [JsonInclude]
        public Pokemon[] pokemons;

    }

    [Serializable]
    public class Pokemon
    {
        static Dictionary<int, Pokemon> _pokedex;

        static Pokemon()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var json = File.ReadAllText("../../../Pokemon.json");
            var pokedex = JsonSerializer.Deserialize<Pokedex>(json, options);
            _pokedex = new Dictionary<int, Pokemon>(pokedex.pokemons.Select(i => new KeyValuePair<int, Pokemon>(i.id, i)));
        }


        [JsonInclude] public int id;
        [JsonInclude] public Dictionary<string, string> name;
        [JsonInclude] public string[] type;


        public Attack[] attack;
        public int level;
        public int currentHp;
        public int currentXp;
        public int XpMax;

        public Dictionary<string, int> Base { get; set; }


        public static Pokemon GetPokemon(int id, int lvl)
        {
            var neuf = _pokedex.GetValueOrDefault(id);
            var newp = new Pokemon()
            {
                id = neuf.id,
                name = new Dictionary<string, string>(neuf.name),
                type = neuf.type.ToArray(),
                Base = new Dictionary<string, int>(neuf.Base)
            };

            newp.level = lvl;
            newp.attack = new Attack[4];
            newp.Base["HP"] = (newp.Base["HP"] * (newp.level / 100) + newp.level + 10);
            newp.Base["Attack"] = (newp.Base["Attack"] * (newp.level / 100) + 5);
            newp.Base["Defense"] = (newp.Base["Defense"] * (newp.level / 100) + 5);
            newp.Base["Sp. Attack"] = (newp.Base["Sp. Attack"] * (newp.level / 100) + 5);
            newp.Base["Sp. Defense"] = (newp.Base["Sp. Defense"] * (newp.level / 100) + 5);
            newp.Base["Speed"] = (newp.Base["Speed"] * (newp.level / 100) + 5);
            newp.currentHp = newp.Base["HP"];

            for (int i = 0; i < 4; i++)
            {
                Random r = new Random();
                int a = r.Next(1, 613);
                newp.attack[i] = Attack.GetAttack(a);
            }
            newp.currentXp = 0;
            newp.XpMax = 1000 * newp.level;
            return newp;
        }

        public double typeTable(Pokemon P1, Attack A)
        {
            double efficiency1 = 0;
            switch (P1.type[0])
            {
                case "Fire":
                    if(A.type == "Water" || A.type == "ground" || A.type == "Rock") { efficiency1 += 2; }
                    if(A.type == "Fire" || A.type == "Grass" || A.type == "Ice" || A.type == "Bug" || A.type == "Steel") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Normal":
                    if(A.type == "Fighting") { efficiency1 += 2; }
                    if (A.type == "Ghost") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
                case "Grass":
                    if(A.type == "Fire" || A.type == "Ice" || A.type == "Poison" || A.type == "Bug" || A.type == "Flying") { efficiency1 += 2; }
                    if(A.type == "Grass" || A.type == "Water" || A.type == "Electric" || A.type == "Ground" || A.type == "Steel" || A.type == "Fairy") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Water":
                    if(A.type == "Grass" || A.type == "Electric") { efficiency1 += 2; }
                    if(A.type == "Fire" || A.type == "Water" || A.type == "Ice") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Electric":
                    if(A.type == "Ground") { efficiency1 += 2; }
                    if(A.type == "Electric" || A.type == "Flying" || A.type == "Steel") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Ice":
                    if(A.type == "Fire" || A.type == "Fighting" || A.type == "Rock" || A.type == "Steel") { efficiency1 += 2; }
                    if(A.type == "Ice") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Fighting":
                    if(A.type == "Psychic" || A.type == "Flying" || A.type == "Fairy") { efficiency1 += 2; }
                    if(A.type == "Dark" || A.type == "Rock" || A.type == "Bug") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Poison":
                    if(A.type == "Ground" || A.type == "Psychic") { efficiency1 += 2; }
                    if(A.type == "Grass" || A.type == "Fighting" || A.type == "Poison" || A.type == "Bug" || A.type == "Fairy") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Ground":
                    if(A.type == "Grass" || A.type == "Water" || A.type == "Ice") { efficiency1 += 2; }
                    if(A.type == "Poison" || A.type == "Rock") { efficiency1 += 0.5; }
                    if(A.type == "Electric") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
                case "Flying":
                    if(A.type == "Electric" || A.type == "Ice" || A.type == "Rock") { efficiency1 += 2; }
                    if(A.type == "Grass" || A.type == "Fighting" || A.type == "Bug") { efficiency1 += 0.5; }
                    if(A.type == "Ground") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
                case "Psychic":
                    if(A.type == "Bug" || A.type == "Ghost" || A.type == "Dark") { efficiency1 += 2; }
                    if(A.type == "Fighting" || A.type == "Psychic") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Bug":
                    if(A.type == "Fire" || A.type == "Flying" || A.type == "Rock") { efficiency1 += 2; }
                    if(A.type == "Grass" || A.type == "Fighting" || A.type == "Ground") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Rock":
                    if(A.type == "Grass" || A.type == "Water" || A.type == "Fighting" || A.type == "Ground" || A.type == "Steel") { efficiency1 += 2; }
                    if(A.type == "Flying" || A.type == "Poison" || A.type == "Fire" || A.type == "Normal") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Ghost":
                    if(A.type == "Ghost" || A.type == "Dark") { efficiency1 += 2; }
                    if(A.type == "Poison" || A.type == "Bug") { efficiency1 += 0.5; }
                    if(A.type == "Normal" || A.type == "Fighting") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
                case "Dragon":
                    if(A.type == "Ice" || A.type == "Dragon" || A.type == "Fairy") { efficiency1 += 2; }
                    if(A.type == "Grass" || A.type == "Water" || A.type == "Fire" || A.type == "Electric") { efficiency1 += 0.5; }
                    else { efficiency1 += 1; }
                    break;
                case "Dark":
                    if(A.type == "Fighting" || A.type == "Bug" || A.type == "Fairy") { efficiency1 += 2; }
                    if(A.type == "Ghost" || A.type == "Dark") { efficiency1 += 0.5; }
                    if(A.type == "Psychic") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
                case "Steel":
                    if(A.type == "Fire" || A.type == "Fighting" || A.type == "Ground") { efficiency1 += 2; }
                    if(A.type == "Normal" || A.type == "Grass" || A.type == "Ice" || A.type == "Flying" || A.type == "Psychic" || A.type == "Bug" || A.type == "Rock" || A.type == "Dragon" || A.type == "Steel" || A.type == "Fairy") { efficiency1 += 0.5; }
                    if (A.type == "Poison") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
                case "Fairy":
                    if(A.type == "Poison" || A.type == "Steel") { efficiency1 += 2; }
                    if(A.type == "Fighting" || A.type == "Bug" || A.type == "Dark") { efficiency1 += 0.5; }
                    if(A.type == "Dragon") { efficiency1 = 0; }
                    else { efficiency1 += 1; }
                    break;
            }
            double efficiency2 = 0;
            switch (P1.type[1])
            {
                case "Fire":
                    if (A.type == "Water" || A.type == "ground" || A.type == "Rock") { efficiency2 += 2; }
                    if (A.type == "Fire" || A.type == "Grass" || A.type == "Ice" || A.type == "Bug" || A.type == "Steel") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Normal":
                    if (A.type == "Fighting") { efficiency2 += 2; }
                    if (A.type == "Ghost") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
                case "Grass":
                    if (A.type == "Fire" || A.type == "Ice" || A.type == "Poison" || A.type == "Bug" || A.type == "Flying") { efficiency2 += 2; }
                    if (A.type == "Grass" || A.type == "Water" || A.type == "Electric" || A.type == "Ground" || A.type == "Steel" || A.type == "Fairy") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Water":
                    if (A.type == "Grass" || A.type == "Electric") { efficiency2 += 2; }
                    if (A.type == "Fire" || A.type == "Water" || A.type == "Ice") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Electric":
                    if (A.type == "Ground") { efficiency2 += 2; }
                    if (A.type == "Electric" || A.type == "Flying" || A.type == "Steel") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Ice":
                    if (A.type == "Fire" || A.type == "Fighting" || A.type == "Rock" || A.type == "Steel") { efficiency2 += 2; }
                    if (A.type == "Ice") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Fighting":
                    if (A.type == "Psychic" || A.type == "Flying" || A.type == "Fairy") { efficiency2 += 2; }
                    if (A.type == "Dark" || A.type == "Rock" || A.type == "Bug") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Poison":
                    if (A.type == "Ground" || A.type == "Psychic") { efficiency2 += 2; }
                    if (A.type == "Grass" || A.type == "Fighting" || A.type == "Poison" || A.type == "Bug" || A.type == "Fairy") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Ground":
                    if (A.type == "Grass" || A.type == "Water" || A.type == "Ice") { efficiency2 += 2; }
                    if (A.type == "Poison" || A.type == "Rock") { efficiency2 += 0.5; }
                    if (A.type == "Electric") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
                case "Flying":
                    if (A.type == "Electric" || A.type == "Ice" || A.type == "Rock") { efficiency2 += 2; }
                    if (A.type == "Grass" || A.type == "Fighting" || A.type == "Bug") { efficiency2 += 0.5; }
                    if (A.type == "Ground") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
                case "Psychic":
                    if (A.type == "Bug" || A.type == "Ghost" || A.type == "Dark") { efficiency2 += 2; }
                    if (A.type == "Fighting" || A.type == "Psychic") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Bug":
                    if (A.type == "Fire" || A.type == "Flying" || A.type == "Rock") { efficiency2 += 2; }
                    if (A.type == "Grass" || A.type == "Fighting" || A.type == "Ground") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Rock":
                    if (A.type == "Grass" || A.type == "Water" || A.type == "Fighting" || A.type == "Ground" || A.type == "Steel") { efficiency2 += 2; }
                    if (A.type == "Flying" || A.type == "Poison" || A.type == "Fire" || A.type == "Normal") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Ghost":
                    if (A.type == "Ghost" || A.type == "Dark") { efficiency2 += 2; }
                    if (A.type == "Poison" || A.type == "Bug") { efficiency2 += 0.5; }
                    if (A.type == "Normal" || A.type == "Fighting") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
                case "Dragon":
                    if (A.type == "Ice" || A.type == "Dragon" || A.type == "Fairy") { efficiency2 += 2; }
                    if (A.type == "Grass" || A.type == "Water" || A.type == "Fire" || A.type == "Electric") { efficiency2 += 0.5; }
                    else { efficiency2 += 1; }
                    break;
                case "Dark":
                    if (A.type == "Fighting" || A.type == "Bug" || A.type == "Fairy") { efficiency2 += 2; }
                    if (A.type == "Ghost" || A.type == "Dark") { efficiency2 += 0.5; }
                    if (A.type == "Psychic") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
                case "Steel":
                    if (A.type == "Fire" || A.type == "Fighting" || A.type == "Ground") { efficiency2 += 2; }
                    if (A.type == "Normal" || A.type == "Grass" || A.type == "Ice" || A.type == "Flying" || A.type == "Psychic" || A.type == "Bug" || A.type == "Rock" || A.type == "Dragon" || A.type == "Steel" || A.type == "Fairy") { efficiency2 += 0.5; }
                    if (A.type == "Poison") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
                case "Fairy":
                    if (A.type == "Poison" || A.type == "Steel") { efficiency2 += 2; }
                    if (A.type == "Fighting" || A.type == "Bug" || A.type == "Dark") { efficiency2 += 0.5; }
                    if (A.type == "Dragon") { efficiency2 = 0; }
                    else { efficiency2 += 1; }
                    break;
            }
            return (efficiency1 * efficiency2);
        }

        public int damageStep(Attack A, Pokemon P1, Pokemon P2)
        {
            int Att;
            int Def;
            if (A.category == "Physique")
            {
                Att = P1.Base["Attack"];
                Def = P2.Base["Defense"];
            }
            else
            {
                Att = P1.Base["Sp. Attack"];
                Def = P2.Base["Sp. Defense"];
            }
            int STAB;
            if ((P1.type[0] == A.type) || (P1.type[1] == A.type)) { STAB = 2; }
            else { STAB = 1; }
            double efficiency = typeTable(P2, A);
            int Type1 = Convert.ToInt32(efficiency);
            Random r = new Random();
            int a = r.Next(217, 256);
            int rand = (a * 100) / 255;
            int damage = ((((P1.level * 2 / 5) + 2) * A.power * Att / 50 / Def) + 2) * rand / 100 * STAB * Type1; //Manque CC, mod1, mod2, mod3
            return damage;
        }

        public Pokemon useAttack(Pokemon P1, Pokemon P2)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{P1.attack[i].ename} : {P1.attack[i].type} : power{P1.attack[i].power} : pp{P1.attack[i].currentPp}/{P1.attack[i].pp}");
            }
            Console.WriteLine("Choose the attack you want to use");
        askAttack:
            ConsoleKey Key = Console.ReadKey().Key;
            if (Key != ConsoleKey.NumPad1 && Key != ConsoleKey.NumPad2 && Key != ConsoleKey.NumPad3 && Key != ConsoleKey.NumPad4)
            {
                Console.WriteLine("Choose the attack you want to use");
                goto askAttack;
            }
            int attackSelect = (int)Key;
            if (P1.attack[attackSelect].pp == 0)
            {
                Console.WriteLine("This attack don't have pp !");
                Console.WriteLine("Choose the attack you want tu use");
                goto askAttack;
            }
            Console.WriteLine($"{P1.name["english"]} use {P1.attack[attackSelect-1].ename} !");
            int damage = damageStep(P1.attack[attackSelect], P1, P2);
            P2.currentHp = Math.Max(0, P2.currentHp - damage);
            P1.attack[attackSelect].currentPp -= 1;
            return P2;
        }

        public Pokemon WinXp(Pokemon P1, Pokemon P2)
        {
            int Xpwin = (((100*P2.level)/5)*(int)Math.Pow(((2*(P2.level+10))/(P2.level+P1.level+10)),2.5));
            if((P1.currentXp + Xpwin) < P1.XpMax)
            {
                P1.currentXp += Xpwin;
            }
            else
            {
                int XpSupp = (P1.currentXp + Xpwin) - XpMax;
                P1.currentXp = 0;
                P1.level += 1;
                P1.Base["HP"] = (P1.Base["HP"] * (P1.level / 100) + P1.level + 10);
                P1.Base["Attack"] = (P1.Base["Attack"] * (P1.level / 100) + 5);
                P1.Base["Defense"] = (P1.Base["Defense"] * (P1.level / 100) + 5);
                P1.Base["Sp. Attack"] = (P1.Base["Sp. Attack"] * (P1.level / 100) + 5);
                P1.Base["Sp. Defense"] = (P1.Base["Sp. Defense"] * (P1.level / 100) + 5);
                P1.Base["Speed"] = (P1.Base["Speed"] * (P1.level / 100) + 5);
                P1.XpMax = 1000 * P1.level;
                P1.currentXp += XpSupp;
            }
            if (P1.level % 5 == 0)
            {
                P1.LearnAttack(P1);
            }
            return P1;
        }

        public Pokemon LearnAttack(Pokemon P1)
        {
            Random r = new Random();
            int a = r.Next(1, 613);
            Attack A = Attack.GetAttack(a);
            Console.WriteLine($"{P1.name} want to learn {A.ename} !");
            Console.WriteLine("Choose the attack you want to forget");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(P1.attack[i].ename);
            }
        askAttack:
            ConsoleKey Key = Console.ReadKey().Key;
            if (Key != ConsoleKey.NumPad1 && Key != ConsoleKey.NumPad2 && Key != ConsoleKey.NumPad3 && Key != ConsoleKey.NumPad4)
            {
                Console.WriteLine("Choose the attack you want to use");
                goto askAttack;
            }
            int attackSelect = (int)Key;
            if (attackSelect == 0)
            {
                Console.WriteLine($"{P1.name} don't learn {A.ename}");
                return P1;
            }
            if (attackSelect == 1)
            {
                Console.WriteLine($"{P1.name} forget {P1.attack[attackSelect - 1]} and he learn {A.ename}");
                P1.attack[attackSelect - 1] = A;
                return P1;
            }
            if (attackSelect == 2)
            {
                Console.WriteLine($"{P1.name} forget {P1.attack[attackSelect - 1]} and he learn {A.ename}");
                P1.attack[attackSelect - 1] = A;
                return P1;
            } 
            if (attackSelect == 3)
            {
                Console.WriteLine($"{P1.name} forget {P1.attack[attackSelect - 1]} and he learn {A.ename}");
                P1.attack[attackSelect - 1] = A;
                return P1;
            }
            if (attackSelect == 4)
            {
                Console.WriteLine($"{P1.name} forget {P1.attack[attackSelect - 1]} and he learn {A.ename}");
                P1.attack[attackSelect - 1] = A;
                return P1;
            }
            return P1;
        }
    }
}