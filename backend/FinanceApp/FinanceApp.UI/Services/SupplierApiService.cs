using FinanceApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp.UI.Services
{
    public class SupplierApiService
    {
        private readonly HttpClient _http;

        public SupplierApiService()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/api/")
            };
        }

        public async Task Create(string name)
        {
            await _http.PostAsJsonAsync("suppliers", name);
        }

        public async Task<List<SupplierDto>> GetAll()
        {
            var result = await _http.GetFromJsonAsync<List<SupplierDto>>("suppliers/with-balance");
            return result ?? new List<SupplierDto>();
        }
    }
}