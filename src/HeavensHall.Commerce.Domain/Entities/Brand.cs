using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("brands")]
    public class Brand : BaseEntity
    {
        [Column("name", TypeName = "varchar(80)")]
        public string Name { get; set; }
    }
}
