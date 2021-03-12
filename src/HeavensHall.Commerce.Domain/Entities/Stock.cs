using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("stock")]
    public class Stock : BaseEntity
    {
        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("price")]
        public decimal Price { get; set; }
        
        [ForeignKey("product_id")]
        public Product Product { get; set; }
    }
}
