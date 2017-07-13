using Labyrinthe;
using MazeDll;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Explorateur
{

    public partial class Jeux : Form
    {
        public static Partie partie = new Partie();
        public static Joueur joueur = new Joueur();
        public static MyLabyrinthe laby;

        int Hauteur =61;
        int Largeur =61;
        int DirHorizont = 1;
        int DirVertical = 0;

        int PersoH = 3;
        int PersoL = -3;
        int TailleWarfog = 9;

        int[,] Maze = new int[61,61];

        public Jeux()
        {
            InitializeComponent();
        }



        private void timerPersoHaut_Tick(object sender, EventArgs e)
        {
            //string NomSpritePerso= (PbxPerso.Name[PbxPerso.Name.Length-1]).ToString();

            string image = LblPas.Text;


            switch (image)
            {
                case "0":
                    PbxPerso.Image = Properties.Resources.Haut1;
                    LblPas.Text = "1";
                    break;
                case "1":
                    PbxPerso.Image = Properties.Resources.Haut2;
                    LblPas.Text = "2";

                    break;
                case "2":
                    PbxPerso.Image = Properties.Resources.Haut3;
                    LblPas.Text = "3";

                    break;
                case "3":
                    PbxPerso.Image = Properties.Resources.Haut4;
                    LblPas.Text = "4";

                    break;
                case "4":
                    PbxPerso.Image = Properties.Resources.Haut5;
                    LblPas.Text = "5";

                    break;
                case "5":
                    PbxPerso.Image = Properties.Resources.Haut6;
                    LblPas.Text = "6";

                    break;
                case "6":
                    PbxPerso.Image = Properties.Resources.Haut7;
                    LblPas.Text = "7";

                    break;
                case "7":
                    PbxPerso.Image = Properties.Resources.Haut8;
                    LblPas.Text = "8";

                    break;
                case "8":
                    PbxPerso.Image = Properties.Resources.Haut0;
                    LblPas.Text = "0";

                    timerPersoHaut.Stop();
                    break;

            }
        }

        private void timerPersoGauche_Tick(object sender, EventArgs e)
        {

            //string NomSpritePerso= (PbxPerso.Name[PbxPerso.Name.Length-1]).ToString();

            string image = LblPas.Text;


            switch (image)
            {
                case "0":
                    PbxPerso.Image = Properties.Resources.Gauche1;
                    LblPas.Text = "1";
                    break;
                case "1":
                    PbxPerso.Image = Properties.Resources.Gauche2;
                    LblPas.Text = "2";

                    break;
                case "2":
                    PbxPerso.Image = Properties.Resources.Gauche3;
                    LblPas.Text = "3";

                    break;
                case "3":
                    PbxPerso.Image = Properties.Resources.Gauche4;
                    LblPas.Text = "4";

                    break;
                case "4":
                    PbxPerso.Image = Properties.Resources.Gauche5;
                    LblPas.Text = "5";

                    break;
                case "5":
                    PbxPerso.Image = Properties.Resources.Gauche6;
                    LblPas.Text = "6";

                    break;
                case "6":
                    PbxPerso.Image = Properties.Resources.Gauche7;
                    LblPas.Text = "7";

                    break;
                case "7":
                    PbxPerso.Image = Properties.Resources.Gauche8;
                    LblPas.Text = "8";

                    break;
                case "8":
                    PbxPerso.Image = Properties.Resources.Gauche0;
                    LblPas.Text = "0";

                    timerPersoGauche.Stop();
                    break;

            }
        }

        private void timerPersoBas_Tick(object sender, EventArgs e)
        {

            string image = LblPas.Text;


            switch (image)
            {
                case "0":
                    PbxPerso.Image = Properties.Resources.Bas1;
                    LblPas.Text = "1";
                    break;
                case "1":
                    PbxPerso.Image = Properties.Resources.Bas2;
                    LblPas.Text = "2";

                    break;
                case "2":
                    PbxPerso.Image = Properties.Resources.Bas3;
                    LblPas.Text = "3";

                    break;
                case "3":
                    PbxPerso.Image = Properties.Resources.Bas4;
                    LblPas.Text = "4";

                    break;
                case "4":
                    PbxPerso.Image = Properties.Resources.Bas5;
                    LblPas.Text = "5";

                    break;
                case "5":
                    PbxPerso.Image = Properties.Resources.Bas6;
                    LblPas.Text = "6";

                    break;
                case "6":
                    PbxPerso.Image = Properties.Resources.Bas7;
                    LblPas.Text = "7";

                    break;
                case "7":
                    PbxPerso.Image = Properties.Resources.Bas8;
                    LblPas.Text = "8";

                    break;
                case "8":
                    PbxPerso.Image = Properties.Resources.Bas0;
                    LblPas.Text = "0";

                    timerPersoBas.Stop();
                    break;

            }
        }

        private void timerPersoDroite_Tick(object sender, EventArgs e)
        {

            string image = LblPas.Text;


            switch (image)
            {
                case "0":
                    PbxPerso.Image = Properties.Resources.Droite1;
                    LblPas.Text = "1";
                    break;
                case "1":
                    PbxPerso.Image = Properties.Resources.Droite2;
                    LblPas.Text = "2";

                    break;
                case "2":
                    PbxPerso.Image = Properties.Resources.Droite3;
                    LblPas.Text = "3";

                    break;
                case "3":
                    PbxPerso.Image = Properties.Resources.Droite4;
                    LblPas.Text = "4";

                    break;
                case "4":
                    PbxPerso.Image = Properties.Resources.Droite5;
                    LblPas.Text = "5";

                    break;
                case "5":
                    PbxPerso.Image = Properties.Resources.Droite6;
                    LblPas.Text = "6";

                    break;
                case "6":
                    PbxPerso.Image = Properties.Resources.Droite7;
                    LblPas.Text = "7";

                    break;
                case "7":
                    PbxPerso.Image = Properties.Resources.Droite8;
                    LblPas.Text = "8";

                    break;
                case "8":
                    PbxPerso.Image = Properties.Resources.Droite0;
                    LblPas.Text = "0";

                    timerPersoDroite.Stop();
                    break;

            }
        }

        public void Jeux_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                joueur.isMur(Direction.HAUT);
                PbxPerso.Image = Properties.Resources.Haut0;
                DessineZoneVisible(Maze, PersoH, PersoL, Hauteur, Largeur);

            }
            if (e.KeyCode == Keys.Down)
            {
                joueur.isMur(Direction.BAS);
                PbxPerso.Image = Properties.Resources.Bas0;
                DessineZoneVisible(Maze, PersoH, PersoL, Hauteur, Largeur);

            }
            if (e.KeyCode == Keys.Left)
            {
                joueur.isMur(Direction.GAUCHE);
                PbxPerso.Image = Properties.Resources.Gauche0;
                DessineZoneVisible(Maze, PersoH, PersoL, Hauteur, Largeur);
                

            }
            if (e.KeyCode == Keys.Right)
            {
                joueur.isMur(Direction.DROITE);
                PbxPerso.Image = Properties.Resources.Droite0;
                DessineZoneVisible(Maze, PersoH, PersoL, Hauteur, Largeur);
               
            }
        }

        public void Jeux_Load(object sender, EventArgs e)
        {
            Maze machin = new Maze();
            int[,] tempMaze = new int[Hauteur, Largeur];

            MazeDll.Maze.InitialiseTableau(tempMaze, Hauteur, Largeur);
            MazeDll.Maze.GenereCheminPrimaire(tempMaze, Hauteur, Largeur, 1, 0);
            laby.ConversionMaze(tempMaze);
            DessineZoneVisible(Maze, PersoH, PersoL,  Hauteur, Largeur);

        }
        public void DessineZoneVisible(int[,] Maze, int PersoH, int PersoL, int Hauteur, int Largeur)

        {

            int ecart = joueur.Vision;

            int emplacement = 1;
            int Valeur;

            for (int H = -PersoH; H < 9 - PersoH; H++)
            {

                for (int L = PersoL; L < 9 + PersoL; L++)
                {

                    if (H > Hauteur - 1 || L > Largeur - 1 || H < 0 || L < 0)
                    {
                        Valeur = -1;
                    }
                    else
                    {
                        Valeur = Maze[H, L];
                    }


                    string nomCase = "Pbx" + emplacement.ToString();
                    PictureBox pbx = this.Controls.Find(nomCase, true).FirstOrDefault() as PictureBox;

                    if (Valeur == 1)
                    {
                        pbx.Image = Properties.Resources.murs;
                        pbx.Tag = "1";
                        emplacement++;
                    }
                    if (Valeur == -1)
                    {
                        pbx.Image = Properties.Resources.cielEtoiles;

                        emplacement++;
                    }
                    if (Valeur == 0)
                    {
                        pbx.Image = Properties.Resources.solSable;
                        pbx.Tag = "0";
                        emplacement++;
                    }
                    if (Valeur == 3)
                    {
                        pbx.Image = Properties.Resources.escalierPierre;
                        pbx.Tag = "3";
                        emplacement++;
                    }
                    if (Valeur ==4)
                    {
                        pbx.Image = Properties.Resources.GrilleFermee;
                        pbx.Tag = "4";
                        emplacement++;
                    }
                }
            }

            emplacement = 1;

        }
        private void BruitPas()
        {

            System.Media.SoundPlayer son = new System.Media.SoundPlayer();

            string chemin = "..\\..\\Resources\\PasMarbre.wav";

            son.SoundLocation = chemin;


            son.Play();
        }

    }
}
