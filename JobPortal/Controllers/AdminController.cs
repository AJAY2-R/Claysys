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

        [Authorize]
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

        public ActionResult DisplaySkills()
        {
            PublicRepository repo = new PublicRepository();
            var skills = repo.DisplaySkills();
            return View(skills);
        }
        public ActionResult EditSkill(int id)
        {
            PublicRepository repo = new PublicRepository();
            var skill = repo.DisplaySkills().Find(sk => sk.SkillId == id);
            return View(skill);
        }
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
    }
}