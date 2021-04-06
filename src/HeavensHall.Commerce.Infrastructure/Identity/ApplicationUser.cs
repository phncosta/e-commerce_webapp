using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "varchar(150)")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
