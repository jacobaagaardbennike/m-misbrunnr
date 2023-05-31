using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePlatformen_CPR_1.Models
{
    public class Person
    {
        public string Pnr { get; set; }
        public string Koen { get; set; }
        public DateTime Foedselsdato { get; set; }
        public bool FoedselsdatoUsikkerhedsmarkering { get; set; }
        public int Status { get; set; }
        public string Civilstand { get; set; }
        public bool NavneOgAdressebeskyttelse { get; set; }
        public string Adresseringsnavn { get; set; }
        public string Standardadresse { get; set; }
        public int Postnummer { get; set; }
        public string Postdistrikt { get; set; }
        public string Vejadresseringsnavn { get; set; }
        public string Husnummer { get; set; }
        public string Etage { get; set; }
        public string Sidedoer { get; set; }
        public int Kommunekode { get; set; }
        public int Vejkode { get; set; }
        public DateTime Tilflytningsdato { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
    }
}
