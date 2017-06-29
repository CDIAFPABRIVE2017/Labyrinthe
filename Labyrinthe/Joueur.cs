﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labyrinthe
{
    public enum Direction
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
        Inventaire _inventaire = new Inventaire();
        MyLabyrinthe _tableau = Partie.ConstructionLabyrinthe();


        public void Deplacement(Direction d)
        {
            if (!isMur(d))
            {
                switch (d)
                {
                    case Direction.HAUT:
                        Position = new Point(Position.X, Position.Y - 1);
                        break;
                    case Direction.DROITE:
                        Position = new Point(Position.X + 1, Position.Y);
                        break;
                    case Direction.BAS:
                        Position = new Point(Position.X, Position.Y + 1);
                        break;
                    case Direction.GAUCHE:
                        Position = new Point(Position.X - 1, Position.Y);
                        break;
                }
            }
        }

        /// <summary>
        /// Retourne si le mouvement peut être fait
        /// </summary>
        /// <param name="d">Direction</param>
        /// <returns></returns>
        public bool isMur(Direction d)
        {
            switch (d)
            {
                case Direction.HAUT:
                    if (Position.Y == 0)
                        return true;
                    else return (Laby.Tableau[(int)Position.X, (int)Position.Y - 1]);
                case Direction.DROITE:
                    if (Position.X == Laby.Tableau.GetLength(0)-1)
                        return true;
                    else return (Laby.Tableau[(int)Position.X + 1, (int)Position.Y]);
                case Direction.BAS:
                    if (Position.Y == Laby.Tableau.GetLength(1)-1)
                        return true;
                    else return (Laby.Tableau[(int)Position.X, (int)Position.Y + 1]);
                case Direction.GAUCHE:
                    if (Position.X == 0)
                        return true;
                    else return (Laby.Tableau[(int)Position.X - 1, (int)Position.Y]);
            }
            return false;
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

        public Inventaire Inventaire
        {
            get { return _inventaire; }
            set { _inventaire = value;}
        }

        public MyLabyrinthe Laby
        {
            get
            {
                return _tableau;
            }

            set
            {
                _tableau = value;
            }
        }
    }
}
