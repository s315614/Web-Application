using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1
{
    public class DBKategori
    {
        public List<Katagori> AlleKategorier()
        {
            using (var db = new DBContext())
            {
                List<Katagori> AlleKategorier = db.Kategorier.Select(k => new Katagori
                {
                    KategoriId = k.KategoriId,
                    KatgoriNavn = k.KatgoriNavn


                }).ToList();

                return AlleKategorier;
            }
        }
        public Katagori hentkategori(int KategoriId)
        {
            using (var db = new DBContext())
            {
                Kategorier enKategori = db.Kategorier.Find(KategoriId);
                var hentetKategori = new Katagori()
                {
                    KatgoriNavn = enKategori.KatgoriNavn

                };

                return hentetKategori;
            }
        }
    }
}