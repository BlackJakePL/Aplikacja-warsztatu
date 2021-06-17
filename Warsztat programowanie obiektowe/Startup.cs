using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Warsztat_programowanie_obiektowe.Models;

[assembly: OwinStartupAttribute(typeof(Warsztat_programowanie_obiektowe.Startup))]
namespace Warsztat_programowanie_obiektowe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>());
            var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            if (!roleManager.RoleExists("SuperAdmin"))
            {

                //create super admin
                var role = new IdentityRole("SuperAdmin");
                roleManager.Create(role);

                //create default usr

                var user = new IdentityUser();
                user.UserName = "adm@domain";
                user.Email = "adm@mail.com";
                string pwd = "Qwerty!2";

                var newUsr = userManager.Create(user, pwd);

                if(newUsr.Succeeded)
                {
                    userManager.AddToRole(user.Id, "SuperAdmin");
                }



            }
            else
            {
                //var role = roleManager.FindByName("SuperAdmin");
                //roleManager.Delete(role);
                var user = userManager.FindByName("admin@mail.com");
                //userManager.Delete(user);
                //userManager.AddToRole(user.Id, "SuperAdmin");
            }
        }
    }
}
