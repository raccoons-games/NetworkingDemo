using Raccoons.Files;
using Raccoons.Files.Instances;
using Raccoons.Serialization;

namespace Raccoons.Networking.Api.Configs.Factories
{
    public class FileApiConfigFactory<TConfig> : BaseApiConfigFactory<TConfig>
        where TConfig : BaseApiConfig
    {
        private readonly BaseFileAsset _baseFileInstance;
        private readonly ISerializer _serializer;

        public FileApiConfigFactory(BaseFileAsset baseFileInstance, ISerializer serializer)
        {
            _baseFileInstance = baseFileInstance;
            _serializer = serializer;
        }

        public override TConfig Create()
        {
            return _serializer.Deserialize<TConfig>(_baseFileInstance.ReadAllText());
        }
    }
}
