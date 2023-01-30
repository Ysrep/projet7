using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projet7
{
    public class PokemonTeam
    {
        public List<Attack> pokemonsInTeam;

        public PokemonTeam()
        {
            pokemonsInTeam = new List<Attack>();
        }

        public void AddPokemon(Attack pokemon)
        {
            if (pokemonsInTeam.Count <= 5) 
            {
                pokemonsInTeam.Add(pokemon); 
            }
            else { }
            
        }

        public void RemovePokemon(Attack pokemon)
        {
            pokemonsInTeam.Remove(pokemon);
        }

        public Attack GetPokemon(int id)
        {
            return pokemonsInTeam[id];
        }
    }
}