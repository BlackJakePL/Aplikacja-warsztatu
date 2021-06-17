using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Warsztat_programowanie_obiektowe.Models;
using Warsztat_programowanie_obiektowe.ViewModel;

namespace Warsztat_programowanie_obiektowe.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            var viewmodel = new  WorkshopViewModel();
            viewmodel.roles = db.Roles.ToList();
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            string userName = form["txtEmail"];
            string email = userName;
            string pwd = form["txtPwd"];
            string role = form["roles"];

            var user = new IdentityUser();
            user.UserName = userName;
            user.Email = email;

            var newUser = userManager.Create(user, pwd);
            userManager.AddToRole(user.Id, role);

            return View();
        }
        public ActionResult CreateRole()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult CreaateRole(FormCollection form)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());

            string rolename = form["Rolename"];
            if (!roleManager.RoleExists(rolename))
            {
                var role = new IdentityRole(rolename);
                roleManager.Create(role);
            }

                return View();

        }

        public ActionResult AssignRole()
        {
            return View();
        }


    }
}