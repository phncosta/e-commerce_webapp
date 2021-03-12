using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("products")]
    public class Product : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [ForeignKey("brand_id")]
        public Brand Brand { get; set; }

        [ForeignKey("category_id")]
        public Category Category { get; set; }
    }
}
