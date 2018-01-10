using GUI_SF18_2016.Model;
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
    /// Interaction logic for FrmProdaja.xaml
    /// </summary>
    public partial class FrmProdaja : Window
    {

        public string vrstaPristupa = "";
        public Prodaja prodajaIzmena = null;

        public FrmProdaja()
        {
            InitializeComponent();

            if (MainWindow.listaNamestaja.Count > 0)
            {
                foreach (Namestaj nam in MainWindow.listaNamestaja)
                {
                    if(!nam.Obrisan)
                        cbNamestajID.Items.Add(nam.Id);
                }
                cbNamestajID.SelectedIndex = 0;
                lbNazivNamestaja.Content = MainWindow.listaNamestaja.ElementAt(0).Naziv;
            }
        }

        public void inicijalizujIzmenu()
        {
            if (vrstaPristupa == "izmena" && prodajaIzmena != null)
            {

                cbNamestajID.SelectedItem = prodajaIzmena.IdNamestaj.ToString();

                foreach (Namestaj nam in MainWindow.listaNamestaja)
                {

                    if (nam.Id == Convert.ToInt32(prodajaIzmena.IdNamestaj))
                    {

                        lbNazivNamestaja.Content = nam.Naziv;
                    }
                }

                tbBrojRacuna.Text = prodajaIzmena.BrojRacuna;
                tbKupac.Text = prodajaIzmena.Kupac;
                lbUkupnaCena.Content = "Ukupna cena: " + prodajaIzmena.UkupnaCena;

                btnUpisi.Content = "Izmena";
            }
        }

        private void btnIzadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpisi_Click(object sender, RoutedEventArgs e)
        {

            double ukupnaCena = 0;

            foreach (Namestaj nam in MainWindow.listaNamestaja) {

                if (nam.Id == Convert.ToInt32(cbNamestajID.SelectedItem.ToString())) {

                    ukupnaCena += nam.Cena;
                }
            }

            if (chPrevoz.IsChecked == true)
                ukupnaCena += 1000;

            if (chMontaza.IsChecked == true)
                ukupnaCena += 1000;


            if (vrstaPristupa == "izmena")
            {
                foreach (Prodaja prodaja in MainWindow.listaProdaja)
                {
                    if (prodaja.Id == prodajaIzmena.Id)
                    {

                        prodaja.idNamestaj = Convert.ToInt32(cbNamestajID.SelectedItem.ToString());
                        prodaja.DatumProdaje = DateTime.Now;
                        prodaja.BrojRacuna = tbBrojRacuna.Text;
                        prodaja.Kupac = tbKupac.Text;
                        prodaja.UkupnaCena = ukupnaCena;

                        UpravljanjeBazomPodataka.dodajPodatakUTabelu(
                           "update Prodaja set idNamestaj='"
                           + prodaja.idNamestaj + "', datumProdaje='"
                           + prodaja.DatumProdaje + "', brojRacuna='"
                           + prodaja.BrojRacuna + "', kupac='"
                           + prodaja.Kupac + "', ukupnaCena='"
                           + prodaja.UkupnaCena + "'where id='" + prodaja.Id + "';");

                    }
                }
            }
            else
            {
                int noviId = 0;
                foreach (Prodaja prodaja in MainWindow.listaProdaja)
                {
                    if (prodaja.Id > noviId)
                        noviId = prodaja.Id;
                }
                noviId++;

                Prodaja novaProdaja = new Prodaja();
                novaProdaja.Id = noviId;
                novaProdaja.idNamestaj = Convert.ToInt32(cbNamestajID.SelectedItem.ToString());
                novaProdaja.DatumProdaje = DateTime.Now;
                novaProdaja.BrojRacuna = tbBrojRacuna.Text;
                novaProdaja.Kupac = tbKupac.Text;
                novaProdaja.UkupnaCena = ukupnaCena;
                novaProdaja.Obrisana = false;

                lbUkupnaCena.Content = "Ukupna cena: " + ukupnaCena;

                MainWindow.listaProdaja.Add(novaProdaja);

                UpravljanjeBazomPodataka.dodajPodatakUTabelu(
                    "insert into Prodaja(id,idNamestaj,datumProdaje,brojRacuna,kupac,ukupnaCena,obrisana) values('"
                    + novaProdaja.Id + "','"
                    + novaProdaja.idNamestaj + "','"
                    + novaProdaja.DatumProdaje + "','"
                    + novaProdaja.BrojRacuna + "','"
                    + novaProdaja.Kupac + "','"
                    + novaProdaja.UkupnaCena + "','"
                    + novaProdaja.Obrisana + "');");
            }

            //this.Close();



            /*
                     public int id;
        public int idNamestaj;
        public DateTime datumProdaje;
        public string brojRacuna;
        public string kupac;
        public double ukupnaCena;
        public bool obrisana;
             */
        }

        private void cbAkcijaID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Namestaj nam in MainWindow.listaNamestaja) {

                if (nam.Id == Convert.ToInt32(cbNamestajID.SelectedItem.ToString())) {

                    lbNazivNamestaja.Content = nam.Naziv;
                }
            }
        }
    }
}
