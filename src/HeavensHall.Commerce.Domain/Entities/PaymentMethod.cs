using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("payment_methods")]
    public class PaymentMethod : BaseEntity
    {
        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
