﻿ using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;
using MovieApp.Web.ViewComponents;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Entity;


namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]

        public IActionResult List(int? id, string q)
        {
            //var controller = RouteData.Values["controller"];
            //var action = RouteData.Values["action"];
            //var genreid = RouteData.Values["id"];
            //var kelime = HttpContext.Request.Query["q"].ToString();


            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(m => m.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(i =>
                    i.Title.ToLower().Contains(q.ToLower()) ||
                    i.Description.ToLower().Contains(q.ToLower())).ToList();
            }


            var model = new MovieViewModel()
            {
                Movies = movies

            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");

            return View();

        }
        [HttpPost]
        public IActionResult Create(Movie m)
        {
           
            if (ModelState.IsValid)
            {
                MovieRepository.Add(m);
                TempData["Message"] = $"{m.Title} isimli film eklendi";

                return RedirectToAction("List");
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");

            return View();

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList (GenreRepository.Genres,"GenreId","Name");
            return View(MovieRepository.GetById(id)
);

        }

        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                MovieRepository.Edit(m);
                return RedirectToAction("Details", "Movies", new { @id = m.MovieId });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");

            return View(m);

        }

        [HttpPost]
        public IActionResult Delete(int MovieId, string Title)
        {
           
            MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");

        }




    }
}
