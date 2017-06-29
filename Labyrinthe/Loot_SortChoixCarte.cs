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
        TypeSort _sortCarte = new TypeSort();

        internal TypeSort SortCarte
        {
            get
            {
                return _sortCarte;
            }

            set
            {
                _sortCarte = value;
            }
        }

        public void ChoixSortCarte(TypeSort sort)
        {
            switch (sort)
            {
                case TypeSort.SortVitesse:
                    CarteVitesse();
                    break;
                case TypeSort.SortForce:
                    CarteForce();
                    break;
                case TypeSort.SortVision:
                    CarteVision();
                    break;
                case TypeSort.SortTeleportation:
                    break;
                default:
                    break;
            }
        }

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