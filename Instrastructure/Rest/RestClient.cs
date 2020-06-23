using Instrastructure.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Instrastructure.Rest
{
    public class RestClient : IRestClient
    {
        private ILogger _logger;

        public RestClient(ILogger logger)
        {
            _logger = logger;
        }

        public IEnumerable<T> Execute<T>(Uri url)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    using (var response = client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).GetAwaiter().GetResult())
                    {
                        var stream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();

                        if (response.IsSuccessStatusCode)
                            return DeserializeJsonFromStream<List<T>>(stream);

                        var content = StreamToStringAsync(stream).GetAwaiter().GetResult();

                        _logger.LogWarning($"Rest call error: Code = {response.StatusCode}, Message = {content}");

                        throw new ApiException
                        {
                            StatusCode = (int)response.StatusCode,
                            Content = content
                        };
                    }
                }
            }
        }

        private static T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        private static async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

    }
}
