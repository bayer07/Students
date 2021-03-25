using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Models
{
    public class Group : StudentModel
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<GroupStudent> GroupStudents { get; set; }
    }
}