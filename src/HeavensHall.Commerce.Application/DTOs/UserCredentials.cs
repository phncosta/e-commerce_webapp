
namespace HeavensHall.Commerce.Application.DTOs
{
    public class UserCredentials
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public bool RememberMe { get; set; }
    }
}
