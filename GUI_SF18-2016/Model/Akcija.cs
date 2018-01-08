using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Akcija : INotifyPropertyChanged
    {
        //Proba
        public int id;
        public DateTime datumPocetka;
        public double popust;
        public DateTime datumZavrsetka;
        public bool obrisana;

        public int Id { get { return id; } set { if (value != id) { id = value; OnPropertyChanged("Id"); } } }
        public DateTime DatumPocetka { get { return datumPocetka; } set { if (value != datumPocetka) { datumPocetka = value; OnPropertyChanged("DatumPocetka"); } } }
        public double Popust { get { return popust; } set { if (value != popust) { popust = value; OnPropertyChanged("Popust"); } } }
        public DateTime DatumZavrsetka { get { return datumZavrsetka; } set { if (value != datumZavrsetka) { datumZavrsetka = value; OnPropertyChanged("DatumZavrsetka"); } } }
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
