using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("customers")]
    public class Customer : BaseEntity
    {
        [Required]
        [Column("cpf", TypeName = "varchar(14)")]
        public string Cpf { get; set; }

        [Column("telephone_number", TypeName = "varchar(18)")]
        public string TelephoneNumber { get; set; }

        [Column("cellphone_number", TypeName = "varchar(18)")]
        public string CellphoneNumber { get; set; }

        [Required]
        [Column("gender")]
        public char Gender { get; set; }

        [Column("user_id")]
        [MaxLength(128)]
        public virtual string UserId { get; set; }
    }
}
