using Raccoons.Files;
using Raccoons.Networking.Api.Clients;
using Raccoons.Networking.Api.Configs;
using Raccoons.Networking.Api.Configs.Factories;
using Raccoons.Networking.Api.WebRequests;
using Raccoons.Networking.Runtime.Api;
using System.IO;
using UnityEngine;
using Zenject;

namespace Raccoons.Networking.Api.Installers
{
    public abstract class NetworkApiInstaller<TApiClient, TApiConfig> : ScriptableObjectInstaller
        where TApiConfig : BaseApiConfig
        where TApiClient : ApiClient<TApiConfig>
    {

        [SerializeField]
        private BaseFileInstance configFile;
        public override void InstallBindings()
        {
            Container.Bind<TApiClient>().FromSubContainerResolve().ByMethod(BindApiClient).AsSingle();
        }

        private void BindApiClient(DiContainer apiContainer)
        {
            apiContainer.BindInstance(configFile);
            apiContainer.Bind<TApiConfig>()
                .FromIFactory(
                    x => x.To<FileApiConfigFactory<TApiConfig>>().AsSingle())
                .AsSingle().NonLazy();
            apiContainer.Bind<TApiClient>().AsSingle();
        }
    }
}
