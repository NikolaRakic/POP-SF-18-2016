using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Namestaj: INotifyPropertyChanged
    {
        public int id;
        public string naziv;
        public string sifra;
        public double cena;
        public int kolicinaUMagacinu;
        public int akcijaID;
        public int tipNamestajaID;
        public bool obrisan;

        public int Id{ get { return id; } set { if (value != id) { id = value; OnPropertyChanged("Id"); } } }
        public string Naziv { get { return naziv; } set { if (value != naziv) { naziv = value; OnPropertyChanged("Naziv"); } } }
        public string Sifra { get { return sifra; } set { if (value != sifra) { sifra = value; OnPropertyChanged("Sifra"); } } }
        public double Cena { get { return cena; } set { if (value != cena) { cena = value; OnPropertyChanged("Cena"); } } }
        public int KolicinaUMagacinu { get { return kolicinaUMagacinu; } set { if (value != kolicinaUMagacinu) { kolicinaUMagacinu = value; OnPropertyChanged("KolicinaUMagacinu"); } } }
        public int AkcijaID { get { return akcijaID; } set { if (value != akcijaID) { akcijaID = value; OnPropertyChanged("AkcijaID"); } } }
        public int TipNamestajaID { get { return tipNamestajaID; } set { if (value != tipNamestajaID) { tipNamestajaID = value; OnPropertyChanged("TipNamestajaID"); } } }
        public bool Obrisan { get { return obrisan; } set { if (value != obrisan) { obrisan = value; OnPropertyChanged("Obrisan"); } } }


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
