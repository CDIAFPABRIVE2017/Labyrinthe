using System.Collections;
using System.Collections.Generic;

namespace Labyrinthe
{
     public class Inventaire: List<Loot>
    {
        //ATTRIBUTS
        private List<Loot> _InvSort;

        //CONSTRUCTEURS
        public Inventaire()
        {; }

        //ACCESSEUR
        internal List<Loot> InvSort
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

        public string GetNomObjet(int index)
        {
            if ((this[index]).GetType() ==typeof(Loot_Sort))
            {
                //Loot_Sort sor=new Loot();
                //name = sort.NomSor;
                return (((Loot_Sort)(this[index])).NomSor).ToString();
            }
            else
            {
                return ((this[index]).name).ToString();
            }
            
        }


        //public void Add(Loot objet)
        //{
        //    this.Add(objet);
        //}
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