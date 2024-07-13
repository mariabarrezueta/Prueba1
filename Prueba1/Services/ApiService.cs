using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Prueba1.Models;

namespace Prueba1.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://localhost:7164/api/"), // Asegúrate de que esta dirección sea correcta
                Timeout = TimeSpan.FromMinutes(2)
            };
        }

        public async Task<IEnumerable<EventoDetalle>> GetDetailEventsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("EventoDetalle").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                var eventos = await response.Content.ReadFromJsonAsync<IEnumerable<EventoDetalle>>().ConfigureAwait(false);
                return eventos ?? new List<EventoDetalle>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Compra>> GetPurchasesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Compras").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<IEnumerable<Compra>>().ConfigureAwait(false) ?? new List<Compra>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }

        public async Task PostPurchaseAsync(Compra purchase)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Compras", purchase).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}
