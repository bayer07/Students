namespace Students.Domain.Interfaces
{
    public interface IModel<TKey>
    {
        TKey Id { get; set; }
    }
}