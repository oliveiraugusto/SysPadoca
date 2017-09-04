using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SysPadoca.Forms;

// Programa Principal [Classe Main()] do Windows Forms Application

namespace SysPadoca
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

            //Caso você queira testar algum form de maneira direta
            //chame-o nesse linha, é ela que invoca o primeiro form do programa
            Application.Run(new frmLogin());
        }
    }
}
