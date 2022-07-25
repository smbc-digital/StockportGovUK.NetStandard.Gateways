using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockportGovUK.NetStandard.Gateways.Response
{
    public class HttpResponse<T>
    {
        public HttpResponseHeaders Headers { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public string ReasonPhrase { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public Version Version { get; set; }

        public T ResponseContent { get; set; }

        public static async Task<HttpResponse<T>> Get(HttpResponseMessage responseMessage)
        {
            T deserializedObject;

            try
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                deserializedObject = JsonSerializer.Deserialize<T>(content);
            }
            catch (Exception)
            {
                deserializedObject = default(T);
            }

            return new HttpResponse<T>
            {
                ResponseContent = deserializedObject,
                Headers = responseMessage.Headers,
                IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
                ReasonPhrase = responseMessage.ReasonPhrase,
                StatusCode = responseMessage.StatusCode,
                Version = responseMessage.Version
            };
        }
    }

    public class HttpResponse
    {
        public HttpResponseHeaders Headers { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public string ReasonPhrase { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public Version Version { get; set; }

        public static HttpResponse Get(HttpResponseMessage responseMessage)
        {
            return new HttpResponse
            {
                Headers = responseMessage.Headers,
                IsSuccessStatusCode = responseMessage.IsSuccessStatusCode,
                ReasonPhrase = responseMessage.ReasonPhrase,
                StatusCode = responseMessage.StatusCode,
                Version = responseMessage.Version
            };
        }
    }
}
