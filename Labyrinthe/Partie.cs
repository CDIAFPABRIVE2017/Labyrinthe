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
            rezo.DataReceived += Reception;
            joueur.Laby = ConstructionLabyrinthe();
            joueur.InitialisationCarte();
            askPosition();
        }
        #region Réception et réactions
        private void Reception(string sender, object data)
        {

            //Si on reçoit un point
            if (data.GetType() == typeof(Point))
            {
                //On enlève l'objet à l'endroit correspondant
                Loot loot = TryRamassageObjet(joueur.Laby, (Point)data);
                //Et si on est serveur on envoie le point pour que les autres joueurs l'enlèvent, et on envoie la position du joueur pour qu'elle soit actualisée chez les autres
                if (rezo.IsServer)
                {
                    if (loot != null)
                        rezo.SendData((Point)data);
                    rezo.SendData(new PositionJoueur(sender, (Point)data));
                }

            }

            else if (data.GetType() == typeof(MyLabyrinthe))
                joueur.Laby = (MyLabyrinthe)data;

            else if (data.GetType() == typeof(string))
            {
                if ((string)data == "Labyrinthe")
                    SendLabyrinthe(sender);
                else if ((string)data == "Position")
                { }
            }

            else if (data.GetType() == typeof(PositionJoueur))
                if (joueur.Position == new Point(0, 0))
                    joueur.Position = ((PositionJoueur)data).Position;
                else
                    UpdatePositions((PositionJoueur)data);


                    
        }
        public void askPosition()
        {
            rezo.SendData("Position");
        }

        private void SendLabyrinthe(string sender)
        {
            rezo.SendData(joueur.Laby, sender);
        }

        private void UpdatePositions(PositionJoueur posJ)
        {
            joueur.Laby.Joueurs.Remove(posJ.Position);
            joueur.Laby.Joueurs.Add(posJ.Position, posJ.Adresse);
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

                laby.CreationListLoot();

                return laby;
            }
            else
            {
                //demande un laby au serveur
                rezo.SendData("Labyrinthe");
                return laby;
            }
        } 

        public Loot TryRamassageObjet(MyLabyrinthe laby, Point point)
        {
            Loot loot;
            if (laby.Liste.TryGetValue(point.ToString(), out loot))
            {
                laby.Liste.Remove(point.ToString());
                return loot;
            }
            else return null;
        }            
    }
}
