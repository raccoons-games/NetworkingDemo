using Raccoons.Networking.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Raccoons.Files
{
    public interface IFileReader
    {
        TConfig LoadSerialized<TConfig>(ISerializer serializer);
        Task<TConfig> LoadSerializedAsync<TConfig>(ISerializer serializer, CancellationToken cancellationToken = default);
        
        string ReadAll();
        Task<string> ReadAllAsync(CancellationToken cancellationToken = default);
    }
}