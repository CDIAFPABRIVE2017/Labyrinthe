using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorateur
{
    public partial class Jeux : Form
    {
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

        private void Jeux_KeyPress(object sender, KeyEventArgs e)
        {
            System.Media.SoundPlayer son = new System.Media.SoundPlayer();

            string chemin = "..\\..\\Resources\\PasMarbre.wav";

            son.SoundLocation = chemin;

            
            son.Play();
            

            if (e.KeyCode == Keys.Up)
            {
                timerPersoHaut.Start();
                timerPersoBas.Stop();
                timerPersoGauche.Stop();
                timerPersoDroite.Stop();
            }
            if (e.KeyCode == Keys.Down)
            {

                timerPersoHaut.Stop();
                timerPersoBas.Start();
                timerPersoGauche.Stop();
                timerPersoDroite.Stop();


            }
            if (e.KeyCode == Keys.Left)
            {

                timerPersoHaut.Stop();
                timerPersoBas.Stop();
                timerPersoGauche.Start();
                timerPersoDroite.Stop();

            }
            if (e.KeyCode == Keys.Right)
            {
                timerPersoHaut.Stop();
                timerPersoBas.Stop();
                timerPersoGauche.Stop();
                timerPersoDroite.Start();

            }
        }

        private void Jeux_Load(object sender, EventArgs e)
        {
            

            int Hauteur = 61;
            int Largeur = 61;
            int PersoH = 1;
            int PersoL = 1;
            int TailleWarfog = 3;


            // Liste a deux dimentions

            int[,] Maze = new int[Hauteur, Largeur];


            //InitialiseTableau(Maze, Hauteur, Largeur);

            MazeGenerator.Program.InitialiseTableau(Maze, Hauteur, Largeur);

            DessineZoneVisible(Maze, PersoH,PersoL, TailleWarfog);
        }
        private void DessineZoneVisible(int[,] Maze,int PersoH, int PersoL, int TailleWarfog)
        {
            string nomCase = "";
            int ecart = TailleWarfog / 2;
            int emplacement = 1;


            // Affichage méthode BOURIN !

            for (int H = 0; H < 9; H++)
            {

                for (int L = 0; L < 9; L++)
                {
                    switch (emplacement)
                    {
                        case 1:

                            if (Maze[H, L] == 1)
                            {
                                PbxD3.Image = Properties.Resources.murs;

                            }

                            break;
                        case 2:


                            if (Maze[H, L] == 1)
                            {
                                PbxD4.Image = Properties.Resources.murs;

                            }
                            break;
                        case 3:


                            if (Maze[H, L] == 1)
                            {
                                PbxD5.Image = Properties.Resources.murs;

                            }

                            break;
                        case 4:

                            if (Maze[H, L] == 1)
                            {
                                PbxE3.Image = Properties.Resources.murs;

                            }

                            break;
                        case 5:


                            if (Maze[H, L] == 1)
                            {
                                PbxE2.Image = Properties.Resources.murs;

                            }

                            break;
                        case 6:


                            if (Maze[H, L] == 1)
                            {
                                PbxE3.Image = Properties.Resources.murs;

                            }

                            break;
                        case 7:


                            if (Maze[H, L] == 1)
                            {
                                PbxF1.Image = Properties.Resources.murs;

                            }

                            break;
                        case 8:


                            if (Maze[H, L] == 1)
                            {
                                PbxF2.Image = Properties.Resources.murs;

                            }

                            break;
                        case 9:


                            if (Maze[H, L] == 1)
                            {
                                PbxF3.Image = Properties.Resources.murs;

                            }
                            break;

                    }
                    emplacement++;

                }
            }
            
           
            
           
            
        }


    }
}
