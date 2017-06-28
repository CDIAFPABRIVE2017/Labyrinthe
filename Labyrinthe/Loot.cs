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

    public class Loot
    {
        public string name;
        public static bool IsNull(Loot loot)
        {
            return (loot == null);
        }

        public Loot(string name)
        {
            this.name = name;
        }

        public Loot(Loot loot) : this(loot.name) { }
    }
}