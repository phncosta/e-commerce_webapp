using System.ComponentModel.DataAnnotations;

namespace HeavensHall.Commerce.Web.Models
{
    public class ProductModel : BaseModel
    {
        [Display(Name = "Nome do Produto")]
        public string Name { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Cor do produto")]
        public string Color { get; set; }

        [Display(Name = "Qtd. Estrelas")]
        public float Rating { get; set; }

        [Display(Name = "Status")]
        public bool Is_Active { get; set; }

        [Display(Name = "Fotos")]
        public string Image_Path { get; set; }

        public BrandModel Brand { get; set; }
        public CategoryModel Category { get; set; }
        public StockModel Stock { get; set; }
    }
}
