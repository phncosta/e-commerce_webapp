using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("product_details")]
    public class ProductDetail : BaseEntity
    {
        [Column("color")]
        public string Color { get; set; }

        [Column("rating")]
        public float Rating { get; set; }

        [Column("is_active")]
        public bool Is_Active { get; set; }

        [Column("image_path")]
        public string Image_Path { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
