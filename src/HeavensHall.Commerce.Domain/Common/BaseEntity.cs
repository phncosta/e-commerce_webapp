using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeavensHall.Commerce.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
