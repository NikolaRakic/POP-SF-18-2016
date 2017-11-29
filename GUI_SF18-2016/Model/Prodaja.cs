using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Prodaja
    {
        public List<int> NamestajZaProdajuID { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public List<int> DodatneUslugeID { get; set; }

        public const double PDV = 0.02;
        public double UkupnaCena { get; set; }


        /// PROBASDaSDA
    }
}

