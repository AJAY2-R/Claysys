using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Linq;
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
        public ActionResult ApplicationApprove(int id)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if (repo.JobApplicationApprove(id))
                {
                    TempData["Message"] = "Application Approved";
                }
                return RedirectToAction("Applications");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Reject application
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ApplicationReject(int id)
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                if (repo.JobApplicationReject(id))
                {
                    TempData["Message"] = "Application Rejected";
                }
                return RedirectToAction("Applications");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}