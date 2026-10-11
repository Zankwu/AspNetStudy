using HttpClientEg.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace HttpClientEg.Services
{
    public class FinnhubService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<FinnHubOptions> _options;

        public FinnhubService(IHttpClientFactory clientFactory, IOptions<FinnHubOptions> options)
        {
            _clientFactory = clientFactory;
            _options = options;
        }

        public async Task<Dictionary<string, object>?> GetStockPrice(string symbol)
        {
            using (HttpClient client = _clientFactory.CreateClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                (HttpMethod.Get, $"https://finnhub.io/api/v1/quote?symbol=AAPL&token={_options.Value.defalutApiKet}");
                HttpResponseMessage response = await client.SendAsync(request);
                Stream responesStream = await response.Content.ReadAsStreamAsync();
                StreamReader read = new StreamReader(responesStream);
                Dictionary<string, object>? cnt = JsonSerializer.Deserialize<Dictionary<string,object>?>(read.ReadToEnd());

                return cnt;
            }



        }
        public async Task<ProfileMySelf> GetStockProfile()
        {
            // API Key 从配置读取，切勿硬编码到源码中
            // https://finnhub.io/api/v1/stock/profile2?symbol=AAPL&token=<YOUR_FINNHUB_API_KEY>
            using (HttpClient client = _clientFactory.CreateClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,requestUri: $"https://finnhub.io/api/v1/stock/profile2?symbol=AAPL&token={_options.Value.defalutApiKet}");
                HttpResponseMessage response = await client.SendAsync(request);
                Stream stream = await response.Content.ReadAsStreamAsync();
                StreamReader read = new StreamReader(stream);
                ProfileMySelf pro= JsonSerializer.Deserialize<ProfileMySelf>(read.ReadToEnd());
                return pro;
            }
        }
    }
}
    