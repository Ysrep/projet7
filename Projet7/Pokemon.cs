using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
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


        [JsonInclude]
        public int id;
        [JsonInclude]
        public Dictionary<string, string> name;
        [JsonInclude]
        public string[] type;
        public Dictionary<string, int> Base { get; set; }

        public int level;

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
            return newp;
        }

        /*public int damageStep(Attack A, Pokemon P1, Pokemon P2)
        {
            int Att;
            int Def;
            if (A.Category == "physical")
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
            if ((P1.type[0] == A.Type) || (P1.type[1] == A.Type)) { STAB = 2; }
            else { STAB = 1; }
            Random r = new Random();
            int a = r.Next(217, 256);
            int rand = (a * 100) / 255;
            int damage = ((((P1.level * 2 / 5) + 2) * A.Damage * Att / 50 / Def) + 2) * rand / 100 * STAB; //Manque Type1, Type2, CC, mod1, mod2, mod3
            return damage;
        }*/

        /*public Pokemon useAttack(Pokemon P1, Pokemon P2)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{P1.Attack[i].Name} : {P1.Attack[i].Type}");
            }
            Console.WriteLine("Choose the attack you want to use");
        askAttack:
            ConsoleKey Key = Console.ReadKey().Key;
            if (Key != ConsoleKey.NumPad1 && Key != ConsoleKey.NumPad2 && Key != ConsoleKey.NumPad3 && Key != ConsoleKey.NumPad4)
            {
                Console.Write("Choose the attack you want to use");
                goto askAttack;
            }
            int attackSelect = (int)Key;
            Console.WriteLine($"{P1.name["english"]} use {P1.Attack[attackSelect].Name} !");
            int damage = damageStep(P1.Attack[attackSelect], P1, P2);
            P2.Base["HP"] = Math.Max(0, P2.Base["HP"] - damage);
            return P2;
        }*/
    }
}