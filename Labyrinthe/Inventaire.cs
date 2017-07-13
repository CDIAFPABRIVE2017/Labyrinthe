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
        /// <summary>
        /// Recupère le loot définie par son index
        /// </summary>
        /// <param name="index">index du loot dans l'inventaire</param>
        /// <returns></returns>
        public Loot GetSort(int index)
        {
            return this[index];
        }

        /// <summary>
        /// renvoie le nom du loot défini par l'index, issu de l'enum pour les loot sort du champ name pour les autres
        /// </summary>
        /// <param name="index">index du loot dans l'inventaire</param>
        /// <returns></returns>
        public string GetNomObjet(int index)
        {
            if ((this[index]).GetType() ==typeof(Loot_Sort))
            {
                return (((Loot_Sort)(this[index])).NomSort).ToString();
            }
            else
            {
                return ((this[index]).name).ToString();
            }
            
        }
        
        /// <summary>
        /// Enleve de l'inventaire le loot définie par l'index
        /// </summary>
        /// <param name="index">index du loot dans l'inventaire</param>
        public void EnleveLoot(int index)
        {
            this.RemoveAt(index);
        }

        /// <summary>
        /// renvoie la quantité de loot contenu dans l'inventaire
        /// </summary>
        /// <returns></returns>
        public int QuantiteLoot()
        {
            return this.Count;
        }

        //public void Add(Loot loot)
        //{
        //    this.Add(loot);
        //}

    }
}