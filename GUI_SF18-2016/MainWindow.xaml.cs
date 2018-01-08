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
        public static ObservableCollection<Akcija> listaAkcija;
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
            btnOdjava.Visibility = Visibility.Hidden;

            listaNamestaja = new ObservableCollection<Namestaj>(GenericSerializer.Deserialize<Namestaj>("namestaj.xml"));
            listaAkcija = new ObservableCollection<Akcija>();
            listaKorisnika = new ObservableCollection<Korisnik>();


            listaKorisnika.Add(new Korisnik(1, "Petar", "Petrovic", "admin", "admin", TipKorisnika.Administrator, false));
            listaKorisnika.Add(new Korisnik(2, "Slavoljub", "Slavoljubovic", "prod", "prod", TipKorisnika.Prodavac, false));


            dataGrid.ItemsSource = listaNamestaja;

        }

        private void btnPrijaviSe_Click(object sender, RoutedEventArgs e)
        {

            bool postoji = false;
            TipKorisnika tip = TipKorisnika.Prodavac;
            foreach (Korisnik k in listaKorisnika) {

                if (k.KorisnickoIme == tbKorisnickoIme.Text && k.Lozinka == tbLozinka.Text)
                {
                    postoji = true;
                    if (k.Tip == TipKorisnika.Administrator)
                        tip = TipKorisnika.Administrator;
                }
            }

            if (postoji && tip==TipKorisnika.Administrator)
            {
                lbKorisnickoIme.Visibility = Visibility.Hidden;
                tbKorisnickoIme.Visibility = Visibility.Hidden;
                lbLozinka.Visibility = Visibility.Hidden;
                tbLozinka.Visibility = Visibility.Hidden;
                btnPrijaviSe.Visibility = Visibility.Hidden;

                dataGrid.Visibility = Visibility.Visible;
                glavniMenu.Visibility = Visibility.Visible;
                menuPrikazNamestaja.Visibility = Visibility.Visible;
                menuPrikazAkcija.Visibility = Visibility.Visible;
                menuPrikazProdaja.Visibility = Visibility.Visible;
                menuPrikazKorisnika.Visibility = Visibility.Visible;
                btnDodaj.Visibility = Visibility.Visible;
                btnIzmeni.Visibility = Visibility.Visible;
                btnBrisi.Visibility = Visibility.Visible;
                btnOdjava.Visibility = Visibility.Visible;
            }
            else if (postoji && tip == TipKorisnika.Prodavac)
            {
                lbKorisnickoIme.Visibility = Visibility.Hidden;
                tbKorisnickoIme.Visibility = Visibility.Hidden;
                lbLozinka.Visibility = Visibility.Hidden;
                tbLozinka.Visibility = Visibility.Hidden;
                btnPrijaviSe.Visibility = Visibility.Hidden;

                dataGrid.Visibility = Visibility.Visible;
                glavniMenu.Visibility = Visibility.Visible;
                menuPrikazNamestaja.Visibility = Visibility.Visible;
                menuPrikazAkcija.Visibility = Visibility.Hidden;
                menuPrikazProdaja.Visibility = Visibility.Visible;
                menuPrikazKorisnika.Visibility = Visibility.Hidden;
                btnDodaj.Visibility = Visibility.Hidden;
                btnIzmeni.Visibility = Visibility.Hidden;
                btnBrisi.Visibility = Visibility.Hidden;
                btnOdjava.Visibility = Visibility.Visible;
            }
            else {
                MessageBox.Show("Pogresno korisnicko ime/sifra");
            }

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
        private void mniPrikazAkcija(object sender, RoutedEventArgs e)
        {
            vrstaPrikaza = "akcija";
            dataGrid.ItemsSource = listaAkcija;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (vrstaPrikaza == "namestaj") {
                FrmNamestaj frm = new FrmNamestaj();
                frm.ShowDialog();
            }
            if (vrstaPrikaza == "akcija")
            {
                FrmAkcija frm = new FrmAkcija();
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


                }
            }

            if (vrstaPrikaza == "akcija")
            {
                if (dataGrid.SelectedIndex != -1 && listaAkcija.Count > 0)
                {

                    Akcija akcija = (Akcija)dataGrid.SelectedItem;

                    FrmAkcija frm = new FrmAkcija();
                    frm.vrstaPristupa = "izmena";
                    frm.akcijaIzmena = akcija;
                    frm.inicijalizujIzmenu();

                    frm.Owner = this;
                    frm.ShowDialog();


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
                                dataGrid.Items.Refresh();
                            }
                        }

                    }
                }
            }

            if (vrstaPrikaza == "akcija")
            {
                if (dataGrid.SelectedIndex != -1 && listaAkcija.Count > 0)
                {
                    Akcija akcija = (Akcija)dataGrid.SelectedItem;

                    FrmPotvrdaBrisanja frm = new FrmPotvrdaBrisanja();
                    frm.ShowDialog();

                    if (frm.DialogResult.HasValue && frm.DialogResult.Value)
                    {
                        for (int i = 0; i < listaAkcija.Count; i++)
                        {
                            if (listaAkcija.ElementAt(i).Id == akcija.Id)
                            {
                                listaAkcija.ElementAt(i).Obrisana = true;
                                dataGrid.Items.Refresh();
                            }
                        }

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
                                dataGrid.Items.Refresh();
                            }
                        }

                    }
                }
            }
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            lbKorisnickoIme.Visibility = Visibility.Visible;
            tbKorisnickoIme.Visibility = Visibility.Visible;
            lbLozinka.Visibility = Visibility.Visible;
            tbLozinka.Visibility = Visibility.Visible;
            btnPrijaviSe.Visibility = Visibility.Visible;

            dataGrid.Visibility = Visibility.Hidden;
            glavniMenu.Visibility = Visibility.Hidden;
            menuPrikazNamestaja.Visibility = Visibility.Hidden;
            menuPrikazAkcija.Visibility = Visibility.Hidden;
            menuPrikazProdaja.Visibility = Visibility.Hidden;
            menuPrikazKorisnika.Visibility = Visibility.Hidden;
            btnDodaj.Visibility = Visibility.Hidden;
            btnIzmeni.Visibility = Visibility.Hidden;
            btnBrisi.Visibility = Visibility.Hidden;
            btnOdjava.Visibility = Visibility.Hidden;

            tbKorisnickoIme.Text = "";
            tbLozinka.Text = "";
        }
    }
}
