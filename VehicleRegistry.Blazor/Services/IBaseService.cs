using VehicleRegistry.Application.VehicleDetail;

namespace VehicleRegistry.Blazor.Services
{
    public interface IBaseService<T>
    {
        Task<bool> AddUpdate(T item);
        Task<bool> Delete(int id);
        Task<T> FindById(int id);
        Task<List<T>> GetAllAsync();
    }
}
