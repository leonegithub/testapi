namespace TestApi.Models.Dto
{
    public class ApplicationUserDTO
    {
        public string? Username { get; set; }
        public string? Role { get; set; }

        public static ApplicationUserDTO MapToDTOUser(ApplicationUser applicationUser)
        {
            return new ApplicationUserDTO
            {
                Username = $"{applicationUser.FirstName} {applicationUser.LastName}",
                Role = applicationUser.Role
            };
        }
    }
}