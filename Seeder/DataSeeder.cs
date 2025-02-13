using Microsoft.AspNetCore.Identity;

public class DataSeeder
{
    private readonly ApplicationDbContext _applicationDbContext;

    public DataSeeder(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }


    public void SeedRoleId()
    {
        if (!_applicationDbContext.UserRoles.Any())
        {
            IEnumerable<IdentityUserRole<string>> userRole = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    UserId = "ccbee901-52ce-465c-a34e-5474a89b0fb9",
                    RoleId = "cd6a7ac2-0bab-4c0a-9619-6efe2408d97e"
                }
            };

            _applicationDbContext.AddRange(userRole);
            _applicationDbContext.SaveChanges();
        }
    }


}