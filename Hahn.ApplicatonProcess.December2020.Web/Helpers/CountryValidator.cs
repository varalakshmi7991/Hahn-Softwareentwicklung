using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers
{
    public class CountryValidator
    {
        private HttpClientProxy myHttpClientProxy;
        private string restCountriesApi;

        public CountryValidator(HttpClientProxy httpClientProxy, IConfiguration configuration)
        {
            myHttpClientProxy = httpClientProxy;
            restCountriesApi = configuration.GetSection("RestCountriesApi").ToString();
        }
        public async Task<bool> IsCountryValid(string countryName)
        {
            var response = await myHttpClientProxy.Get(new System.Uri($"{restCountriesApi}/{countryName}?fullText=true"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody.Contains(countryName, System.StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
