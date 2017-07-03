using System.Collections;
using System.Collections.Generic;

namespace Labyrinthe
{
     public class Inventaire: List<Loot>
    {
        //ATTRIBUTS
        private Inventaire _InvSort;

        //CONSTRUCTEURS
        public Inventaire()
        {; }

        //ACCESSEUR
        internal Inventaire InvSort
        {
            get
            {
                return _InvSort;
            }

            set
            {
                _InvSort = value;
            }
        }

        //METHODES
        public Loot GetSort(int index)
        {
            return this[index];
        }

        public string GetNomSort(int index)
        {
            return ((this[index]).name).ToString();
        }

        public void EnleveSort(int index)
        {
            this.RemoveAt(index);
        }

        public int QuantiteSort()
        {
            return this.Count;
        }
    }
}