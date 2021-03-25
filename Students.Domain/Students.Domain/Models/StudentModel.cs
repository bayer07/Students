using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Models
{
    public abstract class StudentModel
    {
        [Key]
        public int Id { get; set; }
    }
}