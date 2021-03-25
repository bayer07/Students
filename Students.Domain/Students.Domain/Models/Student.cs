using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Students.Domain.Enums;

namespace Students.Domain.Models
{
    public class Student : Model<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [MaxLength(60)]
        public string Patronymic { get; set; }

        [MinLength(6)]
        [MaxLength(16)]
        public string UniqIdentity { get; set; }

        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
    }
}
