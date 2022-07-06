using Raccoons.Networking.Serialization;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Files
{
    public abstract class BaseFileReader : ScriptableObject, IFileReader
    {
        public TConfig LoadSerialized<TConfig>(ISerializer serializer)
        {
            return serializer.Deserialize<TConfig>(ReadAll());
        }

        public async Task<TConfig> LoadSerializedAsync<TConfig>(ISerializer serializer, CancellationToken cancellationToken = default)
        {
            return serializer.Deserialize<TConfig>(await ReadAllAsync(cancellationToken));
        }

        public abstract string ReadAll();

        public abstract Task<string> ReadAllAsync(CancellationToken cancellationToken = default);
    }
}