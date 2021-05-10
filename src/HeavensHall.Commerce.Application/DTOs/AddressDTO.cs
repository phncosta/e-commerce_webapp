
namespace HeavensHall.Commerce.Application.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public bool Active { get; set; }
    }
}
