using ExchangeRates.Networking.Api.Responses;
using Raccoons.Networking.Api.Clients;
using Raccoons.Networking.Api.WebRequests;
using Raccoons.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ExchangeRates.Networking.Api
{
    public class ExchangeRatesApiClient : ApiClient<ExchangeRatesApiConfig>
    {
        public const string LATEST_RATES = "/latest/{0}";
        public const string PAIR_RATE = "/pair/{0}/{1}";
        public const string PAIR_AMOUNT = PAIR_RATE+"/{2}";
        public ExchangeRatesApiClient(ExchangeRatesApiConfig apiConfig, 
            ISerializer serializer, IWebRequestProvider webRequestProvider) 
            : base(apiConfig, serializer, webRequestProvider)
        {
        }

        public override string BuildUrl(string route, params object[] args)
        {
            route = $"/{ApiConfig.GetApiKey()}{route}";
            return base.BuildUrl(route, args);
        }

        public Task<ConversionRatesResponse> GetLatestRatesFor(string baseCode)
        {
            return Get<ConversionRatesResponse>(BuildUrl(LATEST_RATES, baseCode));
        }

        public async Task<string> GetApiIP()
        {
            return (await Dns.GetHostAddressesAsync(new Uri(ApiConfig.GetApiUrl()).Host))[0].ToString();
        }

        public Task<ConversionPairRateResponse> GetPairRate(string baseCode, string targetCode)
        {
            return Get<ConversionPairRateResponse>(BuildUrl(PAIR_RATE, baseCode, targetCode));
        }
        
        public Task<ConversionPairAmountResponse> GetPairAmount(string baseCode, string targetCode, double amount)
        {
            return Get<ConversionPairAmountResponse>(BuildUrl(PAIR_AMOUNT, baseCode, targetCode, amount));
        }
    }
}