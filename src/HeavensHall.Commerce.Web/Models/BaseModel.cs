using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class BaseModel
    {
        [Display(Name = "ID do Produto")]
        public int Id { get; set; }
    }
}
