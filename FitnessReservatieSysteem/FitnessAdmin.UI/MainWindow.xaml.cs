using FitnessReservatie.BL.Domein;
using FitnessReservatie.BL.Managers;
using FItnessReservatieDL;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace FitnessAdmin.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToestelManager tm;
        public MainWindow()
        {
            InitializeComponent();
            tm = new ToestelManager(new ToestelRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));
            ToestelListbox.ItemsSource = tm.ZoekAlleToestellen();
            ToestelTypeComboBox.ItemsSource = tm.KiesToestel();
        }

        private void voegToestelToe_Click(object sender, RoutedEventArgs e)
        {
            VoegToestelToe voegtoesteltoe = new VoegToestelToe();
            voegtoesteltoe.ShowDialog();
        }

        private void ZetBuitenDienst_Click(object sender, RoutedEventArgs e)
        {
            Toestel selectedItem = (Toestel)ToestelListbox.SelectedItem;
            tm.MaakToestelOnbeschikbaar(selectedItem.Id);
        }

        private void ZetIndienst_Click(object sender, RoutedEventArgs e)
        {
            Toestel selectedItem = (Toestel)ToestelListbox.SelectedItem;
            tm.MaakToestelBeschikbaar(selectedItem.Id);
        }

        private void VerwijderToestel_Click(object sender, RoutedEventArgs e)
        {
            Toestel selectedItem = (Toestel)ToestelListbox.SelectedItem;
            //int toestelID = int.Parse(selectedItem.Split('-')[0]);
            tm.VerwijderToestel(selectedItem.Id);
            
        }

        private void ToestelIDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ToestelTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToestelListbox.ItemsSource = tm.ZoekAlleToestellenVanType((string)ToestelTypeComboBox.SelectedItem);
        }

        private void ToestelListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            VoegToestelToeBtn.IsEnabled = true;
            ZetBuitenDienstBtn.IsEnabled = true;
            ZetIndientBtn.IsEnabled = true;
            VerwijderToestel.IsEnabled = true;
        }
    }
}
