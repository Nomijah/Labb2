using System.Net;

namespace Labb2.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<String> ErrorMessages { get; set; }
        public Object Result { get; set; }
    }
}
