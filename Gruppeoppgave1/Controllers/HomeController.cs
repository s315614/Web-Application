using Gruppeoppgave1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gruppeoppgave1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var db = new DBBruker();
            List<Bruker> alleBrukere = db.alleBrukere();
            return View(alleBrukere);

        }


        public ActionResult Login()
        {
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
                ViewBag.Innlogget = true;
                return View();
            }
            else
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }



        public ActionResult Registry()
        {
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

    }
}
