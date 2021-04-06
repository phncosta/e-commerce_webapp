using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class UserModel : UserCredentialsModel
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [MinLength(5, ErrorMessage = "Digite um nome maior que 5 caracteres.")]
        public string Name { get; set; }

        public string Role { get; set; }
        public bool IsActive { get; set; }
    }
}
