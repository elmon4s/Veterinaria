using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veterinaria.Vistas;

namespace Veterinaria
{
    //Monasterio Mateo 404888
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary
        [STAThread]
        static void Main()
        {
            bool MostrarMennsajeInicio = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmPrincipal(MostrarMennsajeInicio));
        }
    }
}
