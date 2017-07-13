using System;
using System.Timers;
using System.Windows;


/* Prototype de gestion de sort
    */

namespace Labyrinthe
{

    class ProgramMain
    {
        #region VARIABLES STATIC
        static bool[,] tableau = {
            { false, false, false, true, false,false },
            { false, true, false, false, false,false },
            { true, false, false, false, false,false },
            { false, false, false, true, true,false },
            { false, true, false, false, false,false },
            { false, false, false, true, true,false }
        };
        static DicoLoot list = new DicoLoot();
        static double xpos = 0;
        static double ypos = 0;
        static Point posi = new Point(0, 0);
        static Joueur bob = new Joueur() { Force = 3, Vitesse = 3, Position = posi };
        static NomSort sortname /*= new NomSort()*/;   //Juste pour afficher le nom du sort
        static Loot_Sort sortInventaire = new Loot_Sort();
        #endregion

        static void Main(string[] args)
        {
           // Loot cle = Loot;
            Loot_Sort sor = new Loot_Sort();
            sor.CreationSort(NomSort.Force, 20);      //creation de sort
            bob.Inventaire.Add(sor);                  //Ajout dans l'inventaire
            Loot_Sort sor2 = new Loot_Sort();
            sor2.CreationSort(NomSort.Vitesse, 20);
            bob.Inventaire.Add(sor2);
            Loot_Sort sor3 = new Loot_Sort();
            sor3.CreationSort(NomSort.Vision, 20);
            bob.Inventaire.Add(sor3);
            Loot_ObjetCle cle = new Loot_ObjetCle() { name="cle1"};
            bob.Inventaire.Add(cle);
            Loot_Sort sor4 = new Loot_Sort();
            sor4.CreationSort(TypeSort.Potion,NomSort.Vision);
            bob.Inventaire.Add(sor4);
            string reponse = string.Empty;

            do
            {
                RemplissageDicoSort(tableau);
                Jeux();

                Console.WriteLine("Un autre essais (o)?");
                reponse = Console.ReadLine();
                list.Clear();
            } while (reponse == "o");
        }

        /// <summary>
        /// Afficher le tableau sous forme de "0" et "1" ainsi que le personnage avec "x"
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="pox"></param>
        /// <param name="poy"></param>
        static void Affichage(bool[,] tab, double pox, double poy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PROTOTYPE SORT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {

                    if (j == pox && i == poy)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("0");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        if (tab[i, j])
                        {
                            Console.Write("1");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("x");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }

                Console.WriteLine();
            }

        }

        /// <summary>
        /// Modification de la coordonnées du personnage par les touches de direction
        /// </summary>
        /// <returns></returns>
        static bool DeplacementPersonnage()
        {
            xpos = bob.Position.X;
            ypos = bob.Position.Y;

            var bouton = Console.ReadKey(false).Key;
            switch (bouton)
            {
                case ConsoleKey.UpArrow:
                    if (ypos > 0)
                    {
                        ypos--;
                    }
                    return true;
                case ConsoleKey.DownArrow:
                    if (ypos < tableau.GetLength(0) - 1)
                    {
                        ypos++;
                    }
                    return true;
                case ConsoleKey.LeftArrow:
                    if (xpos > 0)
                    {
                        xpos--;
                    }
                    return true;
                case ConsoleKey.RightArrow:
                    if (xpos < tableau.GetLength(1) - 1)
                    {
                        xpos++;
                    }
                    return true;
                case ConsoleKey.M:
                    MenuInventaire();
                    break;
                case ConsoleKey.Escape:
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Affiche le personnage dans le tableau ainsi que ces paramètres,applique le déplacement
        /// </summary>
        static void Jeux()
        {
            Timer cycle = new Timer();
            cycle.Enabled = true;
            cycle.Start();
            bool conti = true;

            while (conti)
            {
                Affichage(tableau, xpos, ypos);
                Console.WriteLine();
                Console.WriteLine("Coordonnées personnage:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" x: {0} / y: {1}", xpos, ypos);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("Personnage:", bob.Force, bob.Vitesse);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-Force={0}\n-Vitesse={1}\n-Vision={2}", bob.Force, bob.Vitesse, bob.Vision);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("Vous avez subit un sort: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}", sortname.ToString());
                Console.ForegroundColor = ConsoleColor.White;

                conti = DeplacementPersonnage();

                posi.X = xpos;
                posi.Y = ypos;
                bob.Position = posi;

                ApplicationSort(bob);

                cycle.Interval = (1000);
            }
        }

        /// <summary>
        /// Verification de la présence d'un sort et application au personnage
        /// </summary>
        /// <param name="perso"></param>
        static void ApplicationSort(Joueur perso)
        {
            Loot_Sort sor = new Loot_Sort();
            Console.WriteLine("Un objet Trouve");
            Point poin = new Point(xpos, ypos);

            if (list.ContainsKey(poin))
            {
                sor =(Loot_Sort)(list.GetLoot(poin));
                sor.Affect(perso);
                sortname = sor.NomSort;
            }
        }

        /// <summary>
        /// Generation des sort en fonction du true dans le tableau et ajout du sort dans le dictionnaire
        /// </summary>
        /// <param name="tab"></param>
        public static void RemplissageDicoSort(bool[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j])
                    {
                        Point pt = new Point();
                        pt.X = i;
                        pt.Y = j;

                        list.Add(pt, sortInventaire.CreationSortAleatoire());
                    }
                }
            }
        }

        /// <summary>
        /// Affiche l'inventaire et permet la selection d'un sort
        /// </summary>
        static void MenuInventaire()
        {
            string reponse = string.Empty;
            int repconv = 0;
            Loot_Sort sorinv = new Loot_Sort();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("INVENTAIRE");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("Personnage:");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-Force={0}\n-Vitesse={1}\n-Vision={2}", bob.Force, bob.Vitesse,bob.Vision);
            Console.WriteLine();
            try
            {
                if (bob.Inventaire.QuantiteLoot() != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < bob.Inventaire.QuantiteLoot(); i++)
                    {
                        Console.WriteLine("Le sort en {0} est de type {1}", i, bob.Inventaire.GetNomObjet(i));

                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.WriteLine("Quel sort voulez-vous?");
                    reponse = Console.ReadLine();
                    repconv = int.Parse(reponse);

                    if (repconv < bob.Inventaire.QuantiteLoot())
                    {
                        sorinv = (Loot_Sort)bob.Inventaire.GetSort(repconv);
                        sorinv.Affect(bob);
                        bob.Inventaire.EnleveLoot(repconv);

                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Personnage nouveau:", bob.Force, bob.Vitesse);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("-Force={0}\n-Vitesse={1}\n-Vision={2}", bob.Force, bob.Vitesse, bob.Vision);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine("Tapez sur une touche pour continuer");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Vous n'avez aucun sort. \n Tapez sur une touche pour continuer");
                Console.ReadKey();
            }

        }
    }
}

