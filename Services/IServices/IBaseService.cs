using Labb2.Models;

namespace Labb2.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
