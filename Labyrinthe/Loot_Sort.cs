using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using System.Windows;

namespace Labyrinthe
{
    public enum NomSort
    {
        Force = 0,
        Vitesse = 1,
        Combine = 2,
        Teleportation = 3
    };

    public class Loot_Sort : Loot
    {
        //ATTRIBUTS
        private int _force = 0;
        private int _vitesse = 0;
        private Point _position;
        private NomSort _name = new NomSort();
        static Random ale = new Random();

        // ACCESSEURS
        public int Force
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

        public int Vitesse
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

        public NomSort Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

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

        //METHODES
        /// <summary>
        /// Methode qui affect les paramètres d'un sort au personnage en argument avec gestion séparer de la téléportation
        /// </summary>
        /// <param name="x"></param>
        public void Affect(Joueur x)
        {
            Joueur y = x;

            if (this.Name == NomSort.Teleportation)
            {
                y.Position = Position;
            }
            else
            {
                y.Force += Force;
                y.Vitesse += Vitesse;
            }
        }

        /// <summary>
        /// Renvoie le nombre de valeur contenue dans l'Enum "NomSort"
        /// </summary>
        /// <returns></returns>
        public static int NombreTypeSort()
        {
            return Enum.GetNames(typeof(NomSort)).Length;
        }

        /// <summary>
        /// renvoie un sort dont le type est définie en argument avec des valeurs aléatoires
        /// </summary>
        /// <param name="nomSort"></param>
        /// <returns></returns>
        public Loot_Sort CreationSort(NomSort nomSort)
        {
            Loot_Sort so = new Loot_Sort();
            Point po = new Point();
            po.X = 0;
            po.Y = 0;

            switch (nomSort)
            {
                case NomSort.Vitesse: so.Vitesse += RandNombre(1, 10); so.Name = nomSort; break;
                case NomSort.Force: so.Force += RandNombre(1, 10); so.Name = nomSort; break;
                case NomSort.Teleportation: so.Position = po; so.Name = nomSort; break;
                case NomSort.Combine: so.Force -= RandNombre(1, 10); so.Vitesse -= RandNombre(1, 10); so.Name = nomSort; break;
                default: break;
            }
            return so;
        }

        /// <summary>
        /// renvoie un sort dont le type et la valeur sont définies
        /// </summary>
        /// <param name="nomSort"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public Loot_Sort CreationSort(NomSort nomSort, int val)
        {
            //Sort so = new Sort();
            Point po = new Point();
            po.X = 0;
            po.Y = 0;

            switch (nomSort)
            {
                case NomSort.Vitesse: this.Vitesse += val; this.Name = nomSort; break;
                case NomSort.Force: this.Force += val; this.Name = nomSort; break;
                case NomSort.Teleportation: this.Position = po; this.Name = nomSort; break;
                case NomSort.Combine: this.Force -= val; this.Vitesse -= val; this.Name = nomSort; break;
                default: break;
            }
            return this;
        }

        /// <summary>
        /// Renvoie aleatoirement un type de sort 
        /// </summary>
        /// <returns></returns>
        public Loot_Sort CreationSortAleatoire()
        {
            Loot_Sort so = new Loot_Sort();
            return so.CreationSort((NomSort)(so.RandNombre(0, Loot_Sort.NombreTypeSort())));
        }

        /// <summary>
        /// Renvoie un nombre aléatoire défini entre des valeurs mini et maxi
        /// </summary>
        /// <param name="nbrMin"></param>
        /// <param name="nbrMax"></param>
        /// <returns></returns>
        private int RandNombre(int nbrMin, int nbrMax)
        {
            return ale.Next(nbrMin, nbrMax);
        }
    }
}
