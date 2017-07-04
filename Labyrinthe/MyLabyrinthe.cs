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
        DicoLoot _liste=new DicoLoot();
        internal static Properties.QuantiteLoot quantiteLoot = new Properties.QuantiteLoot();
        PositionsJoueurs _joueurs = new PositionsJoueurs();

        public void ModifierLabyrinthe(int i, int j, bool val)
        {
            if (i>=0 && j>= 0 && i<Tableau.GetLength(0) && j<Tableau.GetLength(1))
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

        public PositionsJoueurs Joueurs
        {
            get
            {
                return _joueurs;
            }

            set
            {
                _joueurs = value;
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
                            Point point = new Point(i, j);
                            Loot loot = new Labyrinthe.Loot("random");
                            Liste.Add(point,loot);
                            break;
                    }
                }
        }

        public void NouveauxObjets()
        {
            int nbPilulesVision = Properties.QuantiteLoot.Default.nbPotionVision;
            int nbClés = Properties.QuantiteLoot.Default.nbClés;
            int nbPilulesForce = Properties.QuantiteLoot.Default.nbPotionForce;
            int nbCartes = Properties.QuantiteLoot.Default.nbCartes;

            for (int i = 0; i < nbPilulesVision; i++)
                Liste.Add(CaseVide(), new Loot("Pilule de vision"));
            for (int i = 0; i < nbClés; i++)
                Liste.Add(CaseVide(), new Loot("Clé"));
            for (int i = 0; i < nbPilulesForce; i++)
                Liste.Add(CaseVide(), new Loot("Pilule de force"));
            for (int i = 0; i < nbCartes; i++)
                Liste.Add(CaseVide(), new Loot("Carte"));
        }

        public Point CaseVide()
        {
            Random rnd = new Random();
            int x, y;
            Loot test;

            do
            {
                x = rnd.Next(Tableau.GetLength(0));
                y = rnd.Next(Tableau.GetLength(1));
            }
            while ((Tableau[x, y]) || (Liste.TryGetValue((new Point(x, y)).ToString(), out test)));

            return (new Point(x, y));

        }

        public MyLabyrinthe() { _liste = new DicoLoot(); }

        /// <summary>
        /// Rempli le dico des loots spécifiés
        /// </summary>
        /// <param name="List"></param>
        public void CreationListLoot()
        {
            //ajout cle
            for (int cle = 0; cle < quantiteLoot.nbClés; cle++)
            {
                Liste.Add(this.CaseVide(), new Loot_ObjetCle());
            }
            //ajout carte du labyrinthe
            for (int carte = 0; carte < quantiteLoot.nbCartes; carte++)
            {
                Liste.Add(this.CaseVide(), new Loot_Carte());
            }
            //ajout pic
            for (int pic = 0; pic < quantiteLoot.nbPic; pic++)
            {
                Liste.Add(this.CaseVide(), new Loot_ObjetPic());
            }
            //ajout etre
            for (int etre = 0; etre < quantiteLoot.nbCartes; etre++)
            {
                Liste.Add(this.CaseVide(), new Loot_Etre());
            }
            //ajout Sort
            InstanciationLootSort(quantiteLoot.nbSortTeleportation, TypeSort.Immediat, NomSort.Teleportation, Liste);
            InstanciationLootSort(quantiteLoot.nbSortVision, TypeSort.Immediat, NomSort.Vision, Liste);
            InstanciationLootSort(quantiteLoot.nbSortForce, TypeSort.Immediat, NomSort.Force, Liste);
            //ajout Potion
            InstanciationLootSort(quantiteLoot.nbPotionForce, TypeSort.Potion, NomSort.Force, Liste);
            InstanciationLootSort(quantiteLoot.nbPotionForce, TypeSort.Potion, NomSort.Vision, Liste);
            InstanciationLootSort(quantiteLoot.nbPotionForce, TypeSort.Potion, NomSort.Vitesse, Liste);
            //ajout carte
            InstanciationLootSort(quantiteLoot.nbCartes, TypeSort.Carte, (NomSort)Utilitaire.RandNombre(0,50), Liste);
            //ajout porte
            Liste.Add(this.CaseVide(), new Loot_Porte());
        }

        /// <summary>
        /// Instancie dans un dico les sort de la quantité déterminé
        /// </summary>
        /// <param name="quantite">défini la quantité de loot</param>
        /// <param name="type">defini le type de sort</param>
        /// <param name="nom">defini le nom du sort</param>
        /// <param name="list">defini le dico affecté</param>
        public void InstanciationLootSort(int quantite, TypeSort type, NomSort nom, DicoLoot list)
        {
            for (int i = 0; i < quantite; i++)
            {
                Loot_Sort sort = new Loot_Sort();
                list.Add(this.CaseVide(), sort.CreationSort(type, nom));
            }
        }
    }
}
