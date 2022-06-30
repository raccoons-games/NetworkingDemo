namespace ExchangeRates.Networking.Api.Responses
{
    public class ConversionPairRateResponse : BaseExchangeRatesResponse
    {
        public string target_code;
        public double conversion_rate;
    }
}
