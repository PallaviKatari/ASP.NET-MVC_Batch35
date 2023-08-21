using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Batch35.Controllers
{
    /// <summary>
    /// Data Annotations - Validation for Model
    /// </summary>
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return Content("I am in Customer Controller");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [ChildActionOnly]
        public ActionResult RenderSideBar()
        {
            return PartialView("_SideBar");
        }
    }
}