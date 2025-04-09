using SurtechChallenge.Application.Interfaces;
using SurtechChallenge.Domain.Entities;
using System.Net.Http.Json;

namespace SurtechChallenge.Infrastructure.Services
{
    public class RestfulApiService : IRestfulApiService
    {
        private readonly HttpClient _httpClient;

        public RestfulApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.restful-api.dev/");
        }

        public async Task<IEnumerable<ApiObject>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ApiObject>>("objects");
            return response ?? new List<ApiObject>();
        }

        public async Task<ApiObject?> GetByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<ApiObject>($"objects/{id}");
        }

        public async Task<ApiObject> CreateAsync(ApiObject obj)
        {
            var response = await _httpClient.PostAsJsonAsync("objects", obj);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ApiObject>() ?? new ApiObject();
        }

        public async Task<ApiObject> UpdateAsync(string id, ApiObject obj)
        {
            var response = await _httpClient.PutAsJsonAsync($"objects/{id}", obj);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ApiObject>() ?? new ApiObject();
        }
    }
}
