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
using System.Windows.Shapes;

namespace FitnessReservatie.UI
{
    /// <summary>
    /// Interaction logic for WelkomWindow.xaml
    /// </summary>
    public partial class WelkomWindow : Window
    {
        private KlantManager km = new KlantManager(new KlantRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));
        private ReservatieManager rm = new ReservatieManager(new ReservatieRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));
        private int klantId;
        public WelkomWindow(int? KlantID, string KlantEmail)
        {
            InitializeComponent();
            Klant klant =  km.ZoekKlantDetails(KlantID, KlantEmail);
            string naamGebruiker = klant.Voornaam;
            welkomLabel.Content = $"Welkom, {naamGebruiker}";
            this.klantId = klant.Id;
            var reservaties = rm.ZoekReservatie(this.klantId);
            ReservatieListBox.ItemsSource = reservaties;
        }
        //public WelkomWindow(string KlantEmail)
        //{
        //    InitializeComponent();
        //}
        private void ReserveerBtn_Click(object sender, RoutedEventArgs e)
        {
            ReservatieWindow reservatiewindow = new ReservatieWindow(this.klantId);
            reservatiewindow.ShowDialog();

        }
    }
}
