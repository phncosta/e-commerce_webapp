using System;

namespace HeavensHall.Commerce.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Category_Id { get; set; }
        public Guid Product_Details_Id { get; set; }
        public Guid Brand_Id { get; set; }
    }
}
