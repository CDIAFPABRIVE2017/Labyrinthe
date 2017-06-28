using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe
{
    public class MyLabyrinthe
    {
        bool[,] _laby; //Le labyrinthe proprement dit. bool ou int ?
        DicoLoot _liste;

        public bool[,] Laby
        {
            get
            {
                return _laby;
            }

            set
            {
                _laby = value;
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

        public MyLabyrinthe() { }
    }
}
