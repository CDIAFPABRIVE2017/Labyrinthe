using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Labyrinthe
{
    public class Partie
    {
        bool _isClient;
        MyLabyrinthe laby;

        public bool IsClient
        {
            get
            {
                return _isClient;
            }

            set
            {
                _isClient = value;
            }
        }

        public void Lancement()
        {
            // Broadcast "serveur ?"
            //attend la réponse 1 sec

            if (/*on reçoit une réponse*/false)
                IsClient = true;
            else
                IsClient = false;

            laby = ConstructionLabyrinthe();
        }

        public MyLabyrinthe ConstructionLabyrinthe()
        {
            if (IsClient)
                return null;
            //On interroge le serveur et on récupère son labyrinthe
            else
                return new MyLabyrinthe();
        }

        public Loot IsObjet(Point p)
        {
            if (IsClient)
                //Interrogation serveur et récupération du LOOT
                return null;
            else
            {
                Loot loot;
                if (laby.Liste.TryGetValue(p, out loot))
                {
                    laby.Liste.Remove(p);
                    //Prévenir les autres de remove cet objet !
                    return loot;
                }

                else return null;
            }            
        }
    }
}
