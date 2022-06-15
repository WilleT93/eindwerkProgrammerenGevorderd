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
    /// Interaction logic for ReservatieWindow.xaml
    /// </summary>
    public partial class ReservatieWindow : Window
    {
        private ReservatieManager rm;
        private TijdslotManager tm;
        private ToestelManager toem;
        int KlantId;
        public ReservatieWindow(int klantId)
        {
            InitializeComponent();
            rm = new ReservatieManager(new ReservatieRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));
            tm = new TijdslotManager(new TijdslotRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));
            toem = new ToestelManager(new ToestelRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));

            this.KlantId = klantId;
            datePicker.DisplayDateStart = DateTime.Today.AddDays(1);
            datePicker.DisplayDateEnd = DateTime.Today.AddDays(7);
            TijdslotComboBox.ItemsSource = tm.KiesTijdslot();
            ToestelComboBox.ItemsSource = toem.KiesToestel();
    }
        private void MaakReservatieBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime? selectedDatum = null;
            string selectedToestelType = null;
            int? selectedTijdslotId = null;
            try
            {
                int Klant_id = this.KlantId;
                selectedDatum = datePicker.SelectedDate;
                selectedTijdslotId = ++TijdslotComboBox.SelectedIndex;
                selectedToestelType = (string)ToestelComboBox.SelectedItem;
                rm.MaakReservatie(Klant_id, selectedDatum, selectedTijdslotId,selectedToestelType) ;
                //    int reservatieId = rm.SchrijfReservatieInDB(Klant_id, selectedDatum);
                //}
                //catch (Exception ex)
                //{
                //    if (datareservatie.SelectDate < DateTime.Today.AddDays(1))
                //    {

                //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToestelComboBox.IsEnabled=true;
        }


        private void ToestelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TijdslotComboBox.IsEnabled = true;
        }

        private void TijdslotComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MaakReservatieBtn.IsEnabled = true;
        }

    }
}
