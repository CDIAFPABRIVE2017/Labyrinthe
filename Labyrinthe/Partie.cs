using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labyrinthe
{
    class Partie
    {
        MyLabyrinthe labyrinthe = new MyLabyrinthe();
        //Peut-être le constructeur peut gérer s'il est client ou serveur ?
        //Comme ça s'il est client il se contente de recevoir le labyrinthe généré par le serveur.
        //Ensuite c'est cet objet qui contiendra un objet de type enum Client ou Serveur, et se comportera en fonction.
        Joueur monJoueur = new Joueur();


        
    }
}
