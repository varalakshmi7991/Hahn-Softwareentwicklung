using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Web.Helpers
{
    public class CountryValidator
    {
        private readonly IConfiguration myConfiguration;
        private HttpClientProxy myHttpClientProxy;
        private string restCountriesApi;

        public CountryValidator(HttpClientProxy httpClientProxy, IConfiguration configuration)
        {
            myConfiguration = configuration;
            myHttpClientProxy = httpClientProxy;
            restCountriesApi = myConfiguration.GetSection("RestCountriesApi").Value;
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
