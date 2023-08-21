using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVC_Batch35.Controllers
{

    /// <summary>
    /// STRONGLY TYPED HTML HELPER DEMO
    /// </summary>
    public class HomeController : Controller
    {
        Employee employee;

        public ActionResult Index(Employee emp)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Trainer Details";
            TrainerLayer layer = new TrainerLayer();
            Trainer trainer = layer.GetTrainerDetails(1);
            return View(trainer);

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your in contact page.";
            List<string> traineeList = new List<string>();
            traineeList.Add("John");
            traineeList.Add("Peter");
            traineeList.Add("Liam");
            traineeList.Add("Paul");
            ViewData["traineeList"] = traineeList;
            ViewBag.traineeList = traineeList;
            return View(traineeList);
        }

        public ActionResult Login()
        {
            string[] names = new string[] { "Harita", "Yamini", "Vignesh", "Siva", "Karthi", "Harshan", "Arun", "Sharon", "Harishmitha", "Hemanth", "Darshan", "Srikanth" };
            Random rnd = new Random();
            string userName = names[rnd.Next(0, 12)];
            TempData["UserName"] = userName;
            return new RedirectResult(@"~\Product\");
        }
    }
}