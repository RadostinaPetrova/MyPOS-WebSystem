namespace WebAppSystem.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using WebAppSystem.Data;
    using WebAppSystem.Data.Models;

    public class AdministratorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var userExists = userManager.Users.Any(u => u.UserName == GlobalConstants.AdministratorUserName);

            if (!userExists)
            {
                var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();

                var admin = new ApplicationUser
                {
                    UserName = GlobalConstants.AdministratorUserName,
                    Email = GlobalConstants.AdministratorEmail,
                    PhoneNumber = GlobalConstants.AdministratorPhoneNumber,
                };

                PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
                admin.PasswordHash = ph.HashPassword(admin, GlobalConstants.AdministratorPassword);

                var result = await userManager.CreateAsync(admin);

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(string.Join(
                        Environment.NewLine,
                        result.Errors.Select(e => e.Description)));
                }

                var roleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdministratorRoleName);

                if (roleExists)
                {
                    await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}
