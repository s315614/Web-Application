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
                    KategoriNavn = k.Kategorier.KatgoriNavn

                }).ToList();

                return alleFilmer;
            }
        }


        public bool lagreFilm(Film lagreFilm)
        {

            using (var db = new DBContext())
            {
                try
                {
                    var nyFilmRad = new Filmer();

                    nyFilmRad.Navn = lagreFilm.Navn;
                    nyFilmRad.Bilde = lagreFilm.Bilde;

                    nyFilmRad.Beskrivelse = lagreFilm.Beskrivelse;
                    nyFilmRad.Pris = lagreFilm.Pris;
     

                    db.Filmer.Add(nyFilmRad);
                    db.SaveChanges();
                    return true;

                }
                catch (Exception feil)
                {
                    return false;
                }
            }
        }

        public Film hentFilm(int id)
        {
            using (var db = new DBContext())
            {
                Filmer enFilm = db.Filmer.Find(id);
                var hentetFilm = new Film()
                {
                    Navn = enFilm.Navn,
                Bilde = enFilm.Bilde,

                Beskrivelse = enFilm.Beskrivelse,
                Pris = enFilm.Pris
            };

                return hentetFilm;
            }
        }

        public bool slett(int id)
        {
            using (var db = new DBContext())
            {
                try
                {
                    var slettObjekt = db.Filmer.Find(id);
                    db.Filmer.Remove(slettObjekt);
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
