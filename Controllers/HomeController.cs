using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;

namespace MVC_Batch35.Controllers
{

    /// <summary>
    /// LOOSELY(VIEWDATA,VIEWBAG,TEMPDATA) AND STRONGLY TYPED HTML HELPER DEMO
    /// </summary>
    
    public class HomeController : Controller
    {
        Employee employee;

        public ActionResult Index(Employee emp)
        {
            return View();
        }

        //Example 1 - CUSTOM ERROR - DEFAULT - Error.cshtml
        public ActionResult Index1()
        {
            return View();
        }

        //Example 2 - Error1.cshtml
        [HandleError(ExceptionType = typeof(DivideByZeroException), View = "Error1")]
        [HandleError] // this will work, go to the default: view = "Error";
        public ActionResult Index2()
        {
            int a = 1;
            int b = 0;
            int c = 0;
            c = a / b; //it would cause exception.
            return View();
        }

        //Example 3 - Error2.cshtml using try/catch/finally
        public ActionResult Index3()
        {
            int a = 1;
            int b = 0;
            int c = 0;
            try
            {
                c = a / b; //it would cause exception.
            }
            catch (Exception)
            {
                return View("Error2");
            }
            finally
            {
            }
            return View();
        }

        //Example 4 - Error3.cshtml
        //Create Exception handler in Global.asax, Register in FilterConfig.cs
        //[MyExceptionHandler]
        public ActionResult Index4()
        {
            //throw new Exception("Something went wrong");
            return View();
        }


        // This method is accessible only by a child request. A runtime 
        // exception will be thrown if a URL request is made to this method
        [ChildActionOnly] //accessing this URL will throw an error https://localhost:44398/Home/Countries
        public ActionResult Countries(List<String> countryData)
        {
            return View(countryData);
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
            //ViewData["traineeList"] = traineeList;
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

        // 1st Request  
        public ActionResult Signin()
        {
            Student std = new Student
            {
                StudentId = 1,
                StudentName="John",
                Age=21
            };

            TempData["info"] = std;

            int sid;

            if (TempData.ContainsKey("info"))
            {
                ViewBag.sid = (TempData["info"] as Student).StudentId;
            }

            //Maintain State
            TempData.Keep();

            return View();
        }
    }
}
