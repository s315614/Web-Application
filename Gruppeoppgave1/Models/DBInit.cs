using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Gruppeoppgave1.Models
{
    public class DBInit : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {

            var nyBruker = new Brukere()
            {
                Epost = "b@bob.bo",
                Fornavn = "Suphakin",
                Etternavn = "Riemprasert",
                Telefon = "95238343",
                Adresse = "Bakkelia 10",
                Fødselsdato = "2017-12-12",
                Passord = "123456"

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
                KatgoriNavn = "Skrekk"
            };


            var nyFilm = new Filmer()
            {

                Navn = "Nemo",
                Bilde = ImageToArray("nemo.jpg"),
                Beskrivelse = "En haifilm!",
                Pris = int.Parse("199"),
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

            var nyFilm2 = new Filmer()
            {

                Navn = "De utrolig 2",
                Bilde = ImageToArray("deutrolige2.jpg"),
                Beskrivelse = "En de utrolige film!",
                Pris = int.Parse("199"),
                Kategorier = nyKategori2
            };

            var nyFilm3 = new Filmer()
            {

                Navn = "Mamma mia! Here we go again!",
                Bilde = ImageToArray("mammami.jpg"),
                Beskrivelse = "En mamma mia film!",
                Pris = int.Parse("250"),
                Kategorier = nyKategori2
            };

            var nyFilm4 = new Filmer()
            {

                Navn = "Night School",
                Bilde = ImageToArray("nightschool.jpg"),
                Beskrivelse = "En night school film!",
                Pris = int.Parse("250"),
                Kategorier = nyKategori2
            };

            var nyFilm5 = new Filmer()
            {

                Navn = "Mission Impossible Fallout",
                Bilde = ImageToArray("missionimpossiblefallout.jpg"),
                Beskrivelse = "En mission impossible film!",
                Pris = int.Parse("99"),
                Kategorier = nyKategori2
            };
            var nyFilm6 = new Filmer()
            {

                Navn = "The Godfather",
                Bilde = ImageToArray("TheGodFather.jpg"),
                Beskrivelse = "Mafialederen Don Vito Corleone styrer sitt mektige imperium gjennom et brutalt system av tjenester og gjentjenester. Når han dør må noen av sønnene ta over: advokaten Tom, playboyen Sonny, lojale Fredo - eller Michael, den yngste og minst villige. Den første delen av Francis Ford Coppolas storslagne mesterverk, som stadig rangerer blant verdens beste filmer.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori3
            };
            var nyFilm7 = new Filmer()
            {

                Navn = "3 Idiots",
                Bilde = ImageToArray("drama.jpg"),
                Beskrivelse = "In college, Farhan and Raju form a great bond with Rancho due to his positive and refreshing outlook to life. Years later, a bet gives them a chance to look for their long-lost friend whose existence seems rather elusive.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori3
            };
            var nyFilm8 = new Filmer()
            {

                Navn = "Beauty And The Beast",
                Bilde = ImageToArray("BeautyAndTheBeast.jpg"),
                Beskrivelse = "Belle er en smart, vakker og selvstendig ung kvinne som blir tatt til fange av Udyret i slottet hans. Til tross for sin frykt, blir hun venn med slottets fortryllende beboere og lærer seg å se forbi Udyrets forferdelige ytre og oppdager det gode hjertet til den sanne prinsen innenfor. Dette er historien og karakterene publikum kjenner så godt og er så glade i, og endelig er den her i spillefilmversjon.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori4
            };
            var nyFilm9 = new Filmer()
            {

                Navn = "Harry Potter",
                Bilde = ImageToArray("HarryPotter.jpg"),
                Beskrivelse = "Voldemorts makt blir større og han kontrollerer nå Hogwarts. Harry, Ron og Hermoine bestemmer seg for å avslutte Dumbledores oppdrag som er å finne de gjenværende malacruxene for å kunne beseire Voldemort. Men med det lille håpet som gjenstår, må alt gå etter planen.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori4
            };
            var nyFilm10 = new Filmer()
            {

                Navn = "Breaking In",
                Bilde = ImageToArray("BrakingInAction.jpg"),
                Beskrivelse = "Etter at faren til Shaun Russells har blitt drept drar hun sammen med sønnen og datteren sin til huset hans for å begynne med salget. Bygningen er utstyrt med et toppmoderne sikkerhetssystem, men det familien ikke vet er at fire innbruddstyver allerede befinner seg der inne. Barna blir tatt som gisler inne i huset, mens Shaun er utenfor. Nå må hun gjøre alt hun kan for å bryte seg inn.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori1
            };
            var nyFilm11 = new Filmer()
            {

                Navn = "Hereditary",
                Bilde = ImageToArray("HereditaryHorror.jpg"),
                Beskrivelse = "Når Graham-familiens overhode, Ellen, dør, oppdager datteren Annie og familien hennes noen kryptiske og stadig mer skremmende familiehemmeligheter. Jo mer de oppdager, dess mer blir de overbevist om at noe fryktelig kommer til å skje.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori4
            };
            var nyFilm12 = new Filmer()
            {

                Navn = "Isle Of Dogs",
                Bilde = ImageToArray("IsleOfDogsKomedie.jpg"),
                Beskrivelse = "Wes Anderson er tilbake! I den nye filmen Isle Of Dogs møter vi den 12 år gamle gutten Atari Kobayashi, som jobber for den korrupte borgemesteren i byen. Når alle hundene i byen en dag blir beordret til å bli dumpet på et søppeldeponi på en øy, tar Atari saken i egne hender og begir seg ut i miniflyet sitt til Thrash Island for å redde vakthunden sin Spots.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori2
            };
            var nyFilm13 = new Filmer()
            {

                Navn = "Krypton",
                Bilde = ImageToArray("Krypton.jpg"),
                Beskrivelse = "Serien utspiller seg på den fiktive planeten Krypton rundt 200 år før Kal-El/Superman blir født, og før planeten blir ødelagt. Handlingen foregår rundt bestefaren til Kal-El, Seg-El, når han kjemper for rettferdighet på sin hjemmeplaneten sin.",
                Pris = int.Parse("99"),
                Kategorier = nyKategori3
            };
            var nyFilm14 = new Filmer()
            {

                Navn = "Unsane",
                Bilde = ImageToArray("unsaneHorror.jpg"),
                Beskrivelse = "En ung kvinne blir tvangsinnlagt på psykiatrisk avdeling. Der blir hun tvunget til å møte sine største redsler - men er alt ekte eller er de bare oppspinn i fantasien hennes?",
                Pris = int.Parse("99"),
                Kategorier = nyKategori4
            };


            var kategoriList = new List<Kategorier>();
            kategoriList.Add(nyKategori1);
            kategoriList.Add(nyKategori2);
            kategoriList.Add(nyKategori3);
            kategoriList.Add(nyKategori4);

            var filmList = new List<Filmer>();
            filmList.Add(nyFilm);
            filmList.Add(nyFilm1);
            filmList.Add(nyFilm2);
            filmList.Add(nyFilm3);
            filmList.Add(nyFilm4);
            filmList.Add(nyFilm5);
            filmList.Add(nyFilm6);
            filmList.Add(nyFilm7);
            filmList.Add(nyFilm8);
            filmList.Add(nyFilm9);
            filmList.Add(nyFilm10);
            filmList.Add(nyFilm11);
            filmList.Add(nyFilm12);
            filmList.Add(nyFilm13);
            filmList.Add(nyFilm14);
            

            context.Brukere.Add(nyBruker);

            context.Kategorier.AddRange(kategoriList);

            context.Filmer.AddRange(filmList);

            base.Seed(context);
        }

        public byte[] ImageToArray(string path)
        {
            var appDomain = System.AppDomain.CurrentDomain;

            var basePath = appDomain.BaseDirectory;

            Image img = Image.FromFile(Path.Combine(basePath, "Content", "Image", path));

            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }

    }
}