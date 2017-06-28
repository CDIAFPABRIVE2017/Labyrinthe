using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    internal class Loot_SortImmediat : Loot
    {
        Joueur personnage = new Joueur();
        public void SortVitesse()
        {
            personnage.Vitesse += constantesLoot.SortVitesse;
        }
        public void SortForce()
        {
            personnage.Force += constantesLoot.SortForce;
        }
        public void SortVision()
        {
            personnage.Vision += constantesLoot.SortVision;
        }
    }
}

