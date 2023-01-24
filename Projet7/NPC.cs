using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Projet7
{
    public class NPC
    {
        public int? teamIdGet { get; }
        public int? DialogSelection { get; set; }
        public int? moneyGive { get; set; }

        public int _trainerPosX;
        public int _trainerPosY;

        public void setTrainerPos(int trainerPosX, int trainerPosY)
        {
            _trainerPosX = trainerPosX;
            _trainerPosY = trainerPosY;
            return;
        }

    }
}