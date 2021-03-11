using HeavensHall.Commerce.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("shippings")]
    public class Shipping : BaseEntity
    {
        [Column("shipping_charge")]
        public decimal Shipping_Charge { get; set; }

        [Column("shipping_address_id")]
        public int Shipping_Address_Id { get; set; }

        [Column("billing_address_id")]
        public int Billing_Address_Id { get; set; }
    }
}
