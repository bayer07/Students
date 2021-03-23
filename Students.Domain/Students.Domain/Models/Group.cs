using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Models
{
    public class Group<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}