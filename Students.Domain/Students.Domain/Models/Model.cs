namespace Students.Domain.Models
{
    public abstract class Model<TKey>
    {
        public TKey Id { get; set; }
    }
}