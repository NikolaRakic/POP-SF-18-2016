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
    /// Interaction logic for FrmAkcija.xaml
    /// </summary>
    public partial class FrmAkcija : Window
    {

        public string vrstaPristupa = "";
        public Akcija akcijaIzmena = null;

        public FrmAkcija()
        {
            InitializeComponent();
        }

        public void inicijalizujIzmenu()
        {
            if (vrstaPristupa == "izmena" && akcijaIzmena != null)
            {

                dtPocetak.SelectedDate = akcijaIzmena.DatumPocetka;
                tbPopust.Text = akcijaIzmena.Popust.ToString();
                dtKraj.SelectedDate = akcijaIzmena.DatumZavrsetka;

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
                foreach (Akcija akcija in MainWindow.listaAkcija)
                {
                    if (akcija.Id == akcijaIzmena.Id)
                    {

                        akcija.DatumPocetka = dtPocetak.SelectedDate.Value;
                        akcija.Popust = Convert.ToDouble(tbPopust.Text);
                        akcija.DatumZavrsetka = dtKraj.SelectedDate.Value;

                        UpravljanjeBazomPodataka.dodajPodatakUTabelu(
                           "update Akcija set datumPocetka='"
                           + akcija.DatumPocetka + "', popust='"
                           + akcija.Popust + "', datumZavrsetka='"
                           + akcija.DatumZavrsetka +  "'where id='" + akcija.Id + "';");

                    }
                }
            }
            else
            {
                int noviId = 0;
                foreach (Akcija akc in MainWindow.listaAkcija)
                {
                    if (akc.Id > noviId)
                        noviId = akc.Id;
                }
                noviId++;

                Akcija novaAkcija = new Akcija();
                novaAkcija.Id = noviId;
                novaAkcija.DatumPocetka = dtPocetak.SelectedDate.Value;
                novaAkcija.Popust = Convert.ToDouble(tbPopust.Text);
                novaAkcija.DatumZavrsetka = dtKraj.SelectedDate.Value;
                novaAkcija.Obrisana = false;
               

                MainWindow.listaAkcija.Add(novaAkcija);

                UpravljanjeBazomPodataka.dodajPodatakUTabelu(
                   "insert into Akcija(id,datumPocetka,popust,datumZavrsetka,obrisana) values('"
                   + novaAkcija.Id + "','"
                   + novaAkcija.DatumPocetka + "','"
                   + novaAkcija.Popust + "','"
                   + novaAkcija.DatumZavrsetka + "','"
                   + novaAkcija.Obrisana + "');");
            }


            this.Close();
        }
    }
}
