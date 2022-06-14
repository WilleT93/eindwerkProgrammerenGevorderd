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

namespace FitnessReservatie.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? klantID = null;
                string email;
                if(string.IsNullOrWhiteSpace(IdTextBox.Text) && string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    MessageBox.Show("Geef een geldig email of ID.");

                }
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    klantID = int.Parse(IdTextBox.Text);
                }
                email = EmailTextBox.Text;
                WelkomWindow welkomwindow = new WelkomWindow(klantID, email);
                welkomwindow.ShowDialog();

                //    if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                //    {  
                //        int KlantID=int.Parse(IdTextBox.Text);
                //        WelkomWindow welkomwindow = new WelkomWindow(KlantID);
                //        welkomwindow.ShowDialog();
                //    }
                //    else if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
                //    {
                //        string KlantEmail=EmailTextBox.Text;
                //        WelkomWindow welkomwindow = new WelkomWindow(KlantEmail);
                //        welkomwindow.ShowDialog();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Geef een ID of Email.");
                //    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "login");
            }
        }
    }
}
