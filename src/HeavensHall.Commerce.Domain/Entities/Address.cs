using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("addresses")]
    public class Address : BaseEntity
    {
        [Column("address_1", TypeName = "varchar(200)")]
        public string Address_1 { get; set; }

        [Column("address_2", TypeName = "varchar(200)")]
        public string Address_2 { get; set; }

        [Column("city", TypeName = "varchar(100)")]
        public string City { get; set; }

        [Column("state", TypeName = "varchar(100)")]
        public string State { get; set; }

        [Column("country", TypeName = "varchar(60)")]
        public string Country { get; set; }

        [Required]
        [Column("postal_code", TypeName = "varchar(60)")]
        public string PostalCode { get; set; }

        [Column("is_active")]
        public bool Active { get; set; }

        [ForeignKey("customer_id")]
        public Customer Customer { get; set; }
    }
}
