﻿using MvcMovie.Models;
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
        public static List<Movie> movies = new List<Movie>()
        {

        new Movie {ID=1,Title="film1",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre1",Price=20},
        new Movie {ID=2,Title="film2",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre2",Price=20},
        new Movie {ID=3,Title="film3",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre3",Price=20},
        new Movie {ID=4,Title="film4",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre4",Price=20},
        new Movie {ID=5,Title="film5",ReleaseDate=new DateTime(2019, 01, 31),Genre="genre5",Price=20},
           };


        // GET: Movie
        /*  public ActionResult Index()
          {

              return View(movies);
          }
          */
        /*
        public ActionResult Index(string searchString)
        {

            List<Movie> moviesSearch = new List<Movie>();
            if (!String.IsNullOrEmpty(searchString))
            {
                var moviesList = from m in movies
                               where m.Title.Contains(searchString)
                               select m;
                moviesSearch = moviesList.ToList();
                return View(moviesSearch);
            }
            
            return View(movies);
        }
        */

        public ActionResult Index(string movieGenre, string searchString)
        {
            List<Movie> result = movies;
            List<String> genres = movies.Select(m => m.Genre).Distinct().ToList();

            ViewBag.movieGenre = new SelectList(genres);

            if (!String.IsNullOrEmpty(searchString))
            {
                result = movies.FindAll(movie => movie.Title.Contains(searchString));
                //return View(result);
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                result = result.FindAll(movie => movie.Genre == movieGenre);
                //return View(result);
            }

            return View(result);
        }

        // GET: Movie/Details/5

        public ActionResult Details(int id)
        {
            Movie movie = movies.ToList().Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }



        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Movie/Create
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")]Movie movie)
         {
             try
             {

                movies.Add(movie);

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
            
            Movie movie = movies.Single(m => m.ID == id);
  
            return View(movie);
        }



        // POST: /Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                
                Movie mov = movies.First(m => m.ID == movie.ID);
                mov.Title = movie.Title;
                mov.ReleaseDate = movie.ReleaseDate;
                mov.Price = movie.Price;

                return RedirectToAction("Index");
            }
            return View(movie);
        }


        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = movies.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // POST: Movie/Delete/5
        [System.Web.Mvc.HttpPost, System.Web.Mvc.ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Movie movie = movies.Single(m => m.ID == id);
                movies.Remove(movie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
