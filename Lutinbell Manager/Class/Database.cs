using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Lutinbell_Manager.Class
{
    class Database
    {
        public static bool Refresh()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.DatabaseConnectionString);
                connection.Open();
                connection.Close();
                if (Properties.Settings.Default.AdvancedLoggingEnabled)
                {
                    Log.Commit("[Database:Refresh] Connection refreshed.");
                }
                return true;
            }
            catch (Exception e)
            {
                if (Properties.Settings.Default.AdvancedLoggingEnabled)
                {
                    Log.Commit("[Database:Refresh:E01] Connection failed: " + e.Message);
                }
                Log.Commit("[Database:Refresh:E01] Connection failed.");
                return false;
            }
        }
    }
}
