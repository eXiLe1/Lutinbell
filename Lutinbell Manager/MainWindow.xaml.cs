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
using Lutinbell_Manager.ViewModels.Website;
using Lutinbell_Manager.ViewModels;
using Lutinbell_Manager.Windows;
using Lutinbell_Manager.Class;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Lutinbell_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private static MainWindow Window;

        public MainWindow()
        {
            InitializeComponent();
            Window = this;
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            DataContext = new HomeViewModel();
            Log.NewLog();
            if (Properties.Settings.Default.AdvancedLoggingEnabled)
            {
                Log.Commit("[Program] Loaded.");
            }
            if (Properties.Settings.Default.DatabaseConnectionString != "")
            {
                if(Database.Refresh())
                {
                    SetDatabaseStatus(true);
                }
                else
                {
                    SetDatabaseStatus(false);
                }
            }
            else
            {
                SetDatabaseStatus(false);
            }
        }

        public void SetDatabaseStatus(bool Status)
        {
            if (Status)
            {
                DatabaseStatusButton.Foreground = Brushes.LimeGreen;
            }
            else
            {
                DatabaseStatusButton.Foreground = Brushes.Red;
            }
        }

        public static void SetDataContext(string Context)
        {
            switch(Context)
            {
                case "WebsiteViewModel":
                    Window.DataContext = new WebsiteViewModel();
                    break;
                default:
                    break;
            }
        }

        #region XAML
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            Options options = new Options();
            options.Show();
        }

        private void DatabaseStatusButton_Click(object sender, RoutedEventArgs e)
        {
            if (Database.Refresh())
            {
                SetDatabaseStatus(true);
            }
            else
            {
                SetDatabaseStatus(false);
            }
        }
        private void SideMenu_ItemClick(object sender, ItemClickEventArgs e)
        {
            // set the content
            SideMenu.Content = e.ClickedItem;
            // close the pane
            SideMenu.IsPaneOpen = false;
        }
        private void SideMenu_OptionsItemClick(object sender, ItemClickEventArgs e)
        {
            // set the content
            SideMenu.Content = e.ClickedItem;
            // close the pane
            SideMenu.IsPaneOpen = false;
        }
        #endregion
    }
}
