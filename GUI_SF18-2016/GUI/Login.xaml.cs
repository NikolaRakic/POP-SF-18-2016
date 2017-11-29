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
using System.Windows.Shapes;

namespace GUI_SF_13_2016.GUI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = tbKorisnickoIme.Text;
            string lozinka = tbLozinka.Text;

            //List<Korisnik>
            MessageBox.Show("Ulogovan!!!!");

        }
    }
}
