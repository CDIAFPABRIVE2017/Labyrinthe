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

        static void Main(string[] args)
        {
            partie.Lancement();
        }

        public static void Deplacement(Direction dir)
        {
            Loot loot;

            if (dir != Direction.AUTRE)
            {
                //C>S : JE PEUX BOUGER ?
                //SI S>C NON :
                //RENCONTRE !
                //SI S>C OUI :
                partie.joueur.Deplacement(dir);
                loot = partie.TryRamassageObjet(partie.joueur.Laby, partie.joueur.Position);
                //C>S J'AI BOUGE ICI
                //SERVEUR UPDATE LA POSITION ET REGARDE SI OBJET
                //SI OBJET, LE REMOVE ET S>C ORDONNE DE REMOVE AUX AUTRES JOUEURS


                //Mettre l'affichage voulu...
                AffichageConsole.AffichageStandard(partie.joueur.Laby,partie.joueur);

                if (!Loot.IsNull(loot))
                {
                    partie.joueur.Inventaire.Add(loot);
                    partie.joueur.SubirEffet(loot);

                    //Mode console only
                    Console.WriteLine("Loooot ! {0}", loot.name);
                }
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
