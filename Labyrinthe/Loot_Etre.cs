using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinthe
{
    public enum TypeEtre
    {
        Dragon = 0,
        Gobelin = 1,
        Spectre = 2
    };

    public class Loot_Etre : Loot
    {
        Joueur personnage = new Joueur();
        TypeEtre _etre = new TypeEtre();
        int _force = 0;



        public TypeEtre Etre
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

        public int Force
        {
            get
            {
                return _force;
            }

            set
            {
                _force = value;
            }
        }

        public void AttackPersonnage(int valeurforceAttack)
        {
            personnage.Force -= valeurforceAttack;
        }

        /// <summary>
        /// Informe si l'être est vivant
        /// </summary>
        /// <returns></returns>
        public bool EstVivant()
        {
            if (this.Force <= 0)
            {
                return false;
            }
            return true;
        }
        public void DefaultForceEtre(TypeEtre etre)
        {
            switch (etre)
            {
                case TypeEtre.Dragon:
                    Force = constantesLoot.ForceDragon;
                    break;
                case TypeEtre.Gobelin:
                    Force = constantesLoot.ForceGobelin;
                    break;
                case TypeEtre.Spectre:
                    Force = constantesLoot.ForceSpectre;
                    break;
                default:
                    break;
            }
        }

    }
}
