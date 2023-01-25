using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projet7
{
    public class PokemonTeam
    {
        public List<Pokemon> pokemonsInTeam;

        public PokemonTeam()
        {
            pokemonsInTeam = new List<Pokemon>();
        }

        public void AddPokemon(Pokemon pokemon)
        {
            if (pokemonsInTeam.Count <= 5) 
            {
                pokemonsInTeam.Add(pokemon); 
            }
            else { }
            
        }

        public void RemovePokemon(Pokemon pokemon)
        {
            pokemonsInTeam.Remove(pokemon);
        }

        public Pokemon GetPokemon(int id)
        {
            return pokemonsInTeam[id];
        }
    }
}