using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Salon
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string WebSajt { get; set; }
        public string PIB { get; set; }
        public string MaticniBroj { get; set; }
        public string BrojZiroRacuna { get; set; }
        public bool Obrisan { get; set; }
    }
}
