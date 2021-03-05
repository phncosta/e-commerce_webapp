
using System;

namespace HeavensHall.Commerce.Domain.Entities
{
    public class Address : Entity
    {
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postal_Code { get; set; }
        public Guid User_Id { get; set; }
    }
}
