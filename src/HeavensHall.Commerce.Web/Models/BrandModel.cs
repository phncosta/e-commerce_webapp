using HeavensHall.Commerce.Application.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class BrandModel : BaseModel
    {
        [Display(Name = "Marca do produto")]
        public string Name { get; set; }
    }
}
