using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column("description", TypeName = "TEXT")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("is_active")]
        public bool Is_Active { get; set; }

        [ForeignKey("brand_id")]
        public Brand Brand { get; set; }

        [ForeignKey("category_id")]
        public Category Category { get; set; }
    }
}
