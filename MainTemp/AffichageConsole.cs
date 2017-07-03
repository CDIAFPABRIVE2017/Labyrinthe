using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labyrinthe;
using System.Windows;

namespace MainTemp
{
    static class AffichageConsole
    {
        public static void AffichageStandard(MyLabyrinthe laby, Joueur joueur)
        {
            Loot loot;
            Console.Clear();

            for (int j = (int)joueur.Position.Y - joueur.Vision; j < (int)joueur.Position.Y + joueur.Vision + 1; j++)
            {
                for (int i = (int)joueur.Position.X - joueur.Vision; i < (int)joueur.Position.X + joueur.Vision + 1; i++)
                {
                    if (joueur.Position == new Point(i, j))
                        Console.Write("XX");
                    else
                    {
                        laby.Liste.TryGetValue((new Point(i, j)).ToString(), out loot);
                        if (!Loot.IsNull(loot))
                        {
                            switch (loot.Name)
                            {
                                case "Pilule de force":
                                    Console.Write("FO");
                                    break;
                                case "Pilule de vision":
                                    Console.Write("VI");
                                    break;
                                case "Carte":
                                    Console.Write("CA");
                                    break;
                                case "random":
                                    Console.Write("!!");
                                    break;
                                case "Clé":
                                    Console.Write("KY");
                                    break;
                                default:
                                    break;
                            }
                        }

                        else
                            if ((i >= 0 && j >= 0 && i < laby.Tableau.GetLength(0) && j < laby.Tableau.GetLength(1)))
                        {
                            if (laby.Tableau[i, j])
                                Console.Write("██");
                            else
                                Console.Write("░░");
                        }
                        else
                            Console.Write("°°");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();

            if (joueur.Carte)
                for (int j = 0; j < laby.Tableau.GetLength(0); j++)
                {
                    for (int i = 0; i < laby.Tableau.GetLength(1); i++)
                    {
                        if (joueur.CarteLaby.Tableau[i,j])
                        {
                            if (joueur.Position == new Point(i, j))
                                Console.Write("XX");
                            else
                            {
                                    if (laby.Tableau[i, j])
                                        Console.Write("██");
                                    else
                                        Console.Write("░░");
                            }
                        }
                        else Console.Write("██");
                    }
                    Console.WriteLine();
                }                      
        }

        public static void AffichageDeuxCartes(MyLabyrinthe laby, Joueur joueur)
        {
            Loot loot;
            Console.Clear();
            for (int j = 0; j < laby.Tableau.GetLength(0); j++)
            {
                for (int i = 0; i < laby.Tableau.GetLength(1); i++)
                {
                    if (joueur.Position == new Point(i, j))
                        Console.Write("XX");
                    else
                    {
                        laby.Liste.TryGetValue((new Point(i, j)).ToString(), out loot);
                        if (!Loot.IsNull(loot))
                        {
                            switch (loot.Name)
                            {
                                case "Pilule de force":
                                    Console.Write("FO");
                                    break;
                                case "Pilule de vision":
                                    Console.Write("VI");
                                    break;
                                case "Carte":
                                    Console.Write("CA");
                                    break;
                                case "random":
                                    Console.Write("!!");
                                    break;
                                case "Clé":
                                    Console.Write("KY");
                                    break;
                                default:
                                    break;
                            }
                        }

                        else if (laby.Tableau[i, j])
                            Console.Write("██");
                        else
                            Console.Write("░░");

                        //  Console.Write("{0}{1} ", i, j);
                    }
                }
                Console.Write("   ");
                for (int i = 0; i < laby.Tableau.GetLength(1); i++)
                {
                    if (joueur.Position == new Point(i, j))
                        Console.Write("XX");
                    else
                    {
                        if (!joueur.CarteLaby.Tableau[i, j])
                            Console.Write("██");
                        else
                        {
                            if (laby.Tableau[i, j])
                                Console.Write("██");
                            else
                                Console.Write("░░");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        //Version avec juste le labyrinthe complet
        public static void AffichageLaby(MyLabyrinthe laby, Joueur joueur)
        {
            Loot loot;
            Console.Clear();
            for (int j = 0; j<laby.Tableau.GetLength(0); j++)
            {
                for(int i = 0; i <laby.Tableau.GetLength(1); i++)
                {
                    if (joueur.Position == new Point(i, j))
                        Console.Write("XX");
                    else
                    {
                           laby.Liste.TryGetValue((new Point(i, j)).ToString(), out loot);
                           if (!Loot.IsNull(loot))
                            {
                            switch (loot.name)
                            {
                                case "Pilule de force":
                                    Console.Write("FO");
                                    break;
                                case "Pilule de vision":
                                    Console.Write("VI");
                                    break;
                                case "Carte":
                                    Console.Write("CA");
                                    break;
                                case "random":
                                    Console.Write("!!");
                                    break;
                                case "Clé":
                                    Console.Write("KY");
                                    break;
                                default:
                                    break;
                            }
                        }

                           else if (laby.Tableau[i, j])
                               Console.Write("██");
                           else
                               Console.Write("░░");

                      //  Console.Write("{0}{1} ", i, j);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
