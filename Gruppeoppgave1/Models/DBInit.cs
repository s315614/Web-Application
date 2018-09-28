using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Gruppeoppgave1.Models
{
    public class DBInit : DropCreateDatabaseAlways<DB>
    {
        protected override void Seed(DB context)
        {
            var nyBruker1 = new Bruker
            {
                Epost = "myepost@epost.no",
                Fornavn = "Fornavn",
                Etternavn = "Etternavn",
                Adresse = "Oslomet 1, Oslo",
                Passord = "mypass",
                Telefon = 12345678,
                Følsesdato = "01/02/03"
            };

            var nyBruker2 = new Bruker
            {
                Epost = "myepost1@epost.no",
                Fornavn = "Fornavn1",
                Etternavn = "Etternavn1",
                Adresse = "Oslomet 11, Oslo",
                Passord = "mypass1",
                Telefon = 12345678,
                Følsesdato = "01/02/03"
            };
            var nyKategori1 = new Kategori
            {
                KategoriId = 1,
                KatgoriNavn = "Komedi"
            };
            var nyKategori2 = new Kategori
            {
                KategoriId = 2,
                KatgoriNavn = "Drama"
            };

            var nyKategori3 = new Kategori
            {
                KategoriId = 3,
                KatgoriNavn = "Horør"
            };

            var nyFilm1 = new Film
            {
                Id = 1,
                Navn = "Film1",
                Beskrivelse = "Film1 Beskrivelse",
                Pris = 50,
                //KategoriId = nyKategori1
            };
            var nyFilm2 = new Film
            {
                Id = 2,
                Navn = "Film2",
                Beskrivelse = "Film2 Beskrivelse",
                Pris = 40,
                //KategoriId = nyKategori2
            };


            var nyKategori = new List<Kategori>();
            nyKategori.Add(nyKategori1);
            nyKategori.Add(nyKategori2);
            nyKategori.Add(nyKategori3);

            var nyFilm = new List<Film>();
            nyFilm.Add(nyFilm1);
            nyFilm.Add(nyFilm2);

            var nyBruker = new List<Bruker>();
            nyBruker.Add(nyBruker1);
            nyBruker.Add(nyBruker2);


           
        }
    }
}