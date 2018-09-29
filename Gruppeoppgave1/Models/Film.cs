﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public double Pris { get; set; }

        public virtual List<Kategori> KategoriId { get; set; }
    }
}