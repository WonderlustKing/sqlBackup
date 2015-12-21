using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackUpDb;

namespace Scheduler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Load load = new Load();
            load.LoadFromFile();

            //pos na diabazei tis baseis pou phre apo to arxeio mia mia
            String[] pinakas = load.getbackup();//periexei oles tis baseis pou tha kaneis backup
           
        }
    }
}
