using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac

    }



    public class Korisnik : INotifyPropertyChanged
    {

        public int id; 
        public string ime; 
        public string prezime; 
        public string korisnickoIme; 
        public string lozinka; 
        public TipKorisnika tip; 
        public bool obrisan;

        public Korisnik() { }
        public Korisnik(int id, string ime, string prezime, string korisnickoIme, string lozinka, TipKorisnika tip, bool obrisan)
        {
            this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.tip = tip;
            this.obrisan = obrisan;
        }

        public int Id { get { return id; } set { if (value != id) { id = value; OnPropertyChanged("Id"); } } }
        public string Ime { get { return ime; } set { if (value != ime) { ime = value; OnPropertyChanged("Ime"); } } }
        public string Prezime { get { return prezime; } set { if (value != prezime) { prezime = value; OnPropertyChanged("Prezime"); } } }
        public string KorisnickoIme { get { return korisnickoIme; } set { if (value != korisnickoIme) { korisnickoIme = value; OnPropertyChanged("KorisnickoIme"); } } }
        public string Lozinka { get { return lozinka; } set { if (value != lozinka) { lozinka = value; OnPropertyChanged("Lozinka"); } } }
        public TipKorisnika Tip { get { return tip; } set { if (value != tip) { tip = value; OnPropertyChanged("Tip"); } } }
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
