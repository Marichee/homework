using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class MovieOrderController : Controller
    {
        private List<MovieOrderModel> movieOrders = new List<MovieOrderModel>
        {
            new MovieOrderModel
            {
                OrderID=1,
                Movie="Glass",
                Quantity=1,
                Price=19.99
            },
                      new MovieOrderModel
            {
                OrderID=2,
                Movie="Aladdin",
                Quantity=2,
                Price=51.00
            },          new MovieOrderModel
            {
                OrderID=3,
                Movie="Rambo: Last Blood",
                Quantity=1,
                Price=23.60
            },

        };
        public IActionResult Index()
        {
            return View(movieOrders);
        }
        public IActionResult OrderDetails(int id)
        {
            var order = movieOrders.FirstOrDefault(o => o.OrderID == id);
            return View(order);
        }
    }
}