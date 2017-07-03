using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Labyrinthe;
using MazeDll;
using System.Threading;

namespace MainTemp
{
    class Program
    {
        public static Partie partie = new Partie();
        public static Joueur joueur = new Joueur();

        static void Main(string[] args)
        {
            partie.Lancement();
            Random rnd = new Random();
            Thread boucle = new Thread(new ThreadStart(BoucleJeu));
            Thread listener = new Thread(new ThreadStart(Listen));

            joueur.Laby = partie.laby;
            joueur.InitialisationCarte();
            joueur.askPosition();

            boucle.Start();
            listener.Start();

        }

        public static void Listen()
        {

        }

        public static void BoucleJeu()
        {
            Loot loot;
            do
            {
                Direction dir = ChangeCaseListener();
                if (dir != Direction.AUTRE)
                {
                    //C>S : JE PEUX BOUGER ?
                    //SI S>C NON :
                        //RENCONTRE !
                    //SI S>C OUI :
                    joueur.Deplacement(dir);
                    loot = partie.TryRamassageObjet(joueur);
                    //C>S J'AI BOUGE ICI
                    //SERVEUR UPDATE LA POSITION ET REGARDE SI OBJET
                    //SI OBJET, LE REMOVE ET S>C ORDONNE DE REMOVE AUX AUTRES JOUEURS


                    //Mettre l'affichage voulu...
                    AffichageConsole.AffichageStandard(partie.laby, joueur);

                    if (!Loot.IsNull(loot))
                    {
                        joueur.Inventaire.Add(loot);
                        joueur.SubirEffet(loot);

                        //Mode console only
                        Console.WriteLine("Loooot ! {0}",loot.name);
                    }
                }
            } while (true);
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
