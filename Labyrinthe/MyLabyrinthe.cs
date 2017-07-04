﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labyrinthe
{
    public class MyLabyrinthe
    {
        bool[,] _tableau; //Le labyrinthe proprement dit. bool ou int ?
        DicoLoot _liste;

        public void ModifierLabyrinthe(int i, int j, bool val)
        {
            if (i>=0 && j>= 0 && i<Tableau.GetLength(0) && j<Tableau.GetLength(1))
                _tableau[i, j] = val;
        }
        public bool[,] Tableau
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

        public void ConversionMaze(int[,] maze)
        {
            this.Tableau = new bool[maze.GetLength(0), maze.GetLength(1)];

            for (int j = 0; j < maze.GetLength(1); j++)
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    switch (maze[j, i])
                    {
                        case 0:
                            ModifierLabyrinthe(i, j, false);
                            break;
                        case 1:
                            ModifierLabyrinthe(i, j, true);
                            break;
                        default:
                            ModifierLabyrinthe(i, j, false);
                            Point point = new Point(i, j);
                            Loot loot = new Labyrinthe.Loot("random");
                            Liste.Add(point,loot);
                            break;
                    }
                }
        }

        public void NouveauxObjets()
        {
            int nbPilulesVision = Properties.Settings.Default.nbPilulesVision;
            int nbClés = Properties.Settings.Default.nbClés;
            int nbPilulesForce = Properties.Settings.Default.nbPilulesForce;
            int nbCartes = Properties.Settings.Default.nbCartes;

            for (int i = 0; i < nbPilulesVision; i++)
                Liste.Add(CaseVide(), new Loot("Pilule de vision"));
            for (int i = 0; i < nbClés; i++)
                Liste.Add(CaseVide(), new Loot("Clé"));
            for (int i = 0; i < nbPilulesForce; i++)
                Liste.Add(CaseVide(), new Loot("Pilule de force"));
            for (int i = 0; i < nbCartes; i++)
                Liste.Add(CaseVide(), new Loot("Carte"));
        }

        public Point CaseVide()
        {
            Random rnd = new Random();
            int x, y;
            Loot test;

            do
            {
                x = rnd.Next(Tableau.GetLength(0));
                y = rnd.Next(Tableau.GetLength(1));
            }
            while ((Tableau[x, y]) || (Liste.TryGetValue((new Point(x, y)).ToString(), out test)));

            return (new Point(x, y));
        }

        public override string ToString()
        {
            Loot loot;
            string retour = "";

            retour += String.Format("{0}\n{1}\n",Tableau.GetLength(0), Tableau.GetLength(1));
            for (int j = 0; j < Tableau.GetLength(0); j++)
                for (int i = 0; i < Tableau.GetLength(1); i++)
                {
                    retour += String.Format("{0};", (Tableau[i, j]) ? 1 : 0);
                    retour += "\n";
                }
            retour += "\n";

            foreach (string item in Liste.Keys)
            {
                Liste.TryGetValue(item, out loot);
                retour += String.Format("{0};{1}\n", item, loot);
            }

            return retour; 
        }

        public MyLabyrinthe() { _liste = new DicoLoot(); }
    }
}
