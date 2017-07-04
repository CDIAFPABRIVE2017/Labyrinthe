using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    public class Loot_ObjetCle : Loot
    {
        private int _nombreCle = 0;

        public Loot_ObjetCle() :base()
            { ;}

        public int MombreCle
        {
            get
            {
                return _nombreCle;
            }

            set
            {
                _nombreCle = value;
            }
        }
    }
}