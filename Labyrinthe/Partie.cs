using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MazeDll;
using ReseauDLL;
using System.Diagnostics;

namespace Labyrinthe
{
    public class Partie
    {

        public static int hauteur = 51, largeur = 51;
        public Joueur joueur = new Joueur();
        public Reseau rezo;
        public bool test = true;



        public void Lancement()
        {
            rezo = new Reseau();
            rezo.DataReceived += Reception;
            rezo.FinRechercheServer += Rezo_FinRechercheServer;
            while (test) { }
            Console.WriteLine("Connecté : {0}", rezo.IsServer ? "Serveur" : "Client");
            joueur.Laby = ConstructionLabyrinthe();
            joueur.InitialisationCarte();
            askPosition();
        }

        private void Rezo_FinRechercheServer(bool isserver)
        {
            test = false;
        }
        #region Réception et réactions
        private void Reception(string sender, object data)
        {
            Debug.WriteLine(sender);
            Debug.WriteLine(data.ToString());
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
            {
                joueur.Laby = (MyLabyrinthe)data;
                joueur.InitialisationCarte();
            }


            else if (data.GetType() == typeof(string))
            {
                if ((string)data == "Labyrinthe")
                    SendLabyrinthe(sender);
                else if ((string)data == "Position")
                {
                    EnvoiePosition(sender);
                }
            }

            else if (data.GetType() == typeof(PositionJoueur))
                if (joueur.Position == new Point(0, 0))
                {
                    joueur.Position = ((PositionJoueur)data).Position;
                    test = false;
                }

                else
                    UpdatePositions((PositionJoueur)data);



        }

        public void DeplacementJoueur(Direction dir)
        {
            joueur.Deplacement(dir);
            rezo.SendData(joueur.Position);
        }

        //Ouais c'est moche parce que ça marche que pour le jeu jusqu'à 4, au-delà c'est random.
        //Mais ça fait que chacun démarre à peu près dans un coin. Ah et si y a pas de place libre, boucle infinie.
        public void EnvoiePosition(string sender)
        {
            Point point;
            switch (rezo.Clients.Count)
            {
                case 1:
                    do
                    {
                        point = joueur.Laby.CaseVide();
                    } while (point.X >= joueur.Laby.Tableau.GetLength(0) * 3 / 4 && point.Y >= joueur.Laby.Tableau.GetLength(1) * 3 / 4);
                    break;
                case 2:
                    do
                    {
                        point = joueur.Laby.CaseVide();
                    } while (point.X <= joueur.Laby.Tableau.GetLength(0) / 4 && point.Y >= joueur.Laby.Tableau.GetLength(1) * 3 / 4);
                    break;
                case 3:
                    do
                    {
                        point = joueur.Laby.CaseVide();
                    } while (point.X >= joueur.Laby.Tableau.GetLength(0) * 3 / 4 && point.Y <= joueur.Laby.Tableau.GetLength(1) / 4);
                    break;
                default:
                    point = joueur.Laby.CaseVide();
                    break;
            }
            rezo.SendData(new PositionJoueur(sender, point), sender);
        }
        public void askPosition()
        {
            Random rnd = new Random();
            Point point;
            if (rezo.IsServer)
            {
                do
                {
                    point = joueur.Laby.CaseVide();
                } while (point.X <= joueur.Laby.Tableau.GetLength(0) / 4 && point.Y <= joueur.Laby.Tableau.GetLength(1) / 4);
                joueur.Position = point;
            }
            else
            {
                test = true;
                rezo.SendData("Position");
                while (test) { }
            }
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

        public Partie() { }
    }
}
