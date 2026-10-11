using System.Text.Json.Serialization;

namespace HttpClientEg
{
    public class ProfileMySelf
    {
        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;


        public string Currency { get; set; } = string.Empty;


        public string Exchange { get; set; } = string.Empty;

        /// <summary>IPO 日期，格式 "yyyy-MM-dd"，注意可能是空字符串</summary>

        public string Ipo { get; set; } = string.Empty;

        /// <summary>市值，单位：百万美元（Finnhub 的约定，不是美元）</summary>

        public decimal MarketCapitalization { get; set; }


        public string Name { get; set; } = string.Empty;


        public string Phone { get; set; } = string.Empty;

        /// <summary>流通股数，单位：百万股</summary>

        public double ShareOutstanding { get; set; }


        public string Ticker { get; set; } = string.Empty;


        public string WebUrl { get; set; } = string.Empty;


        public string Logo { get; set; } = string.Empty;


        public string Industry { get; set; } = string.Empty;

        /// <summary>便捷属性：换算成美元的真实市值，不会参与序列化</summary>
        [JsonIgnore]
        public decimal MarketCapUsd => MarketCapitalization * 1_000_000m;
    }
}
