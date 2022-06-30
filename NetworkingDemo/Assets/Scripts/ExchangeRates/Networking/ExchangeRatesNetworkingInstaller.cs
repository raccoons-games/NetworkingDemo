using ExchangeRates.Networking.Api;
using Raccoons.Networking.Api.Installers;
using Raccoons.Networking.Api.WebRequests.UnityWebRequests;
using UnityEngine;

namespace ExchangeRates.Networking
{
    [CreateAssetMenu(fileName = "ExchangeRatesNetworkingInstaller", menuName = "ExchangeRates/Networking/Installer")]
    public class ExchangeRatesNetworkingInstaller :
        NetworkApiInstaller<ExchangeRatesApiClient, ExchangeRatesApiConfig>
    {
    }
}