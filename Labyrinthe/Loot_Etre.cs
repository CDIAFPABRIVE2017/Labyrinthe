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

        public void ForceEtre(TypeEtre etre)
        {
            switch (etre)
            {
                case TypeEtre.Dragon: _force = constantesLoot.ForceDragon;
                    break;
                case TypeEtre.Gobelin:
                    _force = constantesLoot.ForceGobelin;
                    break;
                case TypeEtre.Spectre:
                    _force = constantesLoot.ForceSpectre;
                    break;
                default:
                    break;
            }
        }

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
            if (this._force <= 0)
            {
                return false;
            }
            return true;
        }

    }
}
