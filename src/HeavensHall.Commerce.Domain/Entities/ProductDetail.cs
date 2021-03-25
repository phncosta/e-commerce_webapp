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

        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
