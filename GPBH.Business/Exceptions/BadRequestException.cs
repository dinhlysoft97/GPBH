using System;
using System.Net;

namespace GPBH.Business.Exceptions
{
    public class BadRequestException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Meesage { get; set; }
        public BadRequestException(string message) : base(message)
        {
            StatusCode = HttpStatusCode.BadGateway;
            Meesage = message;
        }
    }
}
