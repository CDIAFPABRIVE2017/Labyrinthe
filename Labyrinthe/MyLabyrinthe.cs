using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labyrinthe
{
    public class MyLabyrinthe
    {
        bool[,] _tableau; //Le labyrinthe proprement dit. bool ou int ?
        DicoLoot _liste;

        public void ModifierLabyrinthe(int i, int j, bool val)
        {
            _tableau[i, j] = val;
        }
        public bool[,] Tableau
        {
            get
            {
                return _tableau;
            }

            set
            {
                _tableau = value;
            }
        }

        public DicoLoot Liste
        {
            get
            {
                return _liste;
            }

            set
            {
                _liste = value;
            }
        }

        public void ConversionMaze(int[,] maze)
        {
            this.Tableau = new bool[maze.GetLength(0), maze.GetLength(1)];
            for (int j = 0; j < maze.GetLength(1); j++)
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    switch (maze[j, i])
                    {
                        case 0:
                            ModifierLabyrinthe(i, j, false);
                            break;
                        case 1:
                            ModifierLabyrinthe(i, j, true);
                            break;
                        default:
                            ModifierLabyrinthe(i, j, false);
                            Liste.Add(new Point(i, j), new Labyrinthe.Loot("random"));
                            break;
                    }
                }
        }

        public MyLabyrinthe() { }
    }
}
