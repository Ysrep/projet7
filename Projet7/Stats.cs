using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet7
{
    public class Stats
    {
        int[] stat = new int[4];

        public int getStar(int i)
        {
            return stat[i];
        }

        public void setStat(int S, int i)
        {
            stat[i] = S;
        }
    }
}