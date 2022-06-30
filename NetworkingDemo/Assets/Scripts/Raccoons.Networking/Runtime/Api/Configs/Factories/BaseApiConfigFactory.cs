using System.IO;
using Zenject;

namespace Raccoons.Networking.Api.Configs.Factories
{
    public abstract class BaseApiConfigFactory<TConfig> : IFactory<TConfig>
    {
        public abstract TConfig Create();
    }
}