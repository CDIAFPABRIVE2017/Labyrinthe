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
	public enum TypeLoot
	{
		Sort = 0,
		Etre = 1,
		Cle = 2,
		Porte = 3,
		Pic = 4
	}

	public class Loot
	{
		private string _name;
		internal static LootConstantes constantesLoot = new LootConstantes();

		//CONSTRUCTEURS
		public Loot() { }
		public Loot(string name) : this() { name = _name; }

		//ACCESSEURS
		public string name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public TypeLoot TypeLoot
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
		public static bool IsNull(Loot loot)
		{
			return (loot == null);
		}
        
	}




	/* public Loot ChoixLoot()
	 {
		 Effet typeLoot = new Effet();
 =======
		 internal static LootConstantes constantesLoot = new LootConstantes();

		 public string name;

		 public static bool IsNull(Loot loot)
		 {
			 return (loot == null);
		 }




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
		 public Loot() { }
		 public Loot(string nom):this() { name = nom; }
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