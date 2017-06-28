using System.Windows;
using System.Configuration;


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
        internal static LootConstantes constantesLoot = new LootConstantes();
       
        

		internal Effet Effet
		{
			get
			{
				throw new System.NotImplementedException();
			}

			set
			{
			}
		}

    }
   /* public Loot ChoixLoot()
	{
		Effet typeLoot = new Effet();

		switch (typeLoot)
	{
		default:
 break;
	}
}*/
}