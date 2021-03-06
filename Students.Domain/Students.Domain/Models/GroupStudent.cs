namespace Students.Domain.Models
{
    public class GroupStudent : StudentModel
    {
        public int GroupId { get; set; }

        public Group Group { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}