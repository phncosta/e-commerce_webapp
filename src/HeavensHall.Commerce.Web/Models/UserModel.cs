using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class UserModel : UserCredentialsModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [MinLength(5, ErrorMessage = "Digite um nome maior que 5 caracteres.")]
        public override string Name { get; set; }
    }
}
