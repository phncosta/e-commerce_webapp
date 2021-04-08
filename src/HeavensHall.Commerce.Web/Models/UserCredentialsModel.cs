using HeavensHall.Commerce.Application.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class UserCredentialsModel : UserCredentials
    {
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha uma senha.")]
        [MinLength(3, ErrorMessage = "A senha deve possuir no mínimo 3 caracteres.")]
        public override string Password { get; set; }

        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas informadas devem ser iguais.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Preencha o e-mail.")]
        [EmailAddress]
        public override string Email { get; set; }

        [Display(Name = "Lembrar-me")]
        public override bool RememberMe { get; set; }
    }
}
