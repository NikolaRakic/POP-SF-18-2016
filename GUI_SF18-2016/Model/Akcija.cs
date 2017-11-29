using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Akcija
    {
        //Proba
        public int Id { get; set; }
        public DateTime DatumPocetka { get; set; }
        public decimal Popust { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool Obrisana { get; set; }
    }
}
