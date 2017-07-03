using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    public class Loot_Porte : Loot
    {

        public bool PorteOuvert(int nombreCle)
        {
            if (nombreCle>=constantesLoot.ClesOuvrePorte)
            {
                return true;
            }
            return false;
        }
    }
}