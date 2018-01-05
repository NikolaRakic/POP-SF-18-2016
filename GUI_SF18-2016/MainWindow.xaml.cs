using POP_SF_18_2016.Model;
using POP_SF_18_2016.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GUI_SF18_2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string vrstaPrikaza = "namestaj";
        public static ObservableCollection<Namestaj> listaNamestaja;
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.Visibility = Visibility.Hidden;
            glavniMenu.Visibility = Visibility.Hidden;
            menuPrikazNamestaja.Visibility = Visibility.Hidden;
            menuPrikazProdaja.Visibility = Visibility.Hidden;
            menuPrikazKorisnika.Visibility = Visibility.Hidden;
            btnDodaj.Visibility = Visibility.Hidden;

            listaNamestaja = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));

        }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {
            lbKorisnickoIme.Visibility = Visibility.Hidden;
            tbKorisnickoIme.Visibility = Visibility.Hidden;
            lbLozinka.Visibility = Visibility.Hidden;
            tbLozinka.Visibility = Visibility.Hidden;
            btnPrijaviSe.Visibility = Visibility.Hidden;

            dataGrid.Visibility = Visibility.Visible;
            glavniMenu.Visibility = Visibility.Visible;
            menuPrikazNamestaja.Visibility = Visibility.Visible;
            menuPrikazProdaja.Visibility = Visibility.Visible;
            menuPrikazKorisnika.Visibility = Visibility.Visible;
            btnDodaj.Visibility = Visibility.Visible;

        }

        private void mniPrikazProdaja(object sender, RoutedEventArgs e)
        {

        }

        private void mniPrikazKorisnika(object sender, RoutedEventArgs e)
        {

        }

        private void mniPrikazNamestaja(object sender, RoutedEventArgs e)
        {
            vrstaPrikaza = "namestaj";
            dataGrid.ItemsSource = listaNamestaja;

        }
    }
}
