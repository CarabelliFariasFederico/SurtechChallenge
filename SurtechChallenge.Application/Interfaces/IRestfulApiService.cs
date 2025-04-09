
namespace SurtechChallenge.Application.Interfaces
{
    using SurtechChallenge.Domain.Entities;

    public interface IRestfulApiService
    {
        Task<IEnumerable<ApiObject>> GetAllAsync();
        Task<ApiObject?> GetByIdAsync(string id);
        Task<ApiObject> CreateAsync(ApiObject obj);
        Task<ApiObject> UpdateAsync(string id, ApiObject obj);
    }
}
