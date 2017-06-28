using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labyrinthe
{
    public class Joueur
    {
        Point _position;
        int _vision;
        decimal _vitesse, _force;
        Inventaire _inventaire;

        enum Direction
        {
            HAUT = 0,
            DROITE = 1,
            BAS = 2,
            GAUCHE = 3
        }

        void Deplacmeent()
        {
            Direction d = Direction.DROITE;
            if (ChangementCase(d))
            {
                // Modif position
                // Interroger server
                // liste = Server.input(_position) ?
            }
        }

        /// <summary>
        /// Retourne si le mouvement peut être fait
        /// </summary>
        /// <param name="d">Direction</param>
        /// <returns></returns>
        bool ChangementCase(Direction d)
        {
            switch (d)
            {
                case Direction.HAUT:
                    // Aller en hauf
                    // Appeler le Laby local pour les murs
                    break;
                case Direction.DROITE:
                    // Aller à droite
                    break;
                case Direction.BAS:
                    // Aller en bas
                    break;
                case Direction.GAUCHE:
                    // Aller à gauche
                    break;
            }
            return true;
        }

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
