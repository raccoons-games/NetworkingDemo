using System.Collections;
using System.Collections.Generic;
using Raccoons.Networking.Api.Clients;
using Raccoons.Networking.Api.Configs;
using Raccoons.Networking.Api.Configs.Factories;
using Raccoons.Networking.Api.WebRequests;
using Raccoons.Networking.Api.WebRequests.UnityWebRequests;
using Raccoons.Serialization;
using Raccoons.Serialization.Json;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Raccoons.Networking.Tests
{
    public class NetworkingTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public async void WebRequestTestsSimplePasses()
        {
            var response = await new UnityWebRequestBuilder().Get("google.com").Send();
            Assert.IsTrue(response.Code == 200);
        }

        /*public static TClient CreateTestClient<TClient, TWebRequestBuilder, TConfig>
            (string apiConst, System.Func<TConfig, ISerializer, TClient> clientConstructor)
            where TConfig : BaseApiConfig
            where TClient : ApiClient<TConfig>
            where TWebRequestBuilder : IWebRequestBuilder
        {
            ISerializer serializer = new NewtonsoftJsonSerializer();
            FileApiConfigFactory<TConfig> apiConfigFactory = new ApiConfigFactory<TConfig>(apiConst, serializer);
            TConfig apiConfig = apiConfigFactory.Create();
            TClient client = clientConstructor(apiConfig, serializer);
            return client;
        }*/
    }
}