using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace SoftBed
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
            //Application.Run(new HauptFenster());
            Application.Run(new LoginScreen());
            //Application.Run(new Adminbereich());
            //Application.Run(new LoginScreen());

            /*
            DatabaseManagement db = DatabaseManagement.GetInstance();
            db.TestDB();
            */
        }
    }
}