using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class UserCredentialsModel
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha uma senha.")]
        [MinLength(3, ErrorMessage = "A senha deve possuir no mínimo 3 caracteres.")]
        public string Password { get; set; }

        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas informadas devem ser iguais.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preencha o e-mail.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
