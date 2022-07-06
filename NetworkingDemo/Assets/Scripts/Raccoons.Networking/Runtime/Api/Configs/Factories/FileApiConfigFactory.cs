using Raccoons.Files;
using Raccoons.Networking.Serialization;

namespace Raccoons.Networking.Api.Configs.Factories
{
    public class FileApiConfigFactory<TConfig> : BaseApiConfigFactory<TConfig>
        where TConfig : BaseApiConfig
    {
        private readonly BaseFileReader _baseFileInstance;
        private readonly ISerializer _serializer;

        public FileApiConfigFactory(BaseFileReader baseFileInstance, ISerializer serializer)
        {
            _baseFileInstance = baseFileInstance;
            _serializer = serializer;
        }

        public override TConfig Create()
        {
            return _baseFileInstance.LoadSerialized<TConfig>(_serializer);
        }
    }
}
