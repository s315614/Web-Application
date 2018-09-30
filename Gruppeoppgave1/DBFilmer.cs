using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1
{
    public class DBFilmer
    {
        public List<Film> alleFilmer()
        {
            using (var db = new DBContext())
            {
                List<Film> alleFilmer= db.Filmer.Select(k => new Film
                {
                    Id = k.Id,
                    Navn = k.Navn,
                    Bilde = k.Bilde,
                    Beskrivelse = k.Beskrivelse,
                    Pris = k.Pris,
                    KategoriId = k.Kategorier.KategoriId
                    

                }).ToList();

                return alleFilmer;
            }
        }

       
    }
}
