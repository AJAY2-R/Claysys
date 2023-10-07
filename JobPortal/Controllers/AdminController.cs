using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JobPortal.Models;
using JobPortal.Repository;

namespace JobPortal.Controllers
{
    
    public class AdminController : Controller
    {  
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            ModelState.Clear();
            return View();
        }
        /// <summary>
        /// Admin Login
        /// </summary>
        /// <param name="formCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {
            try
            {
                string Username = formCollection["Username"];
                string Password = formCollection["Password"];
                AdminRepository repo = new AdminRepository();
                if (repo.AdminLogin(Username, Password))
                {
                    FormsAuthentication.SetAuthCookie(Username, false);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    TempData["Message"] = "Invalid Password & Username";
                    return View();
                }
            }catch (Exception ex)
            {
                return View(ex);
            }
        }
        /// <summary>
        /// Add Skills
        /// </summary>
        /// <returns></returns>
        public ActionResult AddSkills()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkills(Skills obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AdminRepository repo = new AdminRepository();//Repository instance
                    if (repo.AddSkill(obj))
                    {
                        TempData["Message"] = "Skill added ";
                        return RedirectToAction("AddSkills");
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Show skills
        /// </summary>
        /// <returns></returns>
        public ActionResult Skills()
        {
            PublicRepository repo = new PublicRepository();
            var skills = repo.DisplaySkills();
            return View(skills);
        }
        /// <summary>
        /// Display Categories
        /// </summary>
        /// <returns></returns>
        public ActionResult Categories()
        {
            PublicRepository repo = new PublicRepository();
            var cate = repo.DisplayCategories();
            return View(cate);
        }
        /// <summary>
        /// Edit skills
        /// </summary>
        /// <param name="id">Skill id</param>
        /// <returns></returns>
        public ActionResult EditSkill(int id)
        {
            PublicRepository repo = new PublicRepository();
            var skill = repo.DisplaySkills().Find(sk => sk.SkillId == id);
            return View(skill);
        }
        /// <summary>
        /// Edit skill
        /// </summary>
        /// <param name="id">Skill id</param>
        /// <param name="obj">Skill object</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditSkill(int id, Skills obj)
        {
            try
            {
                AdminRepository repo = new AdminRepository();
                if (repo.EditSkill(obj, id))
                {
                    TempData["Message"] = "Skill Updated";
                    return RedirectToAction("DisplaySkills", "Admin");
                   
                }
                return View();
            }catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        /// <summary>
        /// Add category
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCategory()
        {
            return View();  
        }
        /// <summary>
        /// Add Category
        /// </summary>
        /// <param name="cat">Category model instance </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            try
            {
                AdminRepository repo = new AdminRepository();
                if (repo.AddCategory(cat))
                {
                    TempData["Message"] = "Category added ";
                    return RedirectToAction("AddCategory");
                   
                }
                return View();
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Edit category
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns></returns>
        public ActionResult EditCategory(int id)
        {
            try
            {
                PublicRepository repo = new PublicRepository();
                var category = repo.DisplayCategories().Find(cat => cat.CategoryId == id);
                return View(category);
            }catch(Exception ex)
            {
                return View(ex.Message);    
            }
        } 
        /// <summary>
        /// Pending verfication list of Employer
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyEmployer()
        {
            try
            {
                EmployerRepository repo = new EmployerRepository();
                var employer = repo.Employers().Where(emp => emp.Status == "Pending");
                return View(employer);
            }catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Approve Employer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployerApprove(int id)
        {
            try
            {
                AdminRepository repo = new AdminRepository();
                if (repo.EmployerApprove(id))
                {
                    TempData["Message"] = "Employer approved..";
                    return RedirectToAction("VerifyEmployer");
                }
                return View();
            }catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Employer reject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EmployerReject(int id)
        {
            try
            {
                AdminRepository repo = new AdminRepository();
                if (repo.EmployerReject(id))
                {
                    TempData["Message"] = "Employer rejected..";
                    return RedirectToAction("VerifyEmployer");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        /// <summary>
        /// Display all the job seekers
        /// </summary>
        /// <returns></returns>
        public ActionResult JobSeekers()
        {
            JobSeekerRepository repo = new JobSeekerRepository();
            return View(repo.JobSeekers());
        }
        /// <summary>
        /// Display all the Employers 
        /// </summary>
        /// <returns></returns>
        public ActionResult Employers()
        {
            EmployerRepository repo = new EmployerRepository();
            return View(repo.Employers());
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

        /// <summary>
        /// Add admin
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            AdminRepository repo = new AdminRepository();
            try
            {
                if (repo.AddAdmin(admin)) {
                    TempData["Message"] = "Admin added successfully"
;                }
                return RedirectToAction("Index");
            }
            catch (Exception ex) { 
            return View(ex.Message);
            }
        }
        /// <summary>
        /// Admin chnage password 
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string oldPassword,string newPassword)
        {
            try
            {
                AdminRepository repo = new AdminRepository();
                if (repo.ChangePassword(oldPassword, newPassword, Convert.ToString(Session["Admin"]))){
                    TempData["Message"] = "Password changed";
                }
                else
                {
                    TempData["Message"] = "Wrong password";
                    return View();
                }
                return RedirectToAction("Index");
            }catch(Exception ex) {
                return View(ex.Message);
            }
        }
    }
}