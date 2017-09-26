using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDome.Models;

namespace EFDome.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
              return View();
        }
      public  testEntities tb = new testEntities();
        public ActionResult student()
        {
            var stu = tb.students.ToList();
            return View(stu);
        }
        public ActionResult coures()
        {
            var cour = tb.courses.ToList();
            return View(cour);
        }
        public ActionResult score()
        {
            var scor = tb.scores.ToList();
            return View(scor);
        }
    }
}