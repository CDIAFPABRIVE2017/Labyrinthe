using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Labyrinthe
{
    public class Utilitaire
    {
        static Random nbrAleatoire = new Random();

        /// <summary>
        /// Renvoie un nombre aléatoire défini entre des valeurs mini et maxi
        /// </summary>
        /// <param name="nbrMin"></param>
        /// <param name="nbrMax"></param>
        /// <returns></returns>
        public static int RandNombre(int nbrMin, int nbrMax)
        {
            return nbrAleatoire.Next(nbrMin, nbrMax);
        }

        /// <summary>
        /// Renvoie un point aléatoire défini dans la valeur de hauteur maxi et une valeur de largeur maxi
        /// </summary>
        /// <param name="hauteur"></param>
        /// <param name="largeur"></param>
        /// <returns></returns>
        public static Point PositionAleatoire(int hauteur, int largeur)
        {
            Point position = new Point();

            position.X = Utilitaire.RandNombre(0, largeur);
            position.Y = Utilitaire.RandNombre(0, hauteur);

            return position;
        }
    }

}