namespace Students.Domain.Models
{
    public abstract class Model<T>
    {
        T Id { get; set; }
    }
}