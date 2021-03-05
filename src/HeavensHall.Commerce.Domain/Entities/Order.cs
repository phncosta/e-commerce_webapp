
using System;

namespace HeavensHall.Commerce.Domain.Entities
{
    public class Order : Entity
    {
        public decimal Total_Amount { get; set; }
        public decimal Discount { get; set; }
        public string Status { get; set; }
        public DateTime Creation_Date { get; set; }
        public Guid Shipping_Id { get; set; }
        public Guid Payment_Id { get; set; }
        public Guid User_Id { get; set; }
    }
}
