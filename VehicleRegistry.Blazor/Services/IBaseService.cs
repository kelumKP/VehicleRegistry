using VehicleRegistry.Application.VehicleDetail;

namespace VehicleRegistry.Blazor.Services
{
    public interface IBaseService<T>
    {
        Task<bool> AddUpdate(T item);
        bool Delete(int id);
        T FindById(int id);
        Task<List<T>> GetAllAsync();
    }
}
