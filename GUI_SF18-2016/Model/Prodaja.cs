using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Prodaja : INotifyPropertyChanged
    {
        public int id;
        public int idNamestaj;
        public DateTime datumProdaje;
        public string brojRacuna;
        public string kupac;
        public double ukupnaCena;
        public bool obrisana;

        public int Id { get { return id; } set { if (value != id) { id = value; OnPropertyChanged("Id"); } } }
        public int IdNamestaj { get { return idNamestaj; } set { if (value != idNamestaj) { idNamestaj = value; OnPropertyChanged("IdNamestaj"); } } }
        public DateTime DatumProdaje { get { return datumProdaje; } set { if (value != datumProdaje) { datumProdaje = value; OnPropertyChanged("DatumProdaje"); } } }
        public string BrojRacuna { get { return brojRacuna; } set { if (value != brojRacuna) { brojRacuna = value; OnPropertyChanged("BrojRacuna"); } } }
        public string Kupac { get { return kupac; } set { if (value != kupac) { kupac = value; OnPropertyChanged("Kupac"); } } }
        public double UkupnaCena { get { return ukupnaCena; } set { if (value != ukupnaCena) { ukupnaCena = value; OnPropertyChanged("UkupnaCena"); } } }
        public bool Obrisana { get { return obrisana; } set { if (value != obrisana) { obrisana = value; OnPropertyChanged("Obrisana"); } } }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}

