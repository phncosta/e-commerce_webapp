using System.Collections.Generic;

namespace HeavensHall.Commerce.Web.Models
{
    public class CheckoutModel
    {
        List<ProductModel> Products { get; set; }

        List<AddressModel> Addresses { get; set; }

        public CustomerModel Customer { get; set; }
    }
}
