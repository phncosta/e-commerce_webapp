using HeavensHall.Commerce.Application.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class AddressModel : BaseModel
    {
        [Required]
        [Display(Name = "Rua")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int Number { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "CEP")]
        public string PostalCode { get; set; }

        [Display(Name = "Rua e Número")]
        public string Address_1 { get; set; }

        [Display(Name = "Bairro / Complemento")]
        public string Address_2 { get; set; }
    }
}
