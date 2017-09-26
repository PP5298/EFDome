using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDome.Models;
using System.Data.Entity.Migrations;
namespace EFDome.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        testEntities tb = new testEntities();
        public ActionResult Add(student stu)
        {
            return View("Add");
        }
        public ActionResult Edit(int id)
        {
            var sid = tb.students.FirstOrDefault(s => s.Id == id);
            if (sid == null) return Content("参数不正确！");
            return View(sid);
        }
        public ActionResult Save(student stu)
        {
            tb.students.AddOrUpdate(stu);
            tb.SaveChanges();
            return RedirectToAction("student","Home");
        }
        public ActionResult Delete(int id)
        {
            var sid = tb.students.FirstOrDefault(s => s.Id == id);
            if (sid == null) return Content("参数不正确！");
            tb.students.Remove(sid);
            try
            {
                tb.SaveChanges();
            }
            catch (Exception)
            {
                return Content("该学生绑定的有成绩，请删除学生后再删除其学生！");
                throw;
            }
            
            return RedirectToAction("student","Home");
        }
    }
}