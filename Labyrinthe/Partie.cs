using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MazeDll;

namespace Labyrinthe
{
    public class Partie
    {

        public static int hauteur = 51, largeur = 51;
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

            IsClient = false;
            /*if (false)
                IsClient = true;
            else
                IsClient = false;*/

            laby = ConstructionLabyrinthe();
            laby.NouveauxObjets();
        }

        public static MyLabyrinthe ConstructionLabyrinthe()
        {
            /*    if (IsClient)
                      //On interroge le serveur et on récupère son labyrinthe
                  else
                  {}
            */

            MyLabyrinthe laby = new Labyrinthe.MyLabyrinthe();

            int[,] tempMaze = new int[hauteur, largeur];

            Maze.InitialiseTableau(tempMaze, hauteur, largeur);

            Maze.GenereCheminPrimaire(tempMaze, hauteur, largeur, 1, 0);

            laby.ConversionMaze(tempMaze);

            return laby;
        }

        public Loot TryRamassageObjet(Joueur joueur)
        {
            if (IsClient)
                //Interrogation serveur et récupération du LOOT
                return null;
            else
            {
                Loot loot;
                if (joueur.Laby.Liste.TryGetValue(joueur.Position.ToString(), out loot))
                {
                    joueur.Laby.Liste.Remove(joueur.Position.ToString());
                    
                    //Prévenir les autres de remove cet objet !
                    return loot;
                }

                else return null;
            }            
        }
    }
}
