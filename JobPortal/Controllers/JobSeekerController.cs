using JobPortal.Models;
using JobPortal.Repository;
using Microsoft.Ajax.Utilities;
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
        public ActionResult UpdateProfile()
        {
            JobSeekerRepository repo = new JobSeekerRepository();
            var jobSeeker = repo.JobSeekers().Find(model => model.SeekerId == (int)Session["SeekerId"]);
            return View(jobSeeker);

        }
        [HttpPost]
        public ActionResult UpdateProfile(JobSeekerModel jobSeeker,HttpPostedFileBase imageUpload)
        {
            try
            {
                JobSeekerRepository repo = new JobSeekerRepository();
                if (repo.JobSeekerUpdate(jobSeeker, imageUpload,Convert.ToInt32(Session["SeekerId"])))
                {
                    TempData["Message"] = "Updated";
                }
                return RedirectToAction("JobSeekerProfile");
            }catch(Exception ex)
            {
                return View(ex.Message);
            }
            
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
        /// <summary>
        /// Visit job to store who visisted the job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ViewJob(int id)
        {
            try
            {
                JobSeekerRepository repo = new JobSeekerRepository();
                ViewJob obj = new ViewJob
                {
                    JobId = id,
                    SeekerId = Convert.ToInt32(Session["SeekerId"]),
                    ViewDate = DateTime.Now,
                };
                if (repo.VisitJob(obj))
                {
                    return new HttpStatusCodeResult(200);
                }
                return new HttpStatusCodeResult(400);
            }
            catch(Exception ){
                return new HttpStatusCodeResult(400);
            }
        }
        /// <summary>
        /// Create and delete bookmark
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Bookmark(int id)
        {
            try
            {
                JobSeekerRepository repo = new JobSeekerRepository();
                Bookmark obj = new Bookmark { 
                    JobId = id,
                    SeekerId = Convert.ToInt32(Session["SeekerId"]),
                };
                if (repo.Bookmark(obj))
                {
                    return new HttpStatusCodeResult(200);
                }
                return new HttpStatusCodeResult(400);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult SavedJobs()
        {
            return View();
        }
        /// <summary>
        /// Display job details 
        /// </summary>
        /// <param name="id">Job id</param>
        /// <returns></returns>
        public ActionResult JobDetails(int id)
        {
            PublicRepository repo =new PublicRepository();
            return View(repo.GetJobDetails().Find(model => model.JobID == id));  

        }
        /// <summary>
        /// View applied jobs and check the status
        /// </summary>
        /// <returns></returns>
        public ActionResult AppliedJobs()
        {
            JobSeekerRepository repo = new JobSeekerRepository();
            int id = Convert.ToInt32(Session["SeekerId"]);
            return View(repo.GetJobApplications(id));
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        /// <summary>
        /// Change password job seeker
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(string oldPassword, string newPassword)
        {
            try
            {
                JobSeekerRepository repo = new JobSeekerRepository();
                if (repo.ChangePassword(oldPassword, newPassword, Convert.ToInt32(Session["SeekerId"])))
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