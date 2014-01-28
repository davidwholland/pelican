using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pelican.Models;

namespace Pelican.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //using (var db = new PelicanContext())
            //{
            //    var person = new Person()
            //    {
            //        UserId = "dave.holl@gmail.com",
            //        FirstName = "David",
            //        LastName = "Holland",
            //        Email = "dave.holl@gmail.com",
            //        WorkPhone = "4255551212",
            //        MobilePhone = "4251112222"                    
            //    };

            //    db.Persons.Add(person);                
            //    db.SaveChanges();

            //    var x = db.Persons.Find(person.PersonId);
            //}

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}