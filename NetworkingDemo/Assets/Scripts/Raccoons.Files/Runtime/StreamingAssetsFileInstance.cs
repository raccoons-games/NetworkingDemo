using System.IO;
using UnityEngine;

namespace Raccoons.Files
{
    [CreateAssetMenu(fileName = "StreamingAssetsFileInstance", menuName = "Raccoons/Files/StreamingAssetsFileInstance")]
    public class StreamingAssetsFileInstance : FileInstance
    {
        public override string FilePath => Path.Combine(Application.streamingAssetsPath, base.FilePath);
    }
}