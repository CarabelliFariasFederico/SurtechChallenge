using SurtechChallenge.Domain.Entities;

namespace SurtechChallenge.Application.Interfaces;

public interface IRestfulApiService
{
    Task<IEnumerable<ApiObject>> GetAllAsync();
    Task<ApiObject?> GetByIdAsync(string id);
    Task<ApiObject> CreateAsync(ApiObject obj);
    Task<ApiObject> UpdateAsync(string id, ApiObject obj);
}

