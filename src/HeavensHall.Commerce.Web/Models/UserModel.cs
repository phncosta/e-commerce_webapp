
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class UserModel : UserCredentialsModel
    {
        public string Name { get; set; }

        public string Role { get; set; }
    }
}
