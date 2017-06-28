using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Labyrinthe
{
    internal class Loot_ObjetChoix : Loot
    {
        MyLabyrinthe murLabyrinthe = new MyLabyrinthe();
        public void ObjetPic(Direction dir,Point position)
        {
            switch (dir)
            {
                case Direction.HAUT:
                   // position.Y - 1;
                    break;
                case Direction.DROITE:
                    break;
                case Direction.BAS:
                    break;
                case Direction.GAUCHE:
                    break;
                default:
                    break;
            }
        }

      
    }
}