using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDome.Models;
using System.Data.Entity.Migrations;

namespace EFDome.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        testEntities tb = new testEntities();
        public ActionResult Add(course stu)
        {
            return View("Add");
        }
        public ActionResult Edit(int id)
        {
            var sid = tb.courses.FirstOrDefault(s => s.Id == id);
            if (sid == null) return Content("参数不正确！");
            return View(sid);
        }
       
        public ActionResult Save(course stu)
        {
            tb.courses.AddOrUpdate(stu);
            tb.SaveChanges();
            return RedirectToAction("coures", "Home");
        }
        public ActionResult Delete(int id)
        {
            var sid = tb.courses.FirstOrDefault(s => s.Id == id);
            if (sid == null) return Content("参数不正确！");
            tb.courses.Remove(sid);
            try
            {
                tb.SaveChanges();
            }
            catch (Exception)
            {
                return Content("该学科绑定的有成绩，请删除学生成绩后再删除其学生！");
                throw;
            }

            return RedirectToAction("coures", "Home");
        }
    }
}