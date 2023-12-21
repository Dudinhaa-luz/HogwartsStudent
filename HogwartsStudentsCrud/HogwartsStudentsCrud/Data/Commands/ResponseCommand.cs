using HogwartsStudentsCrud.Model.Entities;
using System.Net;

namespace HogwartsStudentsCrud.Data.Commands
{
    public class ResponseCommand<T> : BaseResponseCommand
    {
        public T? Object { get; set; }
    }

    public class ResponseCommand : BaseResponseCommand
    {

    }

    public class BaseResponseCommand
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }

    public static class ResponseMessages
    {
        public static BaseResponseCommand ExceptionResponse(Exception ex)
        {
            return new BaseResponseCommand
            {
                Code = HttpStatusCode.Conflict,
                Message = $"Não conseguimos realizar seu cadastro, talvez você seja um trouxa! Exception: {ex.Message}",
                IsSuccess = false
            };
        }
    }
}
