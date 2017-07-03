using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    public class Loot_ObjetCle : Loot
    {
        private int _puissance = 0;

        public Loot_ObjetCle() :base()
            { ;}

        public int Puissance
        {
            get
            {
                return _puissance;
            }

            set
            {
                _puissance = value;
            }
        }
    }
}