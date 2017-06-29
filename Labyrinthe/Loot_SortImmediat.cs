using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    internal class Loot_SortImmediat : Loot
        
    {
        Joueur personnage = new Joueur();
        TypeSort _sortImmediat = new TypeSort();

        internal TypeSort SortImmediat
        {
            get
            {
                return _sortImmediat;
            }

            set
            {
                _sortImmediat = value;
            }
        }

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

