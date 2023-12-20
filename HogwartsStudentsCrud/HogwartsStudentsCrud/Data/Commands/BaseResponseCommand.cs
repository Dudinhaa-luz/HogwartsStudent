using System.Net;

namespace HogwartsStudentsCrud.Data.Commands
{
    public class BaseResponseCommand<T>
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T? Object { get; set; }
    }
}
