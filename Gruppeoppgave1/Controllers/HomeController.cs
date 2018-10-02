﻿using Gruppeoppgave1.Models;
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

            return View();

        }

        [HttpPost]
        public ActionResult Login(Bruker innBruker)
        {
            if (Bruker_i_DB(innBruker))
            {
                Session["LoggetInn"] = true;
                Session["BrukerId"] = innBruker.Epost;
                return RedirectToAction("MainPage", "Home");
            }
            
                Session["LoggetInn"] = false;
                //ViewBag.Innlogget = false;
                return View();
            
        }



        public ActionResult Registry()
        {

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registry(Bruker innBruker)
        {
            var db = new DBBruker();
            bool OK = db.lagreBruker(innBruker);
            if (OK)
            {
                return RedirectToAction("Login");
            }
            return View();

        }

        public ActionResult MainPage()
        {
            string epost = (string)Session["BrukerId"];

            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    var db = new DBFilmer();
                    List<Film> alleFilmer = db.alleFilmer();
                    ViewBag.message = "Welcome " + epost;
                    return View(alleFilmer);
                }
            }

            return RedirectToAction("Index");



        }

        public ActionResult Payment(int Id)
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    string epost = (string)Session["BrukerId"];
                    var db = new DBFilmer();
                    Film funnetFilm = db.hentFilm(Id);
                    if (funnetFilm == null)
                    {
                        return RedirectToAction("MainPage");
                    }
                    else
                    {

                        ViewBag.message = "Welcome " + epost;
                        return View(funnetFilm);

                    };
                }
            }

            return RedirectToAction("Index");

           

           
        }

        [HttpPost]
        public ActionResult Payment(Film innfilm)
        {

            string epost = (string)Session["BrukerId"];

            using (var db = new DBContext())
            {
                var order = new Ordrer();
                var filmer = db.Filmer.FirstOrDefault(b => b.Id == innfilm.Id);
                var brukere = db.Brukere.FirstOrDefault(b => b.Epost == epost);

                DateTime date = DateTime.Now;

                order.OrdreDate = date.ToString();
                order.BrukereId = brukere;
                order.FilmerId = filmer;

                db.Ordrer.Add(order);

                Session["payment"] = false;
                db.SaveChanges();

            }
       

            return RedirectToAction("MainPage");
        }

    
        public ActionResult Loggut()
        {
            Session["LoggetInn"] = false;
            
              
            return RedirectToAction("Index");
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
