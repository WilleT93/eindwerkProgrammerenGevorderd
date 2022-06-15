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

namespace FitnessAdmin.UI
{
    /// <summary>
    /// Interaction logic for VoegToestelToe.xaml
    /// </summary>
    public partial class VoegToestelToe : Window
    {
        private ToestelManager tm;

        public VoegToestelToe()
        {
            InitializeComponent();
            tm = new ToestelManager(new ToestelRepoADO(ConfigurationManager.ConnectionStrings["FitnessDBConnection"].ToString()));


        }

        private void VoegToeBtn_Click(object sender, RoutedEventArgs e)
        {
            string type = VoegToeBox.Text;
            tm.VoegToestelToe(type);
            DialogResult = true;
            Close();
        }
    }
}
