using HeavensHall.Commerce.Application.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class ProductModel : BaseModel
    {
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Preço")]
        public decimal Price { get; set; }

        [Display(Name = "Cor do produto")]
        public string Color { get; set; }

        [Display(Name = "Qtd. Estrelas")]
        public float Rating { get; set; }

        [Display(Name = "Status")]
        public bool Is_Active { get; set; }

        public BrandModel Brand { get; set; }
        public CategoryModel Category { get; set; }
        public StockModel Stock { get; set; }
        public List<ProductImageModel> Images { get; set; }
    }
}
