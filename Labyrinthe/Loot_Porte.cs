using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    public class Loot_Porte : Loot
    {
        bool _porteOuverte = false;

        public bool PorteOuverte
        {
            get
            {
                return _porteOuverte;
            }

            set
            {
                _porteOuverte = value;
            }
        }

    }
}