
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class CategoryModel : BaseModel
    {
        [Display(Name = "Categoria")]
        public string Name { get; set; }
    }
}
