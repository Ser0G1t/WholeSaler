using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WholeSaler.ApiProvider
{
    public class CEIDGApiProvider : ICEIDGApiProvider
    {
        private const string BASE_URL = "https://wl-api.mf.gov.pl/";
        private const string NIP_END_POINT = "api/search/nip/";
        private readonly HttpClient _httpClient;

        public CEIDGApiProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(BASE_URL);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        //7792343623?date=2024-01-05
        public async Task<dynamic> checkNip(string nip)
        {
            string getDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            dynamic company = null;
            HttpResponseMessage response = await _httpClient.GetAsync($"{NIP_END_POINT}/{nip}?date={getDate}");

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                company = JsonConvert.DeserializeObject<dynamic>(responseData);
                Console.WriteLine(company.result.subject.name);
                Console.WriteLine(company.result.subject.nip);
            }
            return company;
        }
    }
}
