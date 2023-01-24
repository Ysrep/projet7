using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projet7
{
    public class PokemonTeam
    {

        public int _teamId;
        public bool _isTrainerTeam = false;
        public int _nbrOfPokemon;
        public int _lvlOfEachPokemon;

        public void TrainerTeam (int teamId)
        {
            _teamId = teamId;
        }

        public void isTrainerDetection()
        {

        }

    }
}