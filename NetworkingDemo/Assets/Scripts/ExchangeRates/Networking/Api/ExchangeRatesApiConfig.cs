using Raccoons.Networking.Api.Configs;
using UnityEngine;

namespace ExchangeRates.Networking.Api
{
    public class ExchangeRatesApiConfig : BaseApiConfig
    {
        public string apiUrl;

        public string apiKey;

        public string version;

        public string GetApiKey()
        {
            return apiKey;
        }

        public string GetVersion()
        {
            return version;
        }

        public override string GetApiUrl()
        {
            return apiUrl;
        }
    }
}