using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinthe;

namespace MainTemp
{
    class Program
    {
        public static Partie partie = new Partie();
        public static Joueur joueur = new Joueur();
        public static event EventHandler<ChangementCaseEventArgs> changementCase;

        static void Main(string[] args)
        {
            Loot loot;
            partie.Lancement();
            while (true)
            {
                ChangeCaseListener();
                loot = partie.IsObjet(joueur.Position);
            }


              
        }

        public static void ChangeCaseListener()
        {
            switch (Console.ReadKey().Key)
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
