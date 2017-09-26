using EFDome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace EFDome.Controllers
{
    public class ScoreController : Controller
    {
        // GET: Score
        testEntities tb = new testEntities();

        public ActionResult Add(score sc)
        {
            ViewBag.student = tb.students;
            ViewBag.course = tb.courses;
            //第一次更改
            return View(sc);
        }
      
        public ActionResult Edit(int id)
        {
            var sid = tb.scores.FirstOrDefault(s => s.Id == id);
            if (sid == null) return Content("参数不正确！");
            return View(sid);
        }
        public ActionResult Save(score stu)
        {
            tb.scores.AddOrUpdate(stu);
            tb.SaveChanges();
            return RedirectToAction("score", "Home");
        }
        public ActionResult Delete(int id)
        {
            var sid = tb.scores.FirstOrDefault(s => s.Id == id);
            if (sid == null) return Content("参数不正确！");
            tb.scores.Remove(sid);
                tb.SaveChanges();
            return RedirectToAction("score", "Home");
        }
    }
}