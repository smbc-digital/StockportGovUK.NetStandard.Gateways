using System.Net.Http;

namespace StockportGovUK.NetStandard.Gateways.Extensions
{
    public static class MultipartFormDataContentExtensions
    {
        public static void AddIfNotNull(this MultipartFormDataContent content, string value, string key)
        {
            if (!string.IsNullOrEmpty(value))
                content.Add(new StringContent(value), key);
        }
    }
}
