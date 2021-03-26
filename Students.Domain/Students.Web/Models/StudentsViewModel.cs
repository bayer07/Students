using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Students.Web.DTOs;

namespace Students.Web.Models
{
    public class StudentsViewModel
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string Group { get; set; }
        public int Gender { get; set; }
        public int? PageNumber { get; set; }
        public SelectList GenderList { get; set; }
        public List<StudentDto> Students { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
    }
}