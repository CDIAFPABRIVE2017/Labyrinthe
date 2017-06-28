using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labyrinthe;

namespace Labyrinthe
{

    enum TypeUser
    {
        Client = 0,
        Serveur = 1
    }
    class MyLabyrinthe
    {
        bool[,] _laby; //Le labyrinthe proprement dit. bool ou int ?
        DicoLoot _liste;
        TypeUser _role;



        /// <summary>
        /// Retourne si une case donnée est un mur
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool isMur(Point position)
        {
            return _laby[(int)position.X, (int)position.Y];
        }

        bool ChangementCase(Direction d)
        {
            switch (d)
            {
                case Direction.HAUT:
                    // Aller en haut
                    // Appeler le Laby local pour les murs
                    //Par exemple :
                    return monLaby.isMur(new Point(this.Position.X, this.Position.Y + 1));
                    break;
                case Direction.DROITE:
                    // Aller à droite
                    return monLaby.isMur(new Point(this.Position.X + 1, this.Position.Y));
                    break;
                case Direction.BAS:
                    // Aller en bas
                    return monLaby.isMur(new Point(this.Position.X, this.Position.Y - 1));
                    break;
                case Direction.GAUCHE:
                    // Aller à gauche
                    return monLaby.isMur(new Point(this.Position.X - 1, this.Position.Y));
                    break;
            }
            return true;
        }


        public bool[,] Laby
        {
            get
            {
                return _laby;
            }

            set
            {
                _laby = value;
            }
        }

        public DicoLoot Liste
        {
            get
            {
                return _liste;
            }

            set
            {
                _liste = value;
            }
        }


        internal TypeUser ClientServeur
        {
            get
            {
                return _role;
            }

            set
            {
                _role = value;
            }
        }
    }
}
