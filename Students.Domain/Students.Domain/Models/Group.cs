using System.ComponentModel.DataAnnotations;
using Students.Domain.Interfaces;

namespace Students.Domain.Models
{
    public class Group<TKey> : IModel<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}