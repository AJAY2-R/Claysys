using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult JobSeekerRegister()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult JobSeekerRegister(JobSeekerModel jobSeeker, HttpPostedFileBase imageUpload, HttpPostedFileBase resumeUpload)
        {
            if (ModelState.IsValid)
            {
                JobSeekerRepository seeker = new JobSeekerRepository();
                string res = seeker.JobSeekerRegiser(jobSeeker,imageUpload,resumeUpload);
                TempData["Message"] = res;
            }
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult JobSeekerLogin()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult JobSeekerLogin(FormCollection formCollection)
        {

            string Username = formCollection["Username"];
            string Password = formCollection["Password"];
            JobSeekerRepository seeker = new JobSeekerRepository();
            int res= seeker.JobSeekerLogin(Username,Password);
            if (res > 0)
            {
                Session["Seekerid"] = res;
                return RedirectToAction("Index","JobSeeker");
            }
            else
            {
                TempData["Message"] = "Username or password error ";
                return View();
            }
           
        }
        public ActionResult EmployerRegister()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult EmployerRegister(EmployerModel emp, HttpPostedFileBase logoUpload)
        {
            EmployerRepository emprepo = new EmployerRepository();
            if (ModelState.IsValid)
            {
                string res = emprepo.EmployerRegister(emp, logoUpload);
                TempData["Message"] = res;

            }
            else
            {
                TempData["Message"] = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            }
            return View();
        }
        public ActionResult EmployerLogin()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult EmployerLogin(FormCollection formCollection)
        {

            string Username = formCollection["Username"];
            string Password = formCollection["Password"];
            EmployerRepository emp = new EmployerRepository();
            int res = emp.EmployerLogin(Username, Password);
            if (res > 0)
            {
                Session["EmployerId"] = res;
                return RedirectToAction("Index", "Employer");
            }
            else
            {
                TempData["Message"] = "Username or password error ";
                return View();
            }

        }
    }
}