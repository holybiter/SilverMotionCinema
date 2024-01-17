using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Net.NetworkInformation;
using SilverMotionCinema.Areas;
using SilverMotionCinema.Data;
using SilverMotionCinema.Areas.Identity.Data;

namespace SilverMotionCinema.Controllers
{
    public class RolesController : Controller
    {
        private string AdminRole = "Admin";
        private string UserEmail = "test@example.com";
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<SilverMotionUser> userManager;

    public RolesController(RoleManager<IdentityRole> roleManager, UserManager<SilverMotionUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            if (!(await roleManager.RoleExistsAsync(AdminRole)))
            {
                await roleManager.CreateAsync(new IdentityRole(AdminRole));
            }
            SilverMotionUser user = await userManager.FindByEmailAsync(UserEmail);
            if (user == null)
            {
                user = new();
                user.UserName = UserEmail;
                user.Email = UserEmail;
                IdentityResult result = await userManager.CreateAsync(user, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    Console.WriteLine($"User {user.UserName} created successfully.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
            if (!user.EmailConfirmed)
            {
                string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                IdentityResult result = await userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    Console.WriteLine($"User {user.UserName} email confirmed successfully.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
            if (!(await userManager.IsInRoleAsync(user, AdminRole)))
            {
                IdentityResult result = await userManager.AddToRoleAsync(user,
                AdminRole);
                if (result.Succeeded)
                {
                    Console.WriteLine($"User {user.UserName} added to {AdminRole} successfully.");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                }
            }
            return Redirect("/");
        }
    }

}