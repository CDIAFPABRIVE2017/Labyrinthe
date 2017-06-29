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

            joueur.Laby = partie.laby;
            joueur.InitialisationCarte();
            joueur.Position = new Point(1, 1);
            while (true)
            {
                ChangeCaseListener();
                loot = partie.TryRamassageObjet(joueur);
                AffichageConsole.AffichageLaby(partie.laby, joueur);
                if (!Loot.IsNull(loot))
                {
                    joueur.Inventaire.Add(loot);
                    Console.WriteLine("Loooot !");
                    foreach (Loot item in joueur.Inventaire)
                        Console.WriteLine(item.name);
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
