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

        public bool lagreBruker(Bruker innBruker)
        {

            using (var db = new DBContext())
            {
                try
                {
                    var nyBrukerRad = new Brukere();

                    nyBrukerRad.Epost = innBruker.Epost;
                    nyBrukerRad.Fornavn = innBruker.Fornavn;
                    nyBrukerRad.Etternavn = innBruker.Etternavn;

                    nyBrukerRad.Adresse = innBruker.Adresse;
                    nyBrukerRad.Telefon = innBruker.Telefon;
                    nyBrukerRad.Fødselsdato = innBruker.Fødselsdato;
                    nyBrukerRad.Passord = innBruker.Passord;

                    db.Brukere.Add(nyBrukerRad);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        

        public Bruker hentBruker(string epost)
            {
                using (var db = new DBContext())
                {
                    Brukere enBruker = db.Brukere.Find(epost);
                    var hentetBruker = new Bruker()
                    {
                        Epost = enBruker.Epost,
                        Fornavn = enBruker.Fornavn,
                        Etternavn = enBruker.Etternavn,
                        Adresse = enBruker.Adresse,
                        Telefon = enBruker.Telefon,
                        Fødselsdato = enBruker.Fødselsdato,
                        Passord = enBruker.Passord
                    };

                    return hentetBruker;
                }
            }






        public bool slett(string epost)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var slettObjekt = db.Brukere.Find(epost);
                    db.Brukere.Remove(slettObjekt);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }



    }


}
