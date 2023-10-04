using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Index page controler
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Controller view for Job seeker registration
        /// </summary>
        /// <returns></returns>
        public ActionResult JobSeekerRegister()
        {
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// Controller for job seeker registration 
        /// </summary>
        /// <param name="jobSeeker">Model instance</param>
        /// <param name="imageUpload">Uploaded profile picture</param>
        /// <param name="resumeUpload">Uploaded resume</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        /// <summary>
        /// About page
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            return View();
        }
        /// <summary>
        /// Contact Us page
        /// </summary>
        /// <returns></returns>
        public ActionResult ContactUs()
        {
            return View();
        }

        /// <summary>
        /// Job seeker login page
        /// </summary>
        /// <returns></returns>
        public ActionResult JobSeekerLogin()
        {
            ModelState.Clear();
            return View();
        }
        /// <summary>
        /// Job seeker login process
        /// </summary>
        /// <param name="seeker">Job seeker model instance with Username and password </param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult JobSeekerLogin([Bind(Include ="Username,Password")]JobSeekerModel seeker )
        {
            JobSeekerRepository repo = new JobSeekerRepository();
            if (repo.JobSeekerLogin(seeker))
            {
                var details = repo.JobSeekers().Find(model=>model.Username == seeker.Username);

                Session["SeekerId"] = details.SeekerId;
                return RedirectToAction("Index","JobSeeker");
            }
            else
            {
                TempData["Message"] = "Username or password error ";
                return View();
            }
           
        }

        /// <summary>
        /// Employer registration view
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployerRegister()
        {
            ModelState.Clear();
            return View();
        }

        /// <summary>
        /// Employer registration process
        /// </summary>
        /// <param name="emp">Employer model instance</param>
        /// <param name="logoUpload">Company logo</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EmployerRegister(EmployerModel emp, HttpPostedFileBase logoUpload)
        {
            EmployerRepository emprepo = new EmployerRepository();
            if (ModelState.IsValid)
            {
                string res = emprepo.EmployerRegister(emp, logoUpload);
                TempData["Message"] = res;

            }
            return View();
        }
        public ActionResult EmployerLogin()
        {
            ModelState.Clear();
            return View();
        }
        /// <summary>
        /// Employer login process
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployerLogin(FormCollection formCollection)
        {

            string Email = formCollection["Email"];
            string Password = formCollection["Password"];
            EmployerRepository emp = new EmployerRepository();
            if (emp.EmployerLogin(Email, Password))
            {
                var details = emp.Employers().Find(model => model.Email == Email);
                Session["EmployerId"] = details.EmployerID;

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