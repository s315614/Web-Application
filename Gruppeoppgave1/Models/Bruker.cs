using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


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
        public int Telefon { get; set; }
        public string Følsesdato { get; set; }
    }
}