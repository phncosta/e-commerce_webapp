using HeavensHall.Commerce.Application.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class CustomerModel : BaseModel
    {
        [Display(Name = "CPF"), Required]
        [MaxLength(14, ErrorMessage = "CPF deve possuir no máximo 14 caracteres.")]
        public string Cpf { get; set; }

        [Display(Name = "Sexo"), Required]
        public char Gender { get; set; }

        [Display(Name = "Telefone")] 
        [MaxLength(18, ErrorMessage = "Telefone deve possuir no máximo 18 caracteres.")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Celular")]
        [MaxLength(18, ErrorMessage = "Celular deve possuir no máximo 18 caracteres.")]
        public string CellphoneNumber { get; set; }

        public List<AddressModel> Addresses { get; set; }
        public AddressModel Address { get; set; }
        public UserModel User { get; set; }
    }
}
