using Students.Domain.Enums;

namespace Students.Web.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public string Groups { get; set; }

        public string UniqIdentity { get; set; }
    }
}