using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1
{
    public class DBBruker
    {
        public List<Bruker> alleBrukere()
        {
            using (var db = new DBContext())
            {
                List<Bruker> alleBrukere = db.Brukere.Select(k => new Bruker
                {
                    Epost = k.Epost,
                    Fornavn = k.Fornavn,
                    Etternavn = k.Etternavn,
                    Adresse = k.Adresse,
                    Passord = k.Passord,
                    Telefon = k.Telefon,
                    Fødselsdato = k.Fødselsdato
                }).ToList();

                return alleBrukere;
            }
        }
    }
}
