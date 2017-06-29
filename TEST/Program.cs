using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinthe;
using System.Windows;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDeplacement();
        }

        public static void TestDeplacement()
        {
            Joueur joueur = new Joueur();
            bool[,] tab = new bool[10, 10];
            bool test;
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    tab[i, j] = false;
            joueur.Laby = Partie.ConstructionLabyrinthe();
            joueur.Laby.Laby = tab;


            Console.WriteLine("Bords :");
            //Test 1
            joueur.Position = new Point(0, 0);
            joueur.Deplacement(Direction.HAUT);
            test = (joueur.Position == new Point(0, 0));
            Console.WriteLine("Test n°1 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 2
            joueur.Position = new Point(0, 0);
            joueur.Deplacement(Direction.GAUCHE);
            test = (joueur.Position == new Point(0, 0));
            Console.WriteLine("Test n°2 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 3
            joueur.Position = new Point(tab.GetLength(0)-1, tab.GetLength(1)-1);
            joueur.Deplacement(Direction.HAUT);
            test = (joueur.Position == new Point(tab.GetLength(0)-1, tab.GetLength(1)-2));
            Console.WriteLine("Test n°3 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 4
            joueur.Position = new Point(tab.GetLength(0)-1, tab.GetLength(1)-1);
            joueur.Deplacement(Direction.DROITE);
            test = (joueur.Position == new Point(tab.GetLength(0)-1, tab.GetLength(1)-1));
            Console.WriteLine("Test n°4 : {0}", (test) ? "Validé !" : "Echoué !");

            Console.WriteLine("Déplacements :");
            //Test 5
            joueur.Position = new Point(5, 5);
            joueur.Deplacement(Direction.BAS);
            test = (joueur.Position == new Point(5, 6));
            Console.WriteLine("Test n°5 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 6
            joueur.Position = new Point(5, 5);
            joueur.Deplacement(Direction.HAUT);
            test = (joueur.Position == new Point(5, 4));
            Console.WriteLine("Test n°6 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 7
            joueur.Position = new Point(5, 5);
            joueur.Deplacement(Direction.GAUCHE);
            test = (joueur.Position == new Point(4, 5));
            Console.WriteLine("Test n°7 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 8
            joueur.Position = new Point(5, 5);
            joueur.Deplacement(Direction.DROITE);
            test = (joueur.Position == new Point(6, 5));
            Console.WriteLine("Test n°8 : {0}", (test) ? "Validé !" : "Echoué !");

            Console.WriteLine("Obstacles");

            //Test 9
            joueur.Position = new Point(5, 5);
            joueur.Laby.Laby[6, 5] = true;
            joueur.Deplacement(Direction.DROITE);
            test = (joueur.Position == new Point(5, 5));
            Console.WriteLine("Test n°9 : {0}", (test) ? "Validé !" : "Echoué !");

            //Test 10
            joueur.Position = new Point(5, 5);
            joueur.Laby.Laby[6, 5] = false;
            joueur.Laby.Laby
            joueur.Deplacement(Direction.DROITE);
            test = (joueur.Position == new Point(5, 5));
            Console.WriteLine("Test n°10 : {0}", (test) ? "Validé !" : "Echoué !");

            Console.ReadLine();
        }
    }
}
