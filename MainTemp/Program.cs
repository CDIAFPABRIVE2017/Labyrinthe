using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labyrinthe;
using MazeDll;
using System.Threading;
using System.Diagnostics;

namespace MainTemp
{
    class Program
    {
        public static Partie partie;

        static void Main(string[] args)
        {
            partie = new Partie();
            partie.Lancement();
            Direction dir;
            AffichageConsole.AffichageLaby(partie.joueur.Laby, partie.joueur);

            while (true)
            {
                dir = ChangeCaseListener();
                if (dir != Direction.AUTRE)
                {
                    partie.DeplacementJoueur(dir);
                    Loot loot = partie.TryRamassageObjet(partie.joueur.Laby, partie.joueur.Position);
                    if (!Loot.IsNull(loot))
                    {
                        partie.joueur.SubirEffet(loot);
                        partie.joueur.Inventaire.Add(loot);
                    }

                }

                AffichageConsole.AffichageDeuxCartes(partie.joueur.Laby, partie.joueur);
            }
        }

        public static Direction ChangeCaseListener()
        {

            //Mode console only
            ConsoleKey saisie = Console.ReadKey().Key;
            Console.WriteLine(saisie.ToString());
            switch (saisie)
            {
                case ConsoleKey.UpArrow:
                    return Direction.HAUT;

                case ConsoleKey.DownArrow:
                    return Direction.BAS;

                case ConsoleKey.RightArrow:
                    return Direction.DROITE;

                case ConsoleKey.LeftArrow:
                    return Direction.GAUCHE;

                default:
                    return Direction.AUTRE;
            }
        }
    }
}
