using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Files
{
    [CreateAssetMenu(fileName = "PathFileReader", menuName = "Raccoons/Files/TextAssetInstance")]
    public class TextAssetFileReader : BaseFileReader
    {
        [SerializeField]
        private TextAsset textAsset;

        public override string ReadAll()
        {
            return textAsset.text;
        }

        public override Task<string> ReadAllAsync(CancellationToken cancellationToken = default)
        {
            
            return Task.FromResult(ReadAll());
        }
    }
}