using POP_SF_18_2016.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_18_2016.Model
{
    public class Projekat
    {
        public static Projekat Instanca { get; private set; } = new Projekat();

        private List<TipNamestaja> tipoviNamestajaLista;
        private List<Namestaj> namestajLista;
        private List<Akcija> akcijeLista;
        private List<DodatneUsluge> dodatneUslugeLista;
        private List<Korisnik> korisniciLista;
        //private List<ProdajaNamestaja> ProdajaNamestajaLista;
        private List<Salon> salonLista;

        public List<TipNamestaja> TipoviNamestajaLista
        {
            get
            {
                tipoviNamestajaLista = GenericSerializer.Deserialize<TipNamestaja>("tipovi_namestaja.xml");
                return tipoviNamestajaLista;
            }
            set
            {
                tipoviNamestajaLista = value;
                GenericSerializer.Serialize<TipNamestaja>("tipovi_namestaja.xml", tipoviNamestajaLista);
            }
        }

        public List<Namestaj> NamestajLista
        {
            get
            {
                namestajLista = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return namestajLista;
            }
            set
            {
                namestajLista = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestajLista);
            }
        }

        public List<Akcija> AkcijeLista
        {
            get
            {
                akcijeLista = GenericSerializer.Deserialize<Akcija>("akcija.xml");
                return akcijeLista;
            }
            set
            {
                akcijeLista = value;
                GenericSerializer.Serialize<Akcija>("akcija.xml", akcijeLista);
            }
        }

        public List<DodatneUsluge> DodatneUslugeLista
        {
            get
            {
                dodatneUslugeLista = GenericSerializer.Deserialize<DodatneUsluge>("dodatne_usluge.xml");
                return dodatneUslugeLista;
            }
            set
            {
                dodatneUslugeLista = value;
                GenericSerializer.Serialize<DodatneUsluge>("dodatne_usluge.xml", dodatneUslugeLista);
            }
        }

        public List<Korisnik> KorisniciLista
        {
            get
            {
                korisniciLista = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
                return korisniciLista;
            }
            set
            {
                korisniciLista = value;
                GenericSerializer.Serialize<Korisnik>("korisnici.xml", korisniciLista);
            }
        }

        /*
        public List<ProdajaNamestaja> ProdajaNamestaja
        {
            get
            {
                ProdajaNamestajaLista = GenericSerializer.Deserialize<ProdajaNamestaja>("prodaja_namestaja.xml");
                return ProdajaNamestajaLista;
            }
            set
            {
                ProdajaNamestajaLista = value;
                GenericSerializer.Serialize<ProdajaNamestaja>("prodaja_namestaja.xml", ProdajaNamestajaLista);
            }
        }
        */

        public List<Salon> SalonLista
        {
            get
            {
                salonLista = GenericSerializer.Deserialize<Salon>("salon.xml");
                return salonLista;
            }
            set
            {
                salonLista = value;
                GenericSerializer.Serialize<Salon>("salon.xml", salonLista);
            }
        }
    }
}
