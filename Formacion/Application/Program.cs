using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kata1.Forms;

namespace Application {
    static class Program {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(){
            var frmSeasons = new FrmSeasons();
            frmSeasons.ShowDialog();
        }
    }
}
