using System.Collections.Generic;
using System.Windows;



namespace Labyrinthe
{
    public class DicoLoot : SortedDictionary<string,Loot>
    {
        //ATTRIBUTS
        private SortedDictionary<string, Loot> _listSort = new SortedDictionary<string, Loot>();


        //CONSTRUCTEUR
        public DicoLoot()
        {; }

        //ACCESSEUR
        public SortedDictionary<string, Loot> ListSort
        {
            get
            {
                return _listSort;
            }

            set
            {
                _listSort = value;
            }
        }

        //METHODES
        public void Add(Point pt, Loot so)
        {
            this.Add(pt.ToString(), so);
        }

        public bool ContainsKey(Point pt)
        {
            return this.ContainsKey(pt.ToString());
        }

        public Loot GetSort(Point pt)
        {
            return this[pt.ToString()];
        }
        
    }
}
