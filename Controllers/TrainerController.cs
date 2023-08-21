using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Batch35.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index()
        {
            TrainerLayer layer = new TrainerLayer();
            Trainer trainer = layer.GetTrainerDetails(1);
            return View(trainer);
        }
    }
}