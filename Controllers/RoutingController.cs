using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Batch35.Controllers
{
    //ROUTE PREFIX
    [RoutePrefix("routes")]
    [Route("action = GetAllStudents")] //Default Route
    public class RoutingController : Controller
    {
        static IList<Student> students = new List<Student>{
                new Student() { StudentId = 1, StudentName = "Harita", Age = 20 } ,
                new Student() { StudentId = 2, StudentName = "Arun",  Age = 21 } ,
                new Student() { StudentId = 3, StudentName = "Yamini",  Age = 20 } ,
                new Student() { StudentId = 4, StudentName = "Vignesh" , Age = 20 } ,
                new Student() { StudentId = 5, StudentName = "Siva" , Age = 22 } ,
                new Student() { StudentId = 6, StudentName = "Srikanth" , Age = 17 } ,
                new Student() { StudentId = 7, StudentName = "Hemanth" , Age = 19 },
                new Student() { StudentId = 8, StudentName = "Darshan" , Age = 20 },
                new Student() { StudentId = 9, StudentName = "Sharon" , Age = 19 },
                new Student() { StudentId = 10, StudentName = "Harishmitha" , Age = 19 },
                new Student() { StudentId = 11, StudentName = "Karthikeyan" , Age = 20 },
                new Student() { StudentId = 12, StudentName = "Harshan" , Age = 19 }
            };

        // GET: Routing
        //1. ATTRIBUTE ROUTING
        [Route("Customer/{id}/details")] //Enable attribute routing in RouteConfig.cs 
        //https://localhost:44398/routes/Customer/1/details
        public ActionResult Index(int id)
        {
            return Content("Routing Demo: "+id);
        }

        //2. OPTIONAL ROUTE PARAMETER
        //[Route("RouteDemo/{studentName}")]
        //[Route("RouteDemo/{studentName?}")]
        [Route("RouteDemo/{studentName=Peter}")]
        public ActionResult Demo(string studentName)
        {
            return Content("Welcome to ASP.NET MVC! " + studentName);
        }

        //3. ROUTE PREFIX
        [HttpGet]
       // [Route] ////https://localhost:44398/routes and renders students details
        public ActionResult GetAllStudents()
        {
            return View(students);
        }

        //4. How to override the route prefix? - Use ~ character to override the route prefix
        //https://localhost:44398/tech/trainers
        [Route("tech/trainers")] //error
        //[Route("~/tech/trainers")]
        public ActionResult GetTrainers()
        {
            TrainerLayer layer = new TrainerLayer();
            Trainer trainer = layer.GetTrainerDetails(1);
            return View(trainer);
        }

        //5. Route Constraints 
        [HttpGet]
        //[Route("{studentID:int}")] //https://localhost:44398/routes/1
        //[Route("{studentID:int:min(1)}")]
        //[Route("{studentID:int:min(1):max(12)}")]
        [Route("{studentID:int:range(1,12)}")]
        public ActionResult GetStudentDetails(int studentID)
        {
            Student studentDetails = students.FirstOrDefault(s => s.StudentId == studentID);
            return Content(studentDetails.StudentId.ToString());
        }
        [HttpGet]
        [Route("{studentName:alpha}")] //https://localhost:44398/routes/Harita
        public ActionResult GetStudentDetails(string studentName)
        {
            Student studentDetails = students.FirstOrDefault(s => s.StudentName == studentName);
            return Content(studentDetails.StudentName.ToString());
        }
    }
}