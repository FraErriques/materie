using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace winFormsIntf
{
    static class Program
    {
        public static System.Windows.Forms.Form firstBlood;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.firstBlood = new frmLogin();
            Application.Run( Program.firstBlood );
        }// main


    }//class
}// nmsp
