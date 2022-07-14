using ExchangeRates.Networking.Api;
using Raccoons.Networking.Runtime.Api.WebRequests.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ExchangeRates.UI
{
    public class CurrencyExchangerCalculator : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField baseCurrencyInput;

        [SerializeField]
        private TMP_InputField baseAmountInput;
        
        [SerializeField]
        private TMP_InputField targetCurrencyInput;

        [SerializeField]
        private TMP_Text resultText;

        [SerializeField]
        private TMP_Text ipText;

        [SerializeField]
        private Button calculateButton;

        public ExchangeRatesApiClient Client { get; private set; }

        [Inject]
        public void Construct(ExchangeRatesApiClient exchangeRatesApiClient)
        {
            Client = exchangeRatesApiClient;
        }

        private async void Start()
        {
#if RACCOONS_SERIALIZATION_NEWTONSOFTJSON

#else

#endif
            calculateButton.onClick.AddListener(Calculate);
            ipText.text = "IP: "+await Client.GetApiIP();
        }

        private void Calculate()
        {
            double amount = double.Parse(baseAmountInput.text);
            string baseCurrency = baseCurrencyInput.text;
            if (string.IsNullOrEmpty(targetCurrencyInput.text))
            {
                CalculateAll(baseCurrency, amount);
            }
            else
            {
                string targetCurrency = targetCurrencyInput.text;
                Calculate(baseCurrency, amount, targetCurrency);
            }
        }

        private async void Calculate(string baseCurrency, double amount, string targetCurrency)
        {
            var response = await Client.GetPairAmount(baseCurrency, targetCurrency, amount);
            resultText.text = $"{amount} {response.base_code} = {StringifyCurrencyAmount(response.conversion_result)} {response.target_code}";
        }

        private async void CalculateAll(string baseCurrency, double amount)
        {
            try
            {
                var response = await Client.GetLatestRatesFor(baseCurrency);
                StringBuilder resultBuilder = new StringBuilder($"{amount} {baseCurrency} = \n");
                foreach (var rate in response.conversion_rates)
                {
                    resultBuilder.AppendLine($"   = {StringifyCurrencyAmount(rate.Value * amount)} {rate.Key}");
                }
                resultText.text = resultBuilder.ToString();
            }
            catch (WebRequestException ex)
            {
                Debug.LogError($"Failed to get latest rates");
            }
            
        }

        public string StringifyCurrencyAmount(double amount)
        {
            return string.Format("{0:0.00}", amount);
        }
    }
}