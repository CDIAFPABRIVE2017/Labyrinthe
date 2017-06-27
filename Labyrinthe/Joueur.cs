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

        public Point Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public int Vision
        {
            get
            {
                return _vision;
            }

            set
            {
                _vision = value;
            }
        }

        public decimal Vitesse
        {
            get
            {
                return _vitesse;
            }

            set
            {
                _vitesse = value;
            }
        }

        public decimal Force
        {
            get
            {
                return _force;
            }

            set
            {
                _force = value;
            }
        }

        internal Inventaire Inventaire
        {
            get
            {
                return _inventaire;
            }

            set
            {
                _inventaire = value;
            }
        }
    }
}
