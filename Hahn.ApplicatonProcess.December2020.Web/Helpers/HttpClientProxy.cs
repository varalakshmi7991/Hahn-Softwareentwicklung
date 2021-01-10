using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers
{
    public class HttpClientProxy
    {
        public async Task<HttpResponseMessage> Get(Uri uri)
        {
            using(var httpClient = new HttpClient())
            {
                return await httpClient.GetAsync(uri).ConfigureAwait(false);
            }
        } 
        public async Task<HttpResponseMessage> Post(Uri uri, Object content )
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                var json = JsonConvert.SerializeObject(content);
                using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    request.Content = stringContent;

                    using (var response = await client
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false))
                    {
                        response.EnsureSuccessStatusCode();
                        return response;
                    }
                }
            }
        }
    }
}
