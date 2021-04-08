using HeavensHall.Commerce.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("orders")]
    public class Order : BaseEntity
    {
        [Column("total_amout")]
        public decimal Total_Amount { get; set; }

        [Column("discount")]
        public decimal Discount { get; set; }

        [Column("status", TypeName = "varchar(30)")]
        public string Status { get; set; }

        [Column("creation_date")]
        public DateTime Creation_Date { get; set; }

        [ForeignKey("shipping_id")]
        public Shipping Shipping { get; set; }

        [ForeignKey("payment_id")]
        public Payment Payment { get; set; }

        [Column("user_id")]
        [MaxLength(128)]
        public virtual int UserId { get; set; }
    }
}
