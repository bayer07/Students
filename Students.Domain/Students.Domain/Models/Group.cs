﻿using System.ComponentModel.DataAnnotations;

namespace Students.Domain.Models
{
    public class Group : Model<int>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}