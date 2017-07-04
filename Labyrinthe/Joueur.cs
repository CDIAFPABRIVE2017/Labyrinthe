using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;



namespace Labyrinthe
{
    public enum Direction
    {
        HAUT = 0,
        DROITE = 1,
        BAS = 2,
        GAUCHE = 3,
        AUTRE = 666
    }
    public class Joueur
    {
        Point _position = new Point(0,0);
        int _vision = 1;
        decimal _vitesse, _force;
        Inventaire _inventaire /*= new Inventaire()*/;
        bool _porteOuverte = false;
        bool _portePresent = false;
        bool _etrePresent=false;
        bool _adversairePresent = false;
        Direction _direction;
        Loot_Etre _etre;
        Joueur _adversaire;
        bool _carte = false;
        internal static LootConstantes constantesLoot = new LootConstantes();
        MyLabyrinthe _tableau;

        MyLabyrinthe _carteLaby;

            public Joueur()
        {
            _inventaire = new Inventaire();
        }

        public void Deplacement(Direction d)
        {
            if (!isMur(d)
                )
            {
                switch (d)
                {
                    case Direction.HAUT:
                        Position = new Point(Position.X, Position.Y - 1);
                        Direction = Direction.HAUT;
                        break;
                    case Direction.DROITE:
                        Position = new Point(Position.X + 1, Position.Y);
                        Direction = Direction.DROITE;
                        break;
                    case Direction.BAS:
                        Position = new Point(Position.X, Position.Y + 1);
                        Direction = Direction.BAS;
                        break;
                    case Direction.GAUCHE:
                        Position = new Point(Position.X - 1, Position.Y);
                        Direction = Direction.GAUCHE;
                        break;
                }
                ModificationCarte(Position, Vision);
            }
        }

        /// <summary>
        /// Retourne si le mouvement peut être fait
        /// </summary>
        /// <param name="d">Direction</param>
        /// <returns></returns>
        public bool isMur(Direction d)
        {
            switch (d)
            {
                case Direction.HAUT:
                    if (Position.Y == 0)
                        return true;
                    else return (Laby.Tableau[(int)Position.X, (int)Position.Y - 1]);
                case Direction.DROITE:
                    if (Position.X == Laby.Tableau.GetLength(0)-1)
                        return true;
                    else return (Laby.Tableau[(int)Position.X + 1, (int)Position.Y]);
                case Direction.BAS:
                    if (Position.Y == Laby.Tableau.GetLength(1)-1)
                        return true;
                    else return (Laby.Tableau[(int)Position.X, (int)Position.Y + 1]);
                case Direction.GAUCHE:
                    if (Position.X == 0)
                        return true;
                    else return (Laby.Tableau[(int)Position.X - 1, (int)Position.Y]);
            }
            return false;
        }

        #region get/set
        public Point Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public int Vision
        {
            get { return _vision; }
            set { _vision = value; }
        }

        public decimal Vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }

        public decimal Force
        {
            get { return _force; }
            set { _force = value; }
        }

        public Inventaire Inventaire
        {
            get { return _inventaire; }
            set { _inventaire = value;}
        }

        public MyLabyrinthe Laby
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

        public MyLabyrinthe CarteLaby
        {
            get
            {
                return _carteLaby;
            }

            set
            {
                _carteLaby = value;
            }
        }

        public bool Carte
        {
            get
            {
                return _carte;
            }

            set
            {
                _carte = value;
            }
        }

        public Loot_Etre Etre
        {
            get
            {
                return _etre;
            }

            set
            {
                _etre = value;
            }
        }

        public Joueur Adversaire
        {
            get
            {
                return _adversaire;
            }

            set
            {
                _adversaire = value;
            }
        }

        public bool EtrePresent
        {
            get
            {
                return _etrePresent;
            }

            set
            {
                _etrePresent = value;
            }
        }

        public bool AdversairePresent
        {
            get
            {
                return _adversairePresent;
            }

            set
            {
                _adversairePresent = value;
            }
        }

        public bool PorteOuverte
        {
            get
            {
                return _porteOuverte;
            }

            set
            {
                _porteOuverte = value;
            }
        }

        public bool PortePresent
        {
            get
            {
                return _portePresent;
            }

            set
            {
                _portePresent = value;
            }
        }

        public Direction Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

        #endregion

        #region METHODES
        public void ModificationCarte(Point position, int Vision)
        {
            for (int i = 0-Vision; i < 0+Vision+1; i++)
                for (int j = 0-Vision; j<0+Vision+1;j++)
                    CarteLaby.ModifierLabyrinthe((int)position.X+i, (int)position.Y+j, true);
                        
        }

        public void InitialisationCarte()
        {
            CarteLaby = new MyLabyrinthe();

            CarteLaby.Tableau = new bool[_tableau.Tableau.GetLength(0), _tableau.Tableau.GetLength(1)];
            for (int i = 0; i < _tableau.Tableau.GetLength(0); i++)
                for (int j = 0; j < _tableau.Tableau.GetLength(1); j++)
                    CarteLaby.ModifierLabyrinthe(i, j, false);
        }

        public void SubirEffet(Loot loot)
        {
            if (loot.name == "Pilule de vision")
                Vision++;
            if (loot.name == "Carte")
                Carte = true;
        }

        /// <summary>
        /// dirige les loot dans l'inventaire, affect le joueur, set la presence porte, Etre
        /// </summary>
        /// <param name="loot">Loot trouvé</param>
        /// <returns></returns>
        public bool GestionLootLabyrinthe(Loot loot)
        {
            PortePresent = false;
            EtrePresent = false;
            if (loot.TypeLoot==TypeLoot.Sort && ((Loot_Sort)loot).TypeSort==TypeSort.Immediat)
            {
                ((Loot_Sort)loot).Affect(this);
                return true;
            }
            else if (loot.TypeLoot == TypeLoot.Sort && ((Loot_Sort)loot).TypeSort != TypeSort.Immediat)
            {
                this.Inventaire.Add(loot);
                return true;
            }
            else if (loot.TypeLoot==TypeLoot.Cle || loot.TypeLoot == TypeLoot.Pic || loot.TypeLoot == TypeLoot.Carte)
            {
                this.Inventaire.Add(loot);
                ((Loot_ObjetCle)loot).MombreCle++;
                return true;
            }
            else if (loot.TypeLoot == TypeLoot.Porte)
            {
                PortePresent = true;
                return false;
            }
            else if (loot.TypeLoot == TypeLoot.Etre)
            {
                EtrePresent = true;
                return false;
            }
 
            return false;
        }

        /// <summary>
        /// action lors d'utilisation de l'inventaire
        /// </summary>
        /// <param name="index">index du loot dans l'inventaire</param>
        /// <returns></returns>
        public int UtilisationLootInventaire(int index)
        {
            Loot loot = Inventaire[index];

            //Loot Sort de l'inventaire
            if (loot.TypeLoot == TypeLoot.Sort)
            {
                //Affectation Sort de type potion
                if (((Loot_Sort)loot).TypeSort==TypeSort.Potion)
                {
                    ((Loot_Sort)loot).Affect(this);
                    Inventaire.EnleveLoot(index);
                    return 1;
                }
                //Affectation Sort sur Etre
                else if (((Loot_Sort)loot).TypeSort == TypeSort.Carte && EtrePresent==true)
                {
                    InteractionEtre((Loot_Sort)loot,Etre);
                    Inventaire.EnleveLoot(index);
                    return 2;
                }
                //Affectation Sort sur Adversaire
                else if (((Loot_Sort)loot).TypeSort == TypeSort.Carte && AdversairePresent==true)
                {
                    InteractionJoueur((Loot_Sort)loot,Adversaire);
                    Inventaire.EnleveLoot(index);
                    return 3;
                }
            }
            //Loot Pic de l'inventaire
            else if (loot.TypeLoot == TypeLoot.Pic)
            {
                ((Loot_ObjetPic)loot).CasserMur(this,Laby);
                return 4;
            }
            //Loot Carte de l'inventaire
            else if (loot.TypeLoot == TypeLoot.Carte)
            {
                //  AfficheCarte();
                return 5;
            }
            //Loot Cle de l'inventaire
            else if (loot.TypeLoot == TypeLoot.Cle && ((Loot_ObjetCle)loot).MombreCle>= constantesLoot.ClesOuvrePorte  && PortePresent==true )
            {
                PorteOuverte = true;
                return 6;
            }
            return 0;                            
        }

        /// <summary>
        /// Affect les paramètres d'un être x avec le sort
        /// </summary>
        /// <param name="sort">Sort à appliquer</param>
        /// <param name="x">l'être affacté</param>
        public void InteractionEtre(Loot_Sort sort,Loot_Etre x)
        {
            sort.Affect(x);
        }

        /// <summary>
        /// Affect les paramètres d'un adversaire x avec le sort
        /// </summary>
        /// <param name="sort">Sort à appliquer</param>
        /// <param name="x">l'être affacté</param>
        public void InteractionJoueur(Loot_Sort sort,Joueur x)
        {
            sort.Affect(x);
        }

        #endregion
    }
}
