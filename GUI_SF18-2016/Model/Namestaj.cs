using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Namestaj
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public double Cena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public int AkcijaID { get; set; }
        public int TipNamestajaID { get; set; }

        public bool Obrisan { get; set; }
    }
}
