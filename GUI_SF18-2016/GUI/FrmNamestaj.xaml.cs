using POP_SF_18_2016.Model;
using POP_SF_18_2016.Utils;
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
    /// Interaction logic for FrmNamestaj.xaml
    /// </summary>
    public partial class FrmNamestaj : Window
    {
        public string vrstaPristupa = "";
        public Namestaj namestajIzmena = null;

        public List<TipNamestaja> listaTipova;
        public List<Akcija> listaAkcija;

        public FrmNamestaj()
        {
            InitializeComponent();

            listaTipova = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
            //listaAkcija = GenericSerializer.Deserialize<Akcija>("akcije.xml");

            foreach (TipNamestaja tipNam in listaTipova) {

                cbTipID.Items.Add(tipNam.Id);
            }
            if (listaTipova.Count > 0)
                lbTipNamestajaNaziv.Content = listaTipova.ElementAt(0).Naziv;

            
            /*
            foreach (Akcija akcija in listaAkcija)
            {

                cbAkcijaID.Items.Add(akcija.Id);
            }
            if (listaAkcija.Count > 0)
                lbAkcijaPopust.Content = listaAkcija.ElementAt(0).Popust;
                */
        }

        public void inicijalizujIzmenu() {
            if (vrstaPristupa == "izmena" && namestajIzmena != null) {

                tbNaziv.Text = namestajIzmena.Naziv;
                tbSifra.Text = namestajIzmena.Sifra;
                tbCena.Text = namestajIzmena.Cena.ToString();
                tbKolicina.Text = namestajIzmena.KolicinaUMagacinu.ToString();
                //cbAkcijaID.SelectedItem = namestajIzmena.AkcijaID;
                cbTipID.SelectedItem = namestajIzmena.TipNamestajaID;

                btnUpisi.Content = "Izmena";
            }
        }

        private void cbTipID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbTipNamestajaNaziv.Content = cbTipID.SelectedItem.ToString();
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpisi_Click(object sender, RoutedEventArgs e)
        {
            if (vrstaPristupa == "izmena")
            {
                foreach (Namestaj namestaj in MainWindow.listaNamestaja)
                {
                    if (namestaj.Id == namestajIzmena.Id)
                    {

                        namestaj.Naziv = tbNaziv.Text.Trim();
                        namestaj.Sifra = tbSifra.Text.Trim();
                        namestaj.Cena = Convert.ToDouble(tbCena.Text.Trim());
                        namestaj.KolicinaUMagacinu = Convert.ToInt32(tbKolicina.Text.Trim());
                        //namestaj.AkcijaID = Convert.ToInt32(cbAkcijaID.SelectedItem.ToString());
                        namestaj.TipNamestajaID = Convert.ToInt32(cbTipID.SelectedItem.ToString());

                    }
                }
            }
            else
            {
                int noviId = 0;
                foreach (Namestaj namestaj in MainWindow.listaNamestaja)
                {
                    if (namestaj.Id > noviId)
                        noviId = namestaj.Id;
                }
                noviId++;

                Namestaj noviNamestaj = new Namestaj();
                noviNamestaj.Id = noviId;
                noviNamestaj.Naziv = tbNaziv.Text.Trim();
                noviNamestaj.Sifra = tbSifra.Text.Trim();
                noviNamestaj.Cena = Convert.ToDouble(tbCena.Text.Trim());
                noviNamestaj.KolicinaUMagacinu = Convert.ToInt32(tbKolicina.Text.Trim());
                noviNamestaj.AkcijaID = 1;
                noviNamestaj.TipNamestajaID = Convert.ToInt32(cbTipID.SelectedItem.ToString());
                noviNamestaj.Obrisan = false;

                MainWindow.listaNamestaja.Add(noviNamestaj);
            }

            this.Close();


        }

    }
}
