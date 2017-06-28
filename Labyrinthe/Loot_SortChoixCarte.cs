using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace Labyrinthe
{
    internal class Loot_SortChoixCarte : Loot_SortChoix
    {
        Joueur personnage = new Joueur();

        public void CarteVitesse()
        {
            personnage.Vitesse -= constantesLoot.SortCarteVitesse;
        }
        public void CarteForce()
        {
            personnage.Force -= constantesLoot.SortCarteForce;
        }
        public void CarteVision()
        {
            personnage.Vision -= constantesLoot.SortCarteVision;
        }
        public void CarteTeleportation(Point positionArrive)
        {
            personnage.Position = positionArrive;
        }
    }
}