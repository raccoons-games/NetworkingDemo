using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Networking.Api.Responses
{
    public class ConversionRatesResponse : BaseExchangeRatesResponse
    {
        public Dictionary<string, double> conversion_rates;
    }
}
