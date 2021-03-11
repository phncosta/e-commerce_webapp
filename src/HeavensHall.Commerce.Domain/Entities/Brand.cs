using HeavensHall.Commerce.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Entities
{
    [Table("brands")]
    public class Brand : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
