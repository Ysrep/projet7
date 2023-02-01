using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Projet7
{
    public class PokemonTeam
    {
        public static PokemonTeam CreateTeam()
        {
            Random rId = new Random();
            Random rLvl = new Random();
            int opponentPokemonId = rId.Next(1, 613);
            int opponentPokemonLvl = rLvl.Next(5, 10);

            Pokemon opponentP = Pokemon.GetPokemon(opponentPokemonId, opponentPokemonLvl);

            Console.WriteLine(opponentP.name["french"]);
            Console.WriteLine("lvl " + opponentP.level);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(opponentP.attack[i].ename + " " + opponentP.attack[i].category);
            }
            return null;
        }
    }
}