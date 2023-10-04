using JobPortal.Models;
using JobPortal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {
        // GET: Employer
        EmployerRepository emp = new EmployerRepository();
        public ActionResult Index()
        {
            var Employer = emp.Employers().Find(model=>model.EmployerID == Convert.ToInt32(Session["EmployerId"]));
            return View(Employer);
        }

    }
}