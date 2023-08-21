using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Batch35.ViewModels;

namespace MVC_Batch35.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // GET: Product
        public ActionResult Index1()
        {
            Product product = new Product()
            {
                Id = 100,
                Name = "Laptop",
                Description = "Dell",
                LocationId = 1
            };
            Location location = new Location()
            {
                LocationId = 1,
                LocationCity = "Chennai",
                LocationState = "Tamilnadu"
            };

            ProductLocation productLocation = new ProductLocation()
            {
                Product = product,
                Location = location
            };

            return View(productLocation);
        }
    }
}