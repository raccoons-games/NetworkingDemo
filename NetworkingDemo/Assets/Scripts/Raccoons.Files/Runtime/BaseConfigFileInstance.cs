using Raccoons.Networking.Serialization;
using UnityEngine;

namespace Raccoons.Files
{
    public abstract class BaseFileInstance : ScriptableObject, IFileInstance
    {
        public TConfig LoadSerialized<TConfig>(ISerializer serializer)
        {
            return serializer.Deserialize<TConfig>(ReadAll());
        }

        public abstract string ReadAll();
    }
}