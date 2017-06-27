using System.Windows;

namespace Labyrinthe
{
    enum Effet
    {
        VisionBonus = 0,
        VisionMalus = 1,
        VitesseBonus = 2,
        VitesseMalus = 3,
        ForceBonus = 4,
        ForceMalus = 5,
        Carte = 6,
        Cle = 7,
        Pic = 8,
    }

    internal class Loot
    {
        Effet _effet;
        Point _emplacement;
        string _nom;
    }
}