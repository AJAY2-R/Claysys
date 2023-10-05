using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class JobSeekerController : Controller
    {
        // GET: JobSeeker
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Display profile of the job seeker
        /// </summary>
        /// <returns></returns>
        public ActionResult JobSeekerProfile()
        {
            JobSeekerRepository seeker = new JobSeekerRepository();
            var jobSeeker = seeker.JobSeekers().Find(model=>model.SeekerId == (int)Session["SeekerId"]);
            var edu = seeker.GetEducationDetails((int)Session["SeekerId"]);
            var viewModel = new JobSeekerProfile
            {
                JobSeekerDetails = jobSeeker,
                EducationDetails = edu
            };
            return View(viewModel);
        }

        public ActionResult AddEducationDetails()
        {
            return View();
        }
        [HttpPost]
        /// <summary>
        /// To add eduction details
        /// </summary>
        /// <param name="educationList">Form contain list of all the eduction deatils of the user</param>
        /// <returns></returns>
        public ActionResult AddEducationDetails(EducationDetails educationList)
        {
            try
            {
                int id =(int)Session["SeekerId"];
                JobSeekerRepository seeker = new JobSeekerRepository();
                if (seeker.AddEducationDetails(educationList, id))
                   {
                    TempData["Message"] = "Added successfully";
                    return RedirectToAction("JobSeekerProfile");
                }
               return View();
            }
            catch (Exception ex )
            {
                TempData["Message"] = ex.Message;
                return View();
            }
        }
        /// <summary>
        /// Display job vacancies posted by the employer
        /// </summary>
        /// <returns></returns>
        public ActionResult Jobs()
        {
            try
            {
                PublicRepository repo = new PublicRepository();
                var vacency = repo.GetJobVacancies();
                return View(vacency);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }
        [HttpGet]
        /// <summary>
        /// Apply for the job 
        /// </summary>
        /// <param name="id">JobId</param>
        /// <returns></returns>
        public ActionResult ApplyJob(int  id) {
            try
            {
                JobApplication application = new JobApplication {
                    SeekerId = Convert.ToInt32(Session["SeekerId"]),
                    JobApplicationID = id,
                    ApplicationDate = DateTime.Now
                    };
                JobSeekerRepository repo = new JobSeekerRepository();
                if (repo.CreateJobApplication(application))
                {
                    TempData["Message"] = "Applied Successfull";
                }
                return RedirectToAction("Jobs");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
      
    }
}