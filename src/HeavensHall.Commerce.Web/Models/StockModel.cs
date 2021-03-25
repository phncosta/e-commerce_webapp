
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class StockModel : BaseModel
    {
        [Display(Name = "Qtd. Estoque")]
        public int Quantity { get; set; }
    }
}
