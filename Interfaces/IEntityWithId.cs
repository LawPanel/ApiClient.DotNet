
namespace LawPanel.ApiClient.Interfaces
{
    public interface IEntityWithId<T> 
    {
        T Id { get; set; }
    }
}
