using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return RedirectToAction("MainPage");
                }
            }

            var db = new DBFilmer();
            List<Film> alleFilmer = db.alleFilmer();

  
            return View(alleFilmer);

        }



        public ActionResult Login()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return RedirectToAction("MainPage");
                }
            }

            if (Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }

            return View();

        }

        [HttpPost]
        public ActionResult Login(Bruker innBruker)
        {
            if (Bruker_i_DB(innBruker))
            {
                Session["LoggetInn"] = true;
                string fornavn = Bruker_i_DB_Navn(innBruker);
                return RedirectToAction("MainPage", "Home", new { name = fornavn });
            }
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }



        public ActionResult Registry()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return RedirectToAction("MainPage");
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Registry(Bruker innBruker)
        {
            if (!ModelState.IsValid)
            {
                return View();
                
            }
            using (var db = new DBContext())
            {
                try
                {
                    var nyBrukerr = new Brukere();

                    nyBrukerr.Epost = innBruker.Epost;

                    nyBrukerr.Fornavn = innBruker.Fornavn;
                    nyBrukerr.Etternavn = innBruker.Etternavn;
                    
                    nyBrukerr.Adresse = innBruker.Adresse;
                    nyBrukerr.Telefon = innBruker.Telefon;
                    nyBrukerr.Fødselsdato = innBruker.Fødselsdato;
                    nyBrukerr.Passord = innBruker.Passord;
                
                    db.Brukere.Add(nyBrukerr);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                catch (Exception feil)
                {
                    return RedirectToAction("Index");
                }

            }

        }

        public ActionResult MainPage(string name)
        {
            Session["payment"] = false;

            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    var db = new DBFilmer();
                    List<Film> alleFilmer = db.alleFilmer();
                    ViewBag.message = "Welcome " +name ;
                    return View(alleFilmer);
                }
            }

            return RedirectToAction("Index");

        }

        public ActionResult Details(int? id)
        {
            Session["payment"] = true;

            bool payment = (bool)Session["payment"];
            if (!payment || id ==null)
            {
                return RedirectToAction("MainPage");
            }
           
            using (var db = new DBContext())
            {
                try
                {
                    Filmer film = db.Filmer.FirstOrDefault
                    (b => b.Id == id);
                    Film nyBrukerr = new Film();

                    nyBrukerr.Id = film.Id;
                    nyBrukerr.Navn = film.Navn;
                    nyBrukerr.Bilde = film.Bilde;
                    nyBrukerr.Beskrivelse = film.Beskrivelse;
                    nyBrukerr.Pris = film.Pris;
                    //nyBrukerr.KategoriId = film.KategoriId;

                    return View(nyBrukerr);
                }
                catch (Exception feil)
                {
                    return Redirect("http://wwww.google.no");
                }

            }
        }

    
        public ActionResult Loggut()
        {
            Session["LoggetInn"] = false;
              
            return RedirectToAction("Index");
        }


        private static bool Film_i_DB(int Id = 0)
        {
            using (var db = new DBContext())
            {

                Filmer funnetFilm = db.Filmer.FirstOrDefault
                    (b => b.Id == Id);



                if (funnetFilm == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                

            }
        }

            private static bool Bruker_i_DB(Bruker innBruker)
        {
            using (var db = new DBContext())
            {
                Brukere funnetBruker = db.Brukere.FirstOrDefault
                    (b => b.Epost == innBruker.Epost && b.Passord == innBruker.Passord);
                if (funnetBruker == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }

        private static string Bruker_i_DB_Navn(Bruker innBruker)
        {
            using (var db = new DBContext())
            {
                Brukere funnetBruker = db.Brukere.FirstOrDefault
                    (b => b.Epost == innBruker.Epost && b.Passord == innBruker.Passord);
                if (funnetBruker == null)
                {
                    return "Ukjent";
                }
                else
                {
                    return funnetBruker.Fornavn;
                    
                }
            }

        }



    }

   
}
