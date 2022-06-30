using Raccoons.Networking.Serialization;

namespace Raccoons.Files
{
    public interface IFileInstance
    {
        TConfig LoadSerialized<TConfig>(ISerializer serializer);
        string ReadAll();
    }
}