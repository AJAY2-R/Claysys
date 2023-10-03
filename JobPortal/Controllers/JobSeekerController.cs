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
        public ActionResult JobSeekerProfile()
        {
            JobSeekerRepository seeker = new JobSeekerRepository();
            var jobseeker = seeker.JobSeekers().Find(model=>model.SeekerId == (int)Session["SeekerId"]);
            return View(jobseeker);
        }
    }
}