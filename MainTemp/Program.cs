using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labyrinthe;

namespace MainTemp
{
    class Program
    {
        public static Partie partie = new Partie();
        public static Joueur joueur = new Joueur();

        static void Main(string[] args)
        {
            Loot loot;
            partie.Lancement();
            Random rnd = new Random();

            joueur.Laby = partie.laby;
            joueur.InitialisationCarte();
            joueur.Position = new Point(rnd.Next(50),rnd.Next(50));
            while (true)
            {
                ChangeCaseListener();
                loot = partie.TryRamassageObjet(joueur);
                //Mettre l'affichage voulu...
                AffichageConsole.AffichageDeuxCartes(partie.laby, joueur);
                if (!Loot.IsNull(loot))
                {
                    joueur.Inventaire.Add(loot);
                    joueur.SubirEffet(loot);
                    Console.WriteLine("Loooot !");
                    foreach (Loot item in joueur.Inventaire)
                        Console.WriteLine(item.Name);
                }

            }


              
        }

        public static void ChangeCaseListener()
        {
            ConsoleKey saisie = Console.ReadKey().Key;
            Console.WriteLine(saisie.ToString());
            switch (saisie)
            {
                case ConsoleKey.UpArrow:
                    joueur.Deplacement(Direction.HAUT);
                    break;
                case ConsoleKey.DownArrow:
                    joueur.Deplacement(Direction.BAS);
                    break;
                case ConsoleKey.RightArrow:
                    joueur.Deplacement(Direction.DROITE);
                    break;
                case ConsoleKey.LeftArrow:
                    joueur.Deplacement(Direction.GAUCHE);
                    break;
                default:
                    break;
            }
        }
    }
}
