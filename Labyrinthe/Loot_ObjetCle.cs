using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    public class Loot_ObjetCle : Loot
    {
        private static int _nombreCle = 0;

        public Loot_ObjetCle() :base()
            { _nombreCle++;}

        public int MombreCle
        {
            get
            {
                return Loot_ObjetCle._nombreCle;
            }

        }
    }
}