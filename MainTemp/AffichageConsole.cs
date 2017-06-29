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
                           laby.Liste.TryGetValue(new Point(i, j), out loot);
                           if (!Loot.IsNull(loot))
                               Console.Write("LL");
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
