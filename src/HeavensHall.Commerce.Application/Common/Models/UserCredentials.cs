
namespace HeavensHall.Commerce.Application.Common.Models
{
    public class UserCredentials
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Role { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool RememberMe { get; set; }
    }
}

