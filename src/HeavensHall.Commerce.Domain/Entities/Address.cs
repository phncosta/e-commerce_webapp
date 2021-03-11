
using HeavensHall.Commerce.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("addresses")]
    public class Address : BaseEntity
    {
        [Column("address_1")]
        public string Address_1 { get; set; }

        [Column("address_2")]
        public string Address_2 { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("state")]
        public string State { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("postal_code")]
        public string Postal_Code { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }
    }
}
