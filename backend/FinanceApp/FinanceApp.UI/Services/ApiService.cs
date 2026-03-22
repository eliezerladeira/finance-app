using System.Net.Http;
using System.Net.Http.Json;
using FinanceApp.UI.Models;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5191/"); // ajuste a porta
    }

    public async Task<List<PurchaseDto>> GetPurchases(Guid invoiceId)
    {
        var response = await _httpClient.GetFromJsonAsync<List<PurchaseDto>>(
            $"api/purchases?invoiceId={invoiceId}");

        return response ?? new List<PurchaseDto>();
    }
}