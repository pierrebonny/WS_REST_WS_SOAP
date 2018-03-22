using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicClient
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MathsOperationsClient clientBase = new MathsOperationsClient("BasicHttpBinding_IMathsOperations");
            MathsOperationsClient clientWs = new MathsOperationsClient("WSHttpBinding_IMathsOperations");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(clientBase,clientWs));
        }
    }
}
