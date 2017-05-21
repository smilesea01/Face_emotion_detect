using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reconocimiento_facial
{
    static class Program
    {
        static DateTime date { get; }
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Reconocimiento());

            Console.WriteLine("Face Recongizing Base Program Beta 0.1 - Daejeon Dongsan HS, DeepMind - Shinkansan");
            Console.WriteLine("Program start" + date);
            Console.WriteLine("This Program is fully compatible for Windows 10 Build 1047 ");

        }
    }
}
