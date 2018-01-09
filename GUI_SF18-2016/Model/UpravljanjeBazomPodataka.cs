using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using POP_SF_18_2016.Model;

namespace GUI_SF18_2016.Model
{
    public class UpravljanjeBazomPodataka
    {
        private static string conn = "Server=localhost\\sqlexpress; Database=salon; Integrated Security=True;";

        public static void dodajPodatakUTabelu(string insertUpdatePodatka)
        {

            using (SqlConnection connection = new SqlConnection(conn))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = insertUpdatePodatka;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static ObservableCollection<Akcija> ucitajAkcije()
        {

            ObservableCollection<Akcija> listaAkcije = new ObservableCollection<Akcija>();
            SqlConnection connection;
            SqlCommand command;
            string sql = "select * from Akcija;";
            SqlDataReader dataReader;
            connection = new SqlConnection(conn);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader.GetValue(0).ToString());
                    DateTime datumPocetka = Convert.ToDateTime(dataReader.GetValue(1).ToString());
                    double popust = Convert.ToDouble(dataReader.GetValue(2).ToString());
                    DateTime datumZavrsetka = Convert.ToDateTime(dataReader.GetValue(3).ToString());
                    bool obrisana = Convert.ToBoolean(dataReader.GetValue(4).ToString());

                    Akcija akcija = new Akcija(id, datumPocetka, popust, datumZavrsetka, obrisana);
                    listaAkcije.Add(akcija);

                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return listaAkcije;

        }

        public static ObservableCollection<Namestaj> ucitajNamestaje()
        {

            ObservableCollection<Namestaj> listaNamestaji = new ObservableCollection<Namestaj>();
            SqlConnection connection;
            SqlCommand command;
            string sql = "select * from Namestaj;";
            SqlDataReader dataReader;

            connection = new SqlConnection(conn);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader.GetValue(0).ToString());
                    string naziv = dataReader.GetValue(1).ToString();
                    string sifra = dataReader.GetValue(2).ToString();
                    double cena = Convert.ToDouble(dataReader.GetValue(3).ToString());
                    int kolicinaUMagacinu = Convert.ToInt32(dataReader.GetValue(4).ToString());
                    int akcijaID = Convert.ToInt32(dataReader.GetValue(5).ToString());
                    int tipNamestajaID = Convert.ToInt32(dataReader.GetValue(6).ToString());
                    bool obrisan = Convert.ToBoolean(dataReader.GetValue(7).ToString());

                    Namestaj namestaj = new Namestaj(id, naziv, sifra, cena, kolicinaUMagacinu, akcijaID, tipNamestajaID, obrisan);
                    listaNamestaji.Add(namestaj);


                }
                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return listaNamestaji;

        }

       


        public static ObservableCollection<Prodaja> ucitajProdaje()
        {

            ObservableCollection<Prodaja> listaProdaje = new ObservableCollection<Prodaja>();
            SqlConnection connection;
            SqlCommand command;
            string sql = "select * from Prodaja;";
            SqlDataReader dataReader;

            connection = new SqlConnection(conn);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader.GetValue(0).ToString());
                    int idNamestaj = Convert.ToInt32(dataReader.GetValue(1).ToString());
                    DateTime datumProdaje = Convert.ToDateTime(dataReader.GetValue(2).ToString());
                    string brojRacuna = dataReader.GetValue(3).ToString();
                    string kupac = dataReader.GetValue(4).ToString();
                    double ukupnaCena = Convert.ToDouble(dataReader.GetValue(5).ToString());
                    bool obrisana = Convert.ToBoolean(dataReader.GetValue(6).ToString());


                    Prodaja prodaja = new Prodaja(id, idNamestaj, datumProdaje, brojRacuna, kupac, ukupnaCena, obrisana);
                    listaProdaje.Add(prodaja);

                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {

            }

            return listaProdaje;

        }
    }
}
