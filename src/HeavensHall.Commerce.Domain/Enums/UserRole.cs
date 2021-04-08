using System.ComponentModel;

namespace HeavensHall.Commerce.Domain.Enums
{
    public enum UserRole
    {
        [Description("Administrador")]
        Admin,

        [Description("Estoquista")]
        Stockist,

        [Description("Cliente")]
        Customer
    }
}
