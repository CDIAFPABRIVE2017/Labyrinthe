﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
//using System.Windows;

namespace Labyrinthe
{
    public enum TypeSort
    {
        Immediat = 0,
        Potion = 1,
        Carte = 2
    }

    public enum NomSort
    {
        Force = 0,
        Vitesse = 1,
        Combine = 2,
        Teleportation = 3,
        Vision = 4
    }

    public class Loot_Sort : Loot
    {
        //ATTRIBUTS
        private int _force = 0;
        private int _vitesse = 0;
        private Point _position;
        private int _vision = 1;
        private NomSort _nomSor = new NomSort();
        private TypeSort _typeSor = new TypeSort();
        static Random ale = new Random();

        // ACCESSEURS
        #region ACCESSEURS
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

        public TypeSort TypeSor
        {
            get
            {
                return _typeSor;
            }
            set
            {
                _typeSor = value;
            }

        }

        public NomSort NomSor
        {
            get
            {
                return _nomSor;
            }

            set
            {
                _nomSor = value;
            }

        }
        #endregion

        //METHODES
        #region METHODES
        /// <summary>
        /// Methode qui affect les paramètres d'un sort au personnage en argument avec gestion séparer de la téléportation
        /// </summary>
        /// <param name="x"></param>
        public void Affect(Joueur x)
        {
            Joueur y = x;

            if (this.NomSor == NomSort.Teleportation)
            {
                y.Position = Position;
            }
            else
            {
                y.Force += Force;
                y.Vitesse += Vitesse;
                y.Vision += Vision;
            }
        }

        /// <summary>
        /// Methode qui affect les paramètres d'un sort au personnage en argument avec gestion séparer de la téléportation
        /// </summary>
        /// <param name="x"></param>
        public void AffectEtre(Loot_Etre x)
        {
            Loot_Etre y = x;

            if (this.NomSor == NomSort.Teleportation)
            {
                y.Position = Position;
            }
            else
            {
                y.Force += Force;

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
            //Loot_Sort so = new Loot_Sort();
            Point po = new Point();
            po.X = 0;
            po.Y = 0;

            switch (nomSort)
            {
                case NomSort.Vitesse: this.Vitesse += RandNombre(1, 10); this.NomSor = nomSort; break;
                case NomSort.Force: this.Force += RandNombre(1, 10); this.NomSor = nomSort; break;
                case NomSort.Teleportation: this.Position = po; this.NomSor = nomSort; break;
                case NomSort.Combine: this.Force -= RandNombre(1, 10); this.Vitesse -= RandNombre(1, 10); this.NomSor = nomSort; break;
                case NomSort.Vision: this.Vision += RandNombre(1, 3); this.NomSor = nomSort; break;
                default: break;
            }
            return this;
        }

        /// <summary>
        /// renvoie un sort dont le type et la valeur sont définies
        /// </summary>
        /// <param name="nomSort"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public Loot_Sort CreationSort(NomSort nomSort, int val)
        {
            //Loot_Sort so = new Loot_Sort();
            Point po = new Point();
            po.X = 0;
            po.Y = 0;

            switch (nomSort)
            {
                case NomSort.Vitesse: this.Vitesse += val; this.NomSor = nomSort; break;
                case NomSort.Force: this.Force += val; this.NomSor = nomSort; break;
                case NomSort.Teleportation: this.Position = po; this.NomSor = nomSort; break;
                case NomSort.Combine: this.Force -= val; this.Vitesse -= val; this.NomSor = nomSort; break;
                case NomSort.Vision: this.Vision += val; this.NomSor = nomSort; break;
                default: break;
            }
            return this;
        }

        /// <summary>
        /// renvoie un sort dont le type et le nom sont définie en argument et dont les valeurs sont issue du fichier des settings
        /// </summary>
        /// <param name="type"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Loot_Sort CreationSort(TypeSort type, NomSort nom)
        {
            Loot_Sort sort = new Loot_Sort();

            switch (type)
            {
                case TypeSort.Immediat:
                    switch (nom)
                    {
                        case NomSort.Force:
                             Force = constantesLoot.SortForce;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Vitesse:
                            Vitesse = constantesLoot.SortVitesse;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Combine:
                            Force = constantesLoot.SortForce;
                            Vitesse = constantesLoot.SortVitesse;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Teleportation:
                            Position = _position;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Vision:
                            Vision = constantesLoot.SortVision;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                    }
                    break;
                case TypeSort.Potion:
                    switch (nom)
                    {
                        case NomSort.Force:
                            Force = constantesLoot.SortPotionForce;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Vitesse:
                            Vitesse = constantesLoot.SortPotionVitesse;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Combine:
                            Force = constantesLoot.SortPotionForce;
                            Vitesse = constantesLoot.SortPotionVitesse;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Teleportation:
                            Position = _position;
                            break;
                        case NomSort.Vision:
                            Vision = constantesLoot.SortPotionVision;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                    }
                    break;
                case TypeSort.Carte:
                    switch (nom)
                    {
                        case NomSort.Force:
                            Force = constantesLoot.SortCarteForce;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Vitesse:
                            Vitesse = constantesLoot.SortCarteVitesse;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Combine:
                            Force = constantesLoot.SortCarteForce;
                            Vitesse = constantesLoot.SortCarteVitesse;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Teleportation:
                            Position = _position;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                        case NomSort.Vision:
                            Vision = constantesLoot.SortCarteVision;
                            this.NomSor = nom;
                            this.TypeSor = type;
                            break;
                    }
                    break;
                default:
                    return null;
            }
            return sort;
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
        #endregion
    }


}
