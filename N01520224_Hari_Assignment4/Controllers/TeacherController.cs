using N01520224_Hari_Assignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace N01520224_Hari_Assignment4.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List
        // NameKey is the value which we will receive here after submiting the Search form
        [Route("Teacher/List/{NameKey}")]
        public ActionResult List(string NameKey)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(NameKey);
            return View(Teachers);


        }

        //GET: Teacher/Show/{id}
        [HttpGet]
        [Route("Teacher/Show/{id}")]
        public ActionResult Show(int? id)
        {
            if (id != null)
            {
                TeacherDataController controller = new TeacherDataController();
                Teacher TeacherDetails = controller.ShowDetails(id);
                return View(TeacherDetails);
            }
            else
            {
                return RedirectToAction("Oops");
            }

        }


        [Route("Teacher/New")]
        public ActionResult New()
        {
            return View();
        }


        //POST: /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                TeacherDataController controller = new TeacherDataController();
                controller.DeleteTeacher(id);
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Oops");
            }

        }

        //GET : /Teacher/DeleteConfirm/{id}
        [HttpGet]
        public ActionResult DeleteConfirm(int? id)
        {
            if (id != null)
            {
                TeacherDataController controller = new TeacherDataController();
                Teacher NewTeacher = controller.ShowDetails(id);
                return View(NewTeacher);
            }
            else
            {
                return RedirectToAction("Oops");
            }

        }

        // POST request - Teacher/Create
        [HttpPost]
        public ActionResult Create(string teacherfname, string teacherlname, string employeenumber, string teachersalary)
        {

            Teacher NewTeacher = new Teacher();
            NewTeacher.FName = teacherfname;
            NewTeacher.LName = teacherlname;
            NewTeacher.EmployeeNumber = employeenumber;
            NewTeacher.Salary = teachersalary;

            TeacherDataController tdController = new TeacherDataController();
            tdController.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        public ActionResult Oops()
        {
            return View("Oops");
        }
    }
}