using Labb1.Models;
using Labb1.Models.DTOs;
using Labb2.Services.IServices;
using static Labb2.Utility.StaticDetails;

namespace Labb2.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _clientFactory;
        public BookService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> CreateBookAsync<T>(BookCreateDTO book)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.POST,
                Data = book,
                Url = BookApiBase + "/books",
                Token = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.DELETE,
                Url = BookApiBase + "/books/" + id,
                Token = ""
            });
        }

        public async Task<T> GetAllBooks<T>()
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.GET,
                Url = BookApiBase + "/books",
                Token = ""
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.GET,
                Url = BookApiBase + "/books/" + id,
                Token = ""
            });
        }

        public async Task<T> GetBooksByAuthor<T>(string author)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.GET,
                Url = BookApiBase + "/books/author/" + author,
                Token = ""
            });
        }

        public async Task<T> GetBooksByTitle<T>(string title)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.GET,
                Url = BookApiBase + "/books/title/" + title,
                Token = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(Book book)
        {
            return await this.SendAsync<T>(new Models.APIRequest
            {
                ApiType = ApiType.PUT,
                Data = book,
                Url = BookApiBase + "/books",
                Token = ""
            });
        }
    }
}
