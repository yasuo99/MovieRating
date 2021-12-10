using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePage.Services
{
    public static class Response
    {
        public static Response<T> NotFound<T>(string ms, int statusCode = 404, T data = default) => new Response<T>(data, ms, true, statusCode);
        public static Response<T> Conflic<T>(string msg, int statusCode = 409, T data = default) => new Response<T>(data, msg, true, statusCode);
        public static Response<T> Fail<T>(string msg, int statusCode = 400, T data = default) => new Response<T>(data, msg, true, statusCode);
        public static Response<T> Ok<T>(string msg, int statusCode = 200, T data = default) => new Response<T>(data, msg, false, statusCode);
        public static Response<T> NoContent<T>(string msg, int statusCode = 204, T data = default) => new Response<T>(data, msg, false, statusCode);
        public static Response<T> Created<T>(string msg, int statusCode = 201, T data = default) => new Response<T>(data, msg, false, statusCode);
        public static Response<T> Unauthorized<T>(string msg = "You are not authorized", int statusCode = 401, T data = default) => new Response<T>(data, msg, false, statusCode);
    }
    public class Response<T> : ResponseStatus
    {
        public Response(T data, string message, bool error, int statusCode)
        {
            Data = data;
            Message = message;
            Error = error;
            StatusCode = statusCode;
        }
        public Response(string message, bool error, int statusCode)
        {
            Message = message;
            Error = error;
            StatusCode = statusCode;
        }
        public T Data { get; set; }
    }
    public abstract class ResponseStatus
    {
        public string Message { get; set; }
        public bool Error { get; set; }
        public int StatusCode { get; set; }
    }
}
