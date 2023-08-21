using MVC_Batch35.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Batch35.ViewModels
{
    public class ProductLocation
    {
        public Product Product { get; set; }
        public Location Location { get; set; }
    }
}