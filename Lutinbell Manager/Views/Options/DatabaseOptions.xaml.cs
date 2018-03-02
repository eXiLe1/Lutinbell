using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lutinbell_Manager.Class;
using MahApps.Metro.Controls.Dialogs;

namespace Lutinbell_Manager.Views.Options
{
    /// <summary>
    /// Interaction logic for Database.xaml
    /// </summary>
    public partial class DatabaseOptions : UserControl
    {
        public DatabaseOptions()
        {
            InitializeComponent();
            if (Properties.Settings.Default.AdvancedLoggingEnabled){Log.Commit("[Views/Options/Database] Loaded");}
            InitializeInterface();
        }

        private void InitializeInterface()
        {
        }

        #region XAML
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(HostField.Text) ||
                string.IsNullOrWhiteSpace(DatabaseNameField.Text) ||
                string.IsNullOrWhiteSpace(PasswordField.Password) ||
                string.IsNullOrWhiteSpace(UsernameField.Text))
            {
                if (Window.GetWindow(this) is MahApps.Metro.Controls.MetroWindow window)
                {
                    await window.ShowMessageAsync("Alert", "Please fill in all the fields");
                }
            }
            else
            {
                Properties.Settings.Default.DatabaseConnectionString = "DATA SOURCE=" + HostField.Text + ";PORT=3306;DATABASE=" + DatabaseNameField.Text + ";UID=" + UsernameField.Text + ";PASSWORD=" + PasswordField.Password + ";";
                Properties.Settings.Default.Save();
                if (Properties.Settings.Default.AdvancedLoggingEnabled)
                {
                    Log.Commit("[Database] Connection saved: " + Properties.Settings.Default.DatabaseConnectionString);
                }
                if (Window.GetWindow(this) is MahApps.Metro.Controls.MetroWindow window)
                {
                    await window.ShowMessageAsync("Success", "Database connection information saved");
                }

                Database.Refresh();
            }
        }
        #endregion
    }
}
