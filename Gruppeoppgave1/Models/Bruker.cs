using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Bruker
    {
        [Key]
        public string Epost { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Adresse { get; set; }
        public string Passord { get; set; }
        public string Telefon { get; set; }
        public string Fødselsdato { get; set; }
    }
}