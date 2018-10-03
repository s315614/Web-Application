using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class DBInit : DropCreateDatabaseIfModelChanges<DBContext>
    {
        protected override void Seed(DBContext context)
        {

            var nyBruker = new Brukere()
            {
                Epost = "b@b",
                Fornavn = "Suphakin",
                Etternavn = "Riemprasert",
                Telefon = "95238343",
                Adresse = "Bakkelia 10",
                Fødselsdato = "12/12-2017",
                Passord = "123"

            };


            var nyKategori1 = new Kategorier()
            {
                KatgoriNavn = "Action"
            };

            var nyKategori2 = new Kategorier()
            {
                KatgoriNavn = "Komedie"
            };
            var nyKategori3 = new Kategorier()
            {
                KatgoriNavn = "Drama"
            };
            var nyKategori4 = new Kategorier()
            {
                KatgoriNavn = "Horror"
            };


            var nyFilm = new Filmer()
            {

                Navn = "Nemo",
                Bilde = ImageToArray("nemo.jpg"),
                Beskrivelse = "En haifilm!",
                Pris = int.Parse("195"),
                Kategorier = nyKategori1
             };

            var nyFilm1 = new Filmer()
            {

                Navn = "Die hard",
                Bilde = ImageToArray("diehard.jpg"),
                Beskrivelse = "En die hard film!",
                Pris = int.Parse("59"),
                Kategorier = nyKategori2
            };


            var kategoriList = new List<Kategorier>();
            kategoriList.Add(nyKategori1);
            kategoriList.Add(nyKategori2);
            kategoriList.Add(nyKategori3);
            kategoriList.Add(nyKategori4);
            var filmList = new List<Filmer>();
            filmList.Add(nyFilm);
            filmList.Add(nyFilm1);




            context.Brukere.Add(nyBruker);

            context.Kategorier.AddRange(kategoriList);

            context.Filmer.AddRange(filmList);

            base.Seed(context);
        }

        public byte[] ImageToArray(string path)
        {
            var appDomain = System.AppDomain.CurrentDomain;

            var basePath = appDomain.BaseDirectory;

            Image img = Image.FromFile(Path.Combine(basePath,"Content", "Image", path));
            
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }

        /*
        public byte[] ImageToArray()
        {
            Image img = Image.FromFile(@"C:\Users\Bas\Desktop\test.jpg");
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }
        */

    }
}