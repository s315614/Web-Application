using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class Order
    {
        [Key]
        public int OrdrerId { get; set; }
        public string OrdreDate { get; set; }

        public Brukere BrukereId { get; set; }

        public Filmer FilmerId { get; set; }

    }
}