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

namespace Lutinbell_Manager.Views.Options
{
    /// <summary>
    /// Interaction logic for GeneralOptions.xaml
    /// </summary>
    public partial class GeneralOptions : UserControl
    {
        public GeneralOptions()
        {
            InitializeComponent();
            if (Properties.Settings.Default.AdvancedLoggingEnabled){Log.Commit("[Views/Options/General] Loaded");}
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            if (Properties.Settings.Default.AdvancedLoggingEnabled)
            {
                AdvancedLoggingToggle.IsChecked = true;
            }
            else
            {
                AdvancedLoggingToggle.IsChecked = false;
            }
        }

        #region XAML
        private void AdvancedLoggingToggle_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AdvancedLoggingEnabled = true;
            Properties.Settings.Default.Save();
        }

        private void AdvancedLoggingToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AdvancedLoggingEnabled = false;
            Properties.Settings.Default.Save();
        }
        #endregion
    }
}
