using System;

namespace HeavensHall.Commerce.Domain.Entities
{
    public class Shipping : Entity
    {
        public decimal Shipping_Charge { get; set; }
        public Guid Shipping_Address_Id { get; set; }
        public Guid Billing_Address_Id { get; set; }
    }
}
