using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TrackerUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialize the database connection
            TrackerLibrary.GlobalConfig.InitializeConnection(DatabaseType.TextFile);
            Application.Run(new CreateTeamForm());

            //Application.Run(new TournamentDashBoardForm());

        }
    }
}
