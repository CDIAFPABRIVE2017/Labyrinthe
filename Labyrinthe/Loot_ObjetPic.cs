using System.Windows;

namespace Labyrinthe
{
    public class Loot_ObjetPic : Loot
    {
        MyLabyrinthe murLabyrinthe;
        public void CasserMur(Joueur personnage,MyLabyrinthe laby)
        {
            if (personnage.isMur(personnage.Direction))
            {
                Point Position = personnage.Position;

                switch (personnage.Direction)
                {
                    case Direction.HAUT:
                        Position = new Point(Position.X, Position.Y - 1);
                        break;
                    case Direction.DROITE:
                        Position = new Point(Position.X + 1, Position.Y);
                        break;
                    case Direction.BAS:
                        Position = new Point(Position.X, Position.Y + 1);
                        break;
                    case Direction.GAUCHE:
                        Position = new Point(Position.X - 1, Position.Y);
                        break;
                }
                laby.ModifierLabyrinthe((int)Position.X, (int)Position.Y, false);
            }
        }
        

      
    }
}