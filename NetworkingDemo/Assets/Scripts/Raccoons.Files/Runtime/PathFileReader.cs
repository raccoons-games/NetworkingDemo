using Raccoons.Networking.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Raccoons.Files
{
    [CreateAssetMenu(fileName = "PathFileReader", menuName = "Raccoons/Files/PathFileReader")]
    public class PathFileReader : BaseFileReader
    {
        [SerializeField]
        private string filePath;

        public virtual string FilePath { get => filePath; }

        public override string ReadAll()
        {
            return File.ReadAllText(FilePath);
        }

        public override Task<string> ReadAllAsync(CancellationToken cancellationToken = default)
        {
            return File.ReadAllTextAsync(FilePath, cancellationToken);
        }
    }
}