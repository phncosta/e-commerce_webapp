
using System;

namespace HeavensHall.Commerce.Domain.Entities
{
    public class Stock : Entity
    {
        public Guid Product_Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
