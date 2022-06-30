using Raccoons.Networking.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ExchangeRates.Networking.Api.Tests
{
    public class ExchangeRatesApiClientInjectTest : MonoBehaviour
    {
        public ExchangeRatesApiClient ApiClient { get; private set; }
        public ISerializer Serializer { get; private set; }

        [Inject]
        public void Construct(ISerializer serializer, ExchangeRatesApiClient client)
        {
            Serializer = serializer;
            ApiClient = client;
        }

        private void Start()
        {
            Debug.Log($"[{nameof(ExchangeRatesApiClientInjectTest)}] Client injection test - \n{Serializer.Serialize(ApiClient)}");
        }
    }
}