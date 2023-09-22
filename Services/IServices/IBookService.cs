using Labb1.Models;
using Labb1.Models.DTOs;

namespace Labb2.Services.IServices
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(int id);
        Task<T> GetBooksByAuthor<T>(string author);
        Task<T> GetBooksByTitle<T>(string title);
        Task<T> CreateBookAsync<T>(BookCreateDTO book);
        Task<T> UpdateBookAsync<T>(Book book);
        Task<T> DeleteBookAsync<T>(int id);
    }
}
