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

        public Loot Loot
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        //METHODES
        /// <summary>
        /// Ajout dans le dico d'un loot à la position défini 
        /// </summary>
        /// <param name="pt">loot à mettre dans le dico</param>
        /// <param name="so">position du loot</param>
        public void Add(Point pt, Loot so)
        {
            this.Add(pt.ToString(), so);
        }

        /// <summary>
        /// Indique si la position contient un loot
        /// </summary>
        /// <param name="pt">position à tester</param>
        /// <returns></returns>
        public bool ContainsKey(Point pt)
        {
            return this.ContainsKey(pt.ToString());
        }

        /// <summary>
        /// Récupère le loot défini par une position
        /// </summary>
        /// <param name="pt">position du loot à récupérer</param>
        /// <returns></returns>
        public Loot GetLoot(Point pt)
        {
            return this[pt.ToString()];
        }

        /// <summary>
        /// Supprime un loot du dictionnaire défini par sa position
        /// </summary>
        /// <param name="pt">position du loot à supprimer</param>
        public void EnleveLootDico(Point pt)
        {
            this.Remove(pt.ToString());
        }
        
    }
}
