using System.ComponentModel.DataAnnotations;

namespace DDD.Domain.Models
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public Guid Uid { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Message { get; set; }

    }
}