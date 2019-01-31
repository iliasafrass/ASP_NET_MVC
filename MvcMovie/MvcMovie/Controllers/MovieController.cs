using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        private Movie[] movies = new Movie[]
        {

        new Movie {ID=1,Title="film1",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre1",Price=20},
        new Movie {ID=2,Title="film2",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre2",Price=20},
        new Movie {ID=3,Title="film3",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre3",Price=20},
        new Movie {ID=4,Title="film4",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre4",Price=20},
        new Movie {ID=5,Title="film5",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre5",Price=20},
           };


        // GET: Movie
        public ActionResult Index()
        {

            return View(movies);
        }
        


        // GET: Movie/Details/5
        
        public ActionResult Details(int id)
        {
           /* if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
            Movie movie = movies.ToList().Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        
  


        // POST: Movie/Create
        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")]Movie movie)
        {
            try
            {
                /*
                int id = movies.Last().ID+1;
                string title = movie.Title;
                string genre = movie.Genre;
                DateTime releaseDate = movie.ReleaseDate;
                decimal price = movie.Price;
                */
                movies.ToList().Add(movie);
                


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [System.Web.Http.HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [System.Web.Http.HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
