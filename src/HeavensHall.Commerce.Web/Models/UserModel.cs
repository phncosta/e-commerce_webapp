using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class UserModel : UserCredentialsModel
    {
        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [MinLength(5, ErrorMessage = "Digite um nome maior que 5 caracteres.")]
        public override string Name { get; set; }
    }
}
