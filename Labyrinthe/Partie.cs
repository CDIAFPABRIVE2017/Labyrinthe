using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MazeDll;
using ReseauDLL;

namespace Labyrinthe
{
    public class Partie
    {

        public static int hauteur = 51, largeur = 51;
        public Joueur joueur = new Joueur();
        public Reseau rezo = new Reseau();



          public void Lancement()
        {
            rezo.Initialize();
            rezo.DataReceived += Reception;
            joueur.Laby = ConstructionLabyrinthe();

        }
        #region Réception et réactions
        private void Reception(string sender, object data)
        {
            string[] donnees = ((string)data).Split('/');


            if (data.GetType() == typeof(Point))
            {
                if (rezo.IsServer)
                {

                }
            }
            else if (data.GetType() == typeof(MyLabyrinthe))
                SendLabyrinthe(sender);                    
        }

        private void SendLabyrinthe(string sender)
        {
            rezo.SendData(joueur.Laby, sender);
        }

        private void RemoveObjet(Point p)
        {
            joueur.Laby.Liste.Remove(p.ToString());
        }

        #endregion

        public MyLabyrinthe ConstructionLabyrinthe()
        {
            MyLabyrinthe laby = new Labyrinthe.MyLabyrinthe();
            if (rezo.IsServer)
            {
                int[,] tempMaze = new int[hauteur, largeur];

                Maze.InitialiseTableau(tempMaze, hauteur, largeur);

                Maze.GenereCheminPrimaire(tempMaze, hauteur, largeur, 1, 0);

                laby.ConversionMaze(tempMaze);

                laby.NouveauxObjets();

                return laby;
            }
            else
            {
                //demande un laby au serveur
                rezo.SendData("Labyrinthe");
                return laby;
            }
        }

        public Loot TryRamassageObjet(Joueur joueur)
        {
                Loot loot;
                if (joueur.Laby.Liste.TryGetValue(joueur.Position.ToString(), out loot))
                {
                    joueur.Laby.Liste.Remove(joueur.Position.ToString());
                    if (rezo.IsServer)
                        //Si on est serveur il faut s'occuper soi-même de prévenir les autres. Si on n'est pas serveur, le simple fait de s'être déplacé provoquera le message du serveur.
                        rezo.SendData(String.Format("RemoveObjet/{0};{1}", joueur.Position.X, joueur.Position.Y));
                    return loot;
                }
                else return null;
        }            
    }
}
