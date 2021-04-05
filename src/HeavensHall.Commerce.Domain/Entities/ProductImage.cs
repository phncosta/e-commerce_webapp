using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("product_images")]
    public class ProductImage : BaseEntity
    {
        [Column("main")]
        public bool Main { get; set; }

        [Column("path", TypeName = "varchar(255)")]
        public string Path { get; set; }

        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
