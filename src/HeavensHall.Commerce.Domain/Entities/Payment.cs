using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("payments")]
    public class Payment : BaseEntity
    {
        [Column("status")]
        public string Status { get; set; }

        [Column("payment_type")]
        public string Payment_Type { get; set; }
    }
}
