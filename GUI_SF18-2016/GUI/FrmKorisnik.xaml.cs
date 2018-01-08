using POP_SF_18_2016.Model;
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

namespace GUI_SF18_2016.GUI
{
    /// <summary>
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {

        public string vrstaPristupa = "";
        public Korisnik korisnikIzmena = null;

        public FrmKorisnik()
        {
            InitializeComponent();

            cbTipKorisnika.Items.Add("Administrator");
            cbTipKorisnika.Items.Add("Prodavac");
            cbTipKorisnika.SelectedIndex = 0;
        }

        public void inicijalizujIzmenu()
        {
            if (vrstaPristupa == "izmena" && korisnikIzmena != null)
            {

                tbIme.Text = korisnikIzmena.Ime;
                tbPrezime.Text = korisnikIzmena.Prezime;
                tbKorisnickoIme.Text = korisnikIzmena.KorisnickoIme;
                tbLozinka.Text = korisnikIzmena.Lozinka;

                TipKorisnika tip = korisnikIzmena.Tip;
                if (tip == TipKorisnika.Administrator)
                    cbTipKorisnika.SelectedItem = "Administrator";
                else
                    cbTipKorisnika.SelectedItem = "Prodavac";


                btnUpisi.Content = "Izmena";
            }
        }


        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpisi_Click(object sender, RoutedEventArgs e)
        {

            if (vrstaPristupa == "izmena")
            {
                foreach (Korisnik korisnik in MainWindow.listaKorisnika)
                {
                    if (korisnik.Id == korisnikIzmena.Id)
                    {

                        korisnik.Ime = tbIme.Text;
                        korisnik.Prezime = tbPrezime.Text;
                        korisnik.KorisnickoIme = tbKorisnickoIme.Text;
                        korisnik.Lozinka = tbLozinka.Text;

                        if (cbTipKorisnika.SelectedItem.ToString() == "Administrator")
                            korisnik.Tip = TipKorisnika.Administrator;
                        else
                            korisnik.Tip = TipKorisnika.Prodavac;

                    }
                }
            }
            else
            {
                int noviId = 0;
                foreach (Korisnik kor in MainWindow.listaKorisnika)
                {
                    if (kor.Id > noviId)
                        noviId = kor.Id;
                }
                noviId++;

                Korisnik noviKorisnik = new Korisnik();
                noviKorisnik.Id = noviId;
                noviKorisnik.Ime = tbIme.Text;
                noviKorisnik.Prezime = tbPrezime.Text;
                noviKorisnik.KorisnickoIme = tbKorisnickoIme.Text;
                noviKorisnik.Lozinka = tbLozinka.Text;

                if (cbTipKorisnika.SelectedItem.ToString() == "Administrator")
                    noviKorisnik.Tip = TipKorisnika.Administrator;
                else
                    noviKorisnik.Tip = TipKorisnika.Prodavac;

                noviKorisnik.obrisan = false;

                MainWindow.listaKorisnika.Add(noviKorisnik);
            }


            this.Close();
        }
    }
}
