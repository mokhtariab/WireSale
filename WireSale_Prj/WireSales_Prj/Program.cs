using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WireSales_Prj
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
            Global_Cls.StartForm = new StartHM_frm();
            Application.Run(Global_Cls.StartForm);
        }
    }
}
