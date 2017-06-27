using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labyrinthe
{
    enum Direction
    {
        HAUT = 0,
        DROITE = 1,
        BAS = 2,
        GAUCHE = 3
    }
    public class Joueur
    {
        Point _position;
        int _vision;
        decimal _vitesse, _force;
        Inventaire _inventaire;



        void Deplacement(Direction d)
        {
            if (ChangementCase(d))
            {
                // Modif position
                // Notifier serveur du déplacement
                // Le serveur répond avec l'éventuel objet ou rencontre, ou vide...
                // On réagit en conséquence.
            }
        }

        /// <summary>
        /// Retourne si le mouvement peut être fait
        /// </summary>
        /// <param name="d">Direction</param>
        /// <returns></returns>
        
        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int Vision
        {
            get { return _vision; }
            set { _vision = value; }
        }

        public decimal Vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }

        public decimal Force
        {
            get { return _force; }
            set { _force = value; }
        }

        internal Inventaire Inventaire
        {
            get { return _inventaire; }
            set { _inventaire = value;}
        }
    }
}
