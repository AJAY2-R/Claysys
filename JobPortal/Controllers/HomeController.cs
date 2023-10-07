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
            try
            {
                if (ModelState.IsValid)
                {
                    JobSeekerRepository seeker = new JobSeekerRepository();
                    if (seeker.JobSeekerRegister(jobSeeker, imageUpload, resumeUpload))
                    {
                        TempData["Message"] = "Registration successful ";
                        return RedirectToAction("JobSeekerLogin");
                    }
                }
                return View();  
            }catch(Exception )
            {
                TempData["Message"] = "Email alredy registred ";
                return View();
            }
           
        }

        /// <summary>
        /// Login form for - Admin,JobSeeker,Employer
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login obj)
        {
            PublicRepository repo = new PublicRepository(); 
            string result = repo.Login(obj);
            if(result == "JobSeeker")
            {
                JobSeekerRepository jobSeekerRepository = new JobSeekerRepository();
                var details = jobSeekerRepository.JobSeekers().Find(model => model.Username == obj.Username);
                Session["SeekerId"] = details.SeekerId;
                return RedirectToAction("Index", "JobSeeker");
            }
            else if (result == "Employer")
            {
                EmployerRepository employerRepository = new EmployerRepository();
                var details = employerRepository.Employers().Find(model => model.Username == obj.Username);
                Session["EmployerId"] = details.EmployerID;
                return RedirectToAction("Index", "Employer");
            }
            else if (result == "Admin")
            {
                Session["Admin"] = obj.Username;
                //Roles.AddUserToRole(obj.Username, "Admin");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["Message"]=result;
                return View();
            }
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
            try
            {
                EmployerRepository emprepo = new EmployerRepository();
                if (ModelState.IsValid)
                {
                    if (emprepo.EmployerRegister(emp, logoUpload)){
                        TempData["Message"] = "Registred Successfully";
                        return RedirectToAction("EmployerLogin");
                    }
                }
                return View();
            }catch(Exception)
            {
                TempData["Message"] = "Email is alredy registred";
                return View();
            }
        }

        /// <summary>
        /// Display all the jobs
        /// </summary>
        /// <returns></returns>
        public ActionResult Jobs()
        {

            PublicRepository repo = new PublicRepository();
            var vacency = repo.GetJobVacancies();
            return View(vacency);

        }
    }
}