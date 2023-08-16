using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC_Batch35.Controllers
{
    /// <summary>
    /// All the public methods of the Controller class are called Action methods. 
    /// They are like any other normal methods with the following restrictions:
    /// Action method must be public. It cannot be private or protected
    /// Action method cannot be overloaded
    /// Action method cannot be a static method.
    /// ActionResult is the base class of all the result types that an action method returns.
    /// </summary>
    public class StudentController : Controller
    {
        /// <summary>
        /// Passing data to Student Model
        /// </summary>
        static IList<Student> studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "Harita", Age = 18 } ,
                new Student() { StudentId = 2, StudentName = "Arun",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Yamini",  Age = 25 } ,
                new Student() { StudentId = 4, StudentName = "Vignesh" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Siva" , Age = 31 } ,
                new Student() { StudentId = 4, StudentName = "Srikanth" , Age = 17 } ,
                new Student() { StudentId = 4, StudentName = "Hemanth" , Age = 19 },
                new Student() { StudentId = 4, StudentName = "Darshan" , Age = 19 },
                new Student() { StudentId = 4, StudentName = "Sharon" , Age = 19 },
                new Student() { StudentId = 4, StudentName = "Harishmitha" , Age = 19 },
                new Student() { StudentId = 4, StudentName = "Karthikeyan" , Age = 19 },
                new Student() { StudentId = 4, StudentName = "Harshan" , Age = 19 }
            };

        /// <summary>
        /// returns a string
        /// </summary>
        /// <returns></returns>
        //[ActionName("Student")] //Perform the below action using Student
        //public string Index()
        //{
        //    return "I am a Student Controller";
        //}

        // GET: Student
        public ActionResult Index()
        {
            //fetch students from the DB using Entity Framework here
            return View(studentList); // returning a Model
        }

        /// <summary>
        /// returns a string with parameter and also accepts Nullable type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction] //Cannot perform the below action
        public string Index1(int id)
        //public string Index1(int? id)
        {
            return "I am a Student Controller with ID: " + id;
        }

        /// <summary>
        /// Conditional view returning a JSON
        /// </summary>
        /// <returns></returns>
        public ActionResult View1()
        {
            if (1000 > 100)
                return View();    // returns ViewResult object
            else
                return Json("Data", JsonRequestBehavior.AllowGet);  // returns JsonResult object
        }

        /// <summary>
        /// redirects to another action within the same component
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult View2(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("View1");

            return View();
        }

        /// <summary>
        /// returns a string using Content("") with ActionResult
        /// </summary>
        /// <returns></returns>
        public ActionResult View3()
        {
            return Content("Returning a content through ActionResult!");
        }

        /// <summary>
        /// returns a DateTime
        /// </summary>
        /// <returns></returns>
        public DateTime View4()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// returns a jsonResult from Person Model
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult View5()
        {
            var persons = new List<Person>
            {
                new Person{Id=1, FirstName="Harry", LastName="Potter"},
                new Person{Id=2, FirstName="Ron", LastName="Weasley"}
            };
            var jsonResult = Json(persons, "application/json", System.Text.Encoding.UTF8, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// returns a JavaScriptResult
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JavaScriptResult View6()
        {
            var msg = "alert('Are you sure want to Continue?');";
            return new JavaScriptResult() { Script = msg };
        }

        /// <summary>
        /// returns a file
        /// </summary>
        /// <returns></returns>
        public FileResult View7()
        {
            return File(Url.Content("~/Files/Files.txt"), "text/plain");
        }

        /// <summary>
        /// returns a html content with Content()
        /// </summary>
        /// <returns></returns>
        public ContentResult View8()
        {
            return Content("<h3>Here's a custom content header returned using a ContentResult</h3>", "text/html", System.Text.Encoding.UTF8);
        }

        /// <summary>
        /// returns a html content as a string
        /// </summary>
        /// <returns></returns>
        public string View9()
        {
            return "<h3>Here's a custom content header returned using a string</h3>";
        }

        /// <summary>
        /// returns a EmptyResult()
        /// </summary>
        /// <returns></returns>
        public EmptyResult View10()
        {
            return new EmptyResult();
        }

        /// <summary>
        /// returns a EmptyResult() using null
        /// </summary>
        /// <returns></returns>
        public ActionResult View11()
        {
            return null; //Returns an EmptyResult
        }

        /// <summary>
        /// redirects to a destination URL
        /// </summary>
        /// <returns></returns>
        public RedirectResult View12()
        {
            return Redirect("https://www.google.co.in/");
        }

        /// <summary>
        /// redirects to a specific Route
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult View13()
        {
            return RedirectToRoute(new { controller = "Home", action = "About" });
        }

        /// <summary>
        /// redirects to a specific action from its corresponding controller
        /// </summary>
        /// <returns></returns>
        public ActionResult View14()
        {
            return RedirectToAction("Contact", "Home"); // action,controller
        }

        /// <summary>
        /// returns to a coreesonding view
        /// </summary>
        /// <returns></returns>
        public ViewResult View15()
        {
            return View("View1");
        }

        /// <summary>
        /// returns to a Partial view
        /// </summary>
        /// <returns></returns>
        public PartialViewResult View16()
        {
            return PartialView("_PartialView");
        }

        /// <summary>
        /// Conditional with error message
        /// </summary>
        /// <returns></returns>
        public ActionResult View17()
        {
            if (1000 > 100)
                return Redirect("https://www.google.co.in/");
            else
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not authorized to access this controller action.");
        }

        /// <summary>
        /// HttpStatusCodeResult with HttpStatusCode.Unauthorized
        /// </summary>
        /// <returns></returns>
        public HttpStatusCodeResult UnauthorizedStatusCode()
        {
            return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "You are not authorized to access this controller action.");
        }

        /// <summary>
        /// HttpStatusCodeResult with HttpStatusCode.BadGateway
        /// </summary>
        /// <returns></returns>
        public HttpStatusCodeResult BadGateway()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadGateway, "I have no idea what this error means.");
        }

        /// <summary>
        /// HttpNotFound
        /// </summary>
        /// <returns></returns>
        public HttpNotFoundResult NotFound()
        {
            return HttpNotFound("We didn't find that action, sorry!");
        }

        /// <summary>
        /// HttpUnauthorizedResult
        /// </summary>
        /// <returns></returns>
        public HttpStatusCodeResult UnauthorizedResult()
        {
            return new HttpUnauthorizedResult("You are not authorized to access this controller action.");
        }
    }
}