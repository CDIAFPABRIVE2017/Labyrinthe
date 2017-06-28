﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{

    internal class Loot_SortChoixPotion : Loot_SortChoix
    {
       Joueur personnage = new Joueur();
        public void PotionVitesse()
        {
            personnage.Vitesse += constantesLoot.SortPotionVitesse;
        }
        public void PotionForce()
        {
            personnage.Force += constantesLoot.SortPotionForce;
        }
        public void PotionVision()
        {
            personnage.Vision += constantesLoot.SortPotionVision;
        }
    }


}