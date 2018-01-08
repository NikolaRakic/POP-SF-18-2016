using GUI_SF18_2016.GUI;
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
        public static ObservableCollection<Korisnik> listaKorisnika;
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.Visibility = Visibility.Hidden;
            glavniMenu.Visibility = Visibility.Hidden;
            menuPrikazNamestaja.Visibility = Visibility.Hidden;
            menuPrikazProdaja.Visibility = Visibility.Hidden;
            menuPrikazKorisnika.Visibility = Visibility.Hidden;
            btnDodaj.Visibility = Visibility.Hidden;
            btnIzmeni.Visibility = Visibility.Hidden;
            btnBrisi.Visibility = Visibility.Hidden;

            listaNamestaja = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));
            listaKorisnika = new ObservableCollection<Korisnik>();

            dataGrid.ItemsSource = listaNamestaja;

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
            btnIzmeni.Visibility = Visibility.Visible;
            btnBrisi.Visibility = Visibility.Visible;

        }

        private void mniPrikazProdaja(object sender, RoutedEventArgs e)
        {

        }

        private void mniPrikazKorisnika(object sender, RoutedEventArgs e)
        {
            vrstaPrikaza = "korisnik";
            dataGrid.ItemsSource = listaKorisnika;
        }

        private void mniPrikazNamestaja(object sender, RoutedEventArgs e)
        {
            vrstaPrikaza = "namestaj";
            dataGrid.ItemsSource = listaNamestaja;

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (vrstaPrikaza == "namestaj") {
                FrmNamestaj frm = new FrmNamestaj();
                frm.ShowDialog();
            }
            if (vrstaPrikaza == "korisnik")
            {
                FrmKorisnik frm = new FrmKorisnik();
                frm.ShowDialog();
            }

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (vrstaPrikaza == "namestaj")
            {
                if (dataGrid.SelectedIndex != -1 && listaNamestaja.Count > 0)
                {

                    Namestaj namestaj = (Namestaj)dataGrid.SelectedItem;

                    FrmNamestaj frm = new FrmNamestaj();
                    frm.vrstaPristupa = "izmena";
                    frm.namestajIzmena = namestaj;
                    frm.inicijalizujIzmenu();

                    frm.Owner = this;
                    frm.ShowDialog();

                    dataGrid.Items.Refresh();

                }
            }

            if (vrstaPrikaza == "korisnik")
            {
                if (dataGrid.SelectedIndex != -1 && listaKorisnika.Count > 0)
                {

                    Korisnik korisnik = (Korisnik)dataGrid.SelectedItem;

                    FrmKorisnik frm = new FrmKorisnik();
                    frm.vrstaPristupa = "izmena";
                    frm.korisnikIzmena = korisnik;
                    frm.inicijalizujIzmenu();

                    frm.Owner = this;
                    frm.ShowDialog();

                    dataGrid.Items.Refresh();

                }
            }
        }

        private void btnBrisi_Click(object sender, RoutedEventArgs e)
        {
            if (vrstaPrikaza == "namestaj")
            {
                if (dataGrid.SelectedIndex != -1 && listaNamestaja.Count > 0)
                {
                    Namestaj namestaj = (Namestaj)dataGrid.SelectedItem;

                    FrmPotvrdaBrisanja frm = new FrmPotvrdaBrisanja();
                    frm.ShowDialog();

                    if (frm.DialogResult.HasValue && frm.DialogResult.Value)
                    {
                        for (int i = 0; i < listaNamestaja.Count; i++)
                        {
                            if (listaNamestaja.ElementAt(i).Id == namestaj.Id)
                            {
                                listaNamestaja.ElementAt(i).obrisan = true; //logicko brisanje
                                //listaNamestaja.RemoveAt(i);
                            }
                        }

                        dataGrid.Items.Refresh();
                    }
                }
            }

            if (vrstaPrikaza == "korisnik")
            {
                if (dataGrid.SelectedIndex != -1 && listaKorisnika.Count > 0)
                {
                    Korisnik korisnik = (Korisnik)dataGrid.SelectedItem;

                    FrmPotvrdaBrisanja frm = new FrmPotvrdaBrisanja();
                    frm.ShowDialog();

                    if (frm.DialogResult.HasValue && frm.DialogResult.Value)
                    {
                        for (int i = 0; i < listaKorisnika.Count; i++)
                        {
                            if (listaKorisnika.ElementAt(i).Id == korisnik.Id)
                            {
                                listaKorisnika.ElementAt(i).obrisan = true; 
                            }
                        }

                        dataGrid.Items.Refresh();
                    }
                }
            }
        }
    }
}
