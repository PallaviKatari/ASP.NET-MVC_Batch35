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
    /// CRUD - TRAINEE MODEL - USING LIST
    /// </summary>
    public class TraineeController : Controller
    {
        static IList<Trainee> traineeList = new List<Trainee>{
                new Trainee() {Id=100,Name="John" } ,
                new Trainee() {Id=101,Name="Jancy"} ,
                new Trainee() {Id=102,Name="James" } ,
                new Trainee() {Id=103,Name="Paul" }
                };
        // GET: Trainee
        public ActionResult Index()
        {
            return View(traineeList);
        }
        public ActionResult Index1()
        {
            return View(traineeList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // Action Verbs
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Trainee t)
        {
            if (ModelState.IsValid)
            {
                traineeList.Add(t);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var t = traineeList.Where(s => s.Id == Id).FirstOrDefault();

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(Trainee t)
        {
            var trainee = traineeList.Where(s => s.Id == t.Id).FirstOrDefault();
            traineeList.Remove(trainee);
            traineeList.Add(t);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {

            var t = traineeList.Where(s => s.Id == Id).FirstOrDefault();

            return View(t);
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var t = traineeList.Where(s => s.Id == Id).FirstOrDefault();
            traineeList.Remove(t);

            return RedirectToAction("Index");
        }

    }
}