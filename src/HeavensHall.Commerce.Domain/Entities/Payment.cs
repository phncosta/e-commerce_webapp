using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("payments")]
    public class Payment : BaseEntity
    {
        [Column("status")]
        public string Status { get; set; }

        [Column("payment_method_id")]
        public PaymentMethod Payment_Method_Id { get; set; }
    }
}
