using ExchangeRates.Networking;
using ExchangeRates.Networking.Api;
using Raccoons.Networking.Api.Installers;
using Raccoons.Networking.Api.WebRequests;
using Raccoons.Networking.Api.WebRequests.UnityWebRequests;
using Raccoons.Serialization;
using Raccoons.Serialization.Json;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "NetworkingDemoInstaller", menuName = "Installers/NetworkingDemoInstaller")]
    public class NetworkingDemoInstaller : ScriptableObjectInstaller<NetworkingDemoInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISerializer>().To<NewtonsoftJsonSerializer>().AsSingle();
            Container.Bind<IWebRequestProvider>().To<UnityWebRequestProvider>().AsSingle();
        }
    }
}
