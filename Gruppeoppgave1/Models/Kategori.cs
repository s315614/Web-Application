using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{

    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        public string KatgoriNavn { get; set; }
    }
}