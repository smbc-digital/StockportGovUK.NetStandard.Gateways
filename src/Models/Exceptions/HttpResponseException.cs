using System;
using System.Net;

namespace StockportGovUK.NetStandard.Gateways.Models.Exceptions
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException() { }
        public HttpResponseException(HttpStatusCode statusCode, object value = null) : base(value.ToString())
            => (StatusCode, Value) = ((int)statusCode, value);

        public HttpResponseException(int statusCode, object value = null) : base(value.ToString())
            => (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; set; } = 500;

        public object Value { get; set; }
    }
}
