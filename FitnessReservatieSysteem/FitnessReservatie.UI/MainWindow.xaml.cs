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
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {  
                    int KlantID=int.Parse(IdTextBox.Text);
                    WelkomWindow welkomwindow = new WelkomWindow(KlantID);
                    welkomwindow.ShowDialog();
                }
                else if (!string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    string KlantEmail=EmailTextBox.Text;
                    WelkomWindow welkomwindow = new WelkomWindow(KlantEmail);
                    welkomwindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Geef een ID of Email.");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"login");
            }
        }
    }
}
