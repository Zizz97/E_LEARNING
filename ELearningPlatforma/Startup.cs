using ELearningPlatforma.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ELearningPlatforma.Startup))]
namespace ELearningPlatforma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUser();
        }

        private void CreateRolesAndUser()
        {
            var _context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@pwais.com";

                //Passwords must have at least one non letter or digit character. Passwords must have at least one uppercase
                var userPassword = "P@$$w0rd";

                var createUsr = userManager.Create(user, userPassword);

                if (createUsr.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrator");
                }
            }
        }
    }
}
