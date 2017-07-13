using System;
using System.Windows.Forms;

namespace Explorateur
{
    static class Principal
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Jeux());
        }
    }
}
