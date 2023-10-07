using JobPortal.Models;
using JobPortal.Repository;
using Microsoft.Ajax.Utilities;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {
        EmployerRepository emp = new EmployerRepository();
        public ActionResult Index()
        {
            var Employer = emp.Employers().Find(model => model.EmployerID == Convert.ToInt32(Session["EmployerId"]));
            return View(Employer);
        }
        /// <summary>
        /// Add job vacancy
        /// </summary>
        /// <returns></returns>
        public ActionResult AddJobVacancy()
        {
            PublicRepository repo = new PublicRepository();
            var categories = repo.DisplayCategories();
            return View(categories);
        }
        [HttpPost]
        public ActionResult AddJobVacancy(JobVacancy obj)
        {
            try
            {
                int employerId = Convert.ToInt32(Session["EmployerId"]);
                EmployerRepository repo = new EmployerRepository();
                if (repo.AddJobVacancy(obj, employerId))
                {
                    TempData["Message"] = "Job vaccency published....";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// View profile
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewProfile()
        {
            EmployerRepository repo = new EmployerRepository();
            return View(repo.Employers().Find(model => model.EmployerID == Convert.ToInt32(Session["EmployerId"])));
        }
        public ActionResult UpdateProfile()
        {
            EmployerRepository repo = new EmployerRepository();
            return View(repo.Employers().Find(model => model.EmployerID == Convert.ToInt32(Session["EmployerId"])));
        }

        [HttpPost]
        public ActionResult UpdateProfile(EmployerModel employer, HttpPostedFileBase uploadedLogo )
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if(repo.UpdateEmployer(employer, uploadedLogo, Convert.ToInt32(Session["EmployerId"])))
                {
                    TempData["Message"] = "Updated";
                }
                return RedirectToAction("ViewProfile");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Diplay vacancy created by the employer
        /// </summary>
        /// <returns></returns>
        public ActionResult Vacancies()
        {
            try
            {
                PublicRepository repo = new PublicRepository();
                var vacency = repo.GetJobVacancies().Where(emp => emp.EmployerID == Convert.ToInt32(Session["EmployerId"]));
                return View(vacency);
            }catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Retrive applications 
        /// </summary>
        /// <param name="id">Job id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Applications(int id)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                return View(repo.GetJobApplications(id));
            }catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Approve application
        /// </summary>
        /// <param name="id">Aplication id</param>
        /// <returns></returns>
        [HttpGet] 
        public ActionResult ApplicationApprove(int id,int aid)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if (repo.JobApplicationApprove(id))
                {
                    TempData["Message"] = "Application Approved";
                }
                return RedirectToAction("Applications",new {id = aid});
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Reject application
        /// </summary>
        /// <param name="id">Application id</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApplicationReject(int id,int aid)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if (repo.JobApplicationReject(id))
                {
                    TempData["Message"] = "Application Rejected";
                }
                return RedirectToAction("Applications",new {id=aid});
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Update status to read 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApplicationRead(int id)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if (repo.JobApplicationRead(id))
                {
                    return new HttpStatusCodeResult(200);
                }
                return new HttpStatusCodeResult(400);
            }
            catch(Exception) {
                return new HttpStatusCodeResult(400);
            }

        }
        /// <summary>
        /// View applicant details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult JobSeekerProfile(int id)
        {
            JobSeekerRepository seeker = new JobSeekerRepository();
            var jobSeeker = seeker.JobSeekers().Find(model => model.SeekerId == id);
            var edu = seeker.GetEducationDetails(id);
            var viewModel = new JobSeekerProfile
            {
                JobSeekerDetails = jobSeeker,
                EducationDetails = edu
            };
            return View(viewModel);
        }
        /// <summary>
        /// Employer chnage password 
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldPassword, string newPassword)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if (repo.ChangePassword(oldPassword, newPassword, Convert.ToInt32(Session["EmployerId"])))
                {
                    TempData["Message"] = "Password changed";
                }
                else
                {
                    TempData["Message"] = "Wrong password";
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}