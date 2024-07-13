using System.Collections.Generic;
using System.Threading.Tasks;
using Prueba1.Models;

namespace Prueba1.Services
{
    public interface IApiService
    {
        Task<IEnumerable<EventoDetalle>> GetDetailEventsAsync();
        Task<IEnumerable<Compra>> GetPurchasesAsync();
        Task PostPurchaseAsync(Compra purchase);
    }
}
