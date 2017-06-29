using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MazeGenerator;

namespace Labyrinthe
{
    public class Partie
    {

        public static int hauteur, largeur;
        public static bool _isClient;
        public MyLabyrinthe laby;

        public bool IsClient
        {
            get
            {
                return _isClient;
            }

            set
            {
                _isClient = value;
            }
        }

        public void Lancement()
        {
            // Broadcast "serveur ?"
            //attend la réponse true sec

            if (/*on reçoit une réponse*/false)
                IsClient = true;
            else
                IsClient = false;

            laby = ConstructionLabyrinthe();
        }

        public static MyLabyrinthe ConstructionLabyrinthe()
        {
            /*  if (IsClient)
                  return null;
              //On interroge le serveur et on récupère son labyrinthe
              else
                  return new MyLabyrinthe();
              */



            ///Ca c'est juste pour le test.
            /*           MyLabyrinthe laby = new MyLabyrinthe();
                       laby.Laby = new bool[,] { { true, false, false, false, false, false, false, false, true, false }, { true, false, true, false, true, false, true, false, true, false }, { false, false, true, false, true, false, true, false, true, false }, { true, false, true, false, true, false, true, false, true, false }, { true, false, true, false, false, false, true, false, true, false }, { true, false, true, true, true, true, true, false, true, false }, { true, false, true, false, false, false, false, false, false, false }, { true, true, true, true, true, true, true, true, true, false }, { true, true, true, true, true, true, true, true, true, false }, { true, true, true, true, true, true, true, true, true, false } };
                       laby.Liste = new DicoLoot();
                       laby.Liste.Add(new Point(1, 3), new Labyrinthe.Loot("Un gros bidule"));
                       laby.Liste.Add(new Point(4, 4), new Labyrinthe.Loot("Une potion de vitesse"));
                       laby.Liste.Add(new Point(6, 6), new Labyrinthe.Loot("une GROSSE EPEE"));
           */

            MyLabyrinthe laby = new Labyrinthe.MyLabyrinthe();
            int[,] tempMaze = new int[hauteur, largeur];
            Maze.InitialiseTableau(tempMaze, hauteur, largeur);
            Maze.GenereCheminPrimaire(tempMaze, hauteur, largeur, 1, 0);
            for (int i = 0;i<)


            return laby;
        }

        public Loot TryRamassageObjet(Point p)
        {
            if (IsClient)
                //Interrogation serveur et récupération du LOOT
                return null;
            else
            {
                Loot loot;
                if (laby.Liste.TryGetValue(p, out loot))
                {
                    laby.Liste.Remove(p);
                    
                    //Prévenir les autres de remove cet objet !
                    return loot;
                }

                else return null;
            }            
        }
    }
}
