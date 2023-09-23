using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentMVC.Repository;
using StudentMVC.Models;
using System.IO;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository studentRepo = new StudentRepository();//Instance of Student repository
        
        
        /// <summary>
        /// Add student details to database
        /// </summary>
        /// <returns></returns>
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(StudentModel student, HttpPostedFileBase UploadImage)
        {
            try
            {
                // Convert the image into binary 
                using (BinaryReader reader = new BinaryReader(UploadImage.InputStream))
                {
                    student.Image = reader.ReadBytes(UploadImage.ContentLength);
                }
                if (studentRepo.AddStudent(student))
                {
                    ViewBag.Message = "Student details added successfully";
                }
                
                return RedirectToAction("StudentsDetails");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        /// <summary>
        /// Retrive all the student details from the database
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentsDetails()
        {
            ModelState.Clear();
            var students = studentRepo.GetAllStudents();
            return View(students);
        }

        /// <summary>
        /// Display student list as grid
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentListGrid()
        {
            ModelState.Clear();
            var students = studentRepo.GetAllStudents();
            return View("StudentListGrid", students);
        }


        /// <summary>
        /// Update a student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateStudent(int id)
        {
            if (ModelState.IsValid)
            {
                var student = studentRepo.GetAllStudents().Find(Student => Student.StudentId == id);//Retrive student details based on the student id
                if (student == null)
                {
                    return View("Error");
                }
                return View(student);
            }
            else
            {
                return View("Error");
            }

        }

        [HttpPost]
        public ActionResult UpdateStudent(int id,StudentModel student)
        {
            ViewBag.Title = "Update Student";
            try
            {
                if (studentRepo.UpdateStudent(student,id))
                {
                    ViewBag.Message = "Student details updated successfully";
                }
                else
                {
                    ViewBag.Message = "Student details are not updated... ";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
        /// <summary>
        /// Delete student details from the database
        /// </summary>
        /// <param name="id">Student id</param>
        /// <returns></returns>
        public ActionResult DeleteStudent(int id)
        {
            try
            {
                if (studentRepo.DeleteStudent(id))
                {
                    TempData["AlertMsg"] = "Student details deleted successfully";
                }
                return RedirectToAction("StudentsDetails");
            }catch{
                return View();
            }
        }
        /// <summary>
        /// View details of induvidual student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
          
            return View(studentRepo.GetAllStudents().Find(student=>student.StudentId==id));
        }
    }
}