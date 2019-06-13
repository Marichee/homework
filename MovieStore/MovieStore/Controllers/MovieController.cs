using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private static List<MovieModel> movieList = new List<MovieModel>
        {
            new MovieModel{
                ID=1,
                Title="Glass",
                ReleaseDate="07/01/2019",
                Genre=("Drama, Mystery & Suspense"),
                Price=19.99

            },
            new MovieModel
            {
                ID=2,
                Title="Aladdin",
                ReleaseDate="08/05/2019",
                Genre=("Adventure"),
                Price=25.50
            },
            new MovieModel
            {
                ID=3,
                Title="Terminator: Dark Fate",
                Genre="Sci-Fi",
                ReleaseDate="23/10/2019",
                Price=18.70
            },
            new MovieModel
            {
                ID=4,
                Title="Rambo: Last Blood",
                Genre="Action",
                ReleaseDate="12/09/2019",
                Price=23.60
            }

        };
        public IActionResult Index()
        {
            return View(movieList);
        }
        public IActionResult MovieDetails(int id)
        {
            var movie = movieList.FirstOrDefault(m => m.ID == id);
            return View(movie);
        }
        public IActionResult Edit(int id)
        {
            var movie = movieList.FirstOrDefault(m => m.ID == id);
            return View(movie);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            movieList.Add(movie);
            return View("Index", movieList);
        }
        [HttpPost]
        [Route("MovieUpdate")]
        public IActionResult SaveMovie(MovieModel movieModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }
            var movie = movieList.FindIndex(m => m.ID == movieModel.ID);
            movieList[movie] = movieModel;
            return View("Index", movieList);
        }
        public IActionResult Delete(int id)
        {
            var movie = movieList.FirstOrDefault(m => m.ID == id);
            movieList.Remove(movie);
            return View("Index", movieList);
        }
        public IActionResult PartialView()
        {
            return PartialView();
        }
    }
}