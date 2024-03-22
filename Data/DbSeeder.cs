namespace BooksShop.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var _userManager = service.GetService<UserManager<IdentityUser>>();
            var _roleManager = service.GetService<RoleManager<IdentityRole>>();

            await _roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

            await _roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            var DefaultAdmin = new IdentityUser()
            {
                UserName = "DefaultAdmin@gmail.com",
                Email = "DefaultAdmin@gmail.com",
                EmailConfirmed = true,

            };

            var isAdminExisted = await _userManager.FindByEmailAsync(DefaultAdmin.Email);
            if (isAdminExisted is null)
            {
               await _userManager.CreateAsync(DefaultAdmin,"Admin2000@");
               await _userManager.AddToRoleAsync(DefaultAdmin,Roles.Admin.ToString());
            }

        }
    }
}
