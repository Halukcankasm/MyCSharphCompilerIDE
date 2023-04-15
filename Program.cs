using MyCSharphCompilerIDE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharpsIDE
{
    static class MyCSharphCompilerIDE
    {
        /// <summary>
        /// Uygulamanýn ana girdi noktasý.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}