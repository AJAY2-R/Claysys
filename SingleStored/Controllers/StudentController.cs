using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SingleStored.Models;
using SingleStored.Repository;
namespace SingleStored.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository repo = new StudentRepository();
        /// <summary>
        /// Add student details to database
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudent()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentModel student,HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid) {
                string res = repo.AddStudent(student, imageUpload);
                TempData["message"] = res;
            }
            return View();
        }
        public ActionResult StudentList()
        {
            var student = repo.GetAllStudents();
            return View(student);
        }

        public ActionResult EditStudent(int id)
        {
            ModelState.Clear();
            return View(repo.GetAllStudents().Find(student=>student.StudentId == id));
        }

        [HttpPost]
        public ActionResult EditStudent(StudentModel student, HttpPostedFileBase imageUpload)
        {
            if (ModelState.IsValid)
            {
                string res = repo.UpdateStudent(student, imageUpload);
                TempData["message"] = res;
            }
           return View();
        }
        public ActionResult DeleteStudent(int id)
        {
            if (repo.DeleteStudent(id))
            {
                TempData["message"] = "Student removed from the database";
            }
            return RedirectToAction("StudentList", "Student");
        }
    }
}