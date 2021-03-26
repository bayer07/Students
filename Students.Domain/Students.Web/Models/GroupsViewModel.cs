using System.Collections.Generic;
using Students.Web.DTOs;

namespace Students.Web.Models
{
    public class GroupsViewModel
    {
        public string Name { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}