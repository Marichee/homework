using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        [Route("Downloading")]
        public IActionResult Downloads()
        {
            string a = Directory.GetCurrentDirectory();
            var dir = new System.IO.DirectoryInfo(a + @"\wwwroot\images");
            System.IO.FileInfo[] fileName = dir.GetFiles("*.*");
            List<string> items = new List<string> { };
            foreach (var file in fileName)
            {
                if (file.Name.Contains(".jpg"))
                {
                    items.Add(file.Name);
                }
            }
            return View(items);
        }

        public FileResult Download(string imageName)
        {
            string current = Directory.GetCurrentDirectory();
            var directory = current + @"\wwwroot\images\" + imageName;
            var dir = System.IO.File.ReadAllBytes(directory);
            return File(dir, "application/jpg", imageName);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
