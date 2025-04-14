using AbySalto.Mid.Application.Interfaces;
using AbySalto.Mid.Application.DTO;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;

namespace AbySalto.Mid.Infrastructure.Services
{
    public class ExternalProductService : IExternalProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;

        public ExternalProductService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<List<Product>?> GetAllProductsAsync()
        {
            return await _cache.GetOrCreateAsync("all-products", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                var response = await _httpClient.GetFromJsonAsync<DummyProductResponse>("/products");
                return response?.Products;
            });
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _cache.GetOrCreateAsync($"product-{id}", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                return await _httpClient.GetFromJsonAsync<Product>($"/products/{id}");
            });
        }

        private class DummyProductResponse
        {
            public List<Product> Products { get; set; }
        }
    }
}
