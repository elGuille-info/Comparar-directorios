//-----------------------------------------------------------------------------
// Punto de entrada de la utilidad Editar colores                   (25/Nov/20)
//
// (c) Guillermo (elGuille) Som, 2020
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editar_Colores
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new fEditarColores());
        }
    }
}
