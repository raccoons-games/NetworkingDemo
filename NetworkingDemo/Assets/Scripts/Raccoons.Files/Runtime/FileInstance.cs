using Raccoons.Networking.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Raccoons.Files
{
    [CreateAssetMenu(fileName = "FileInstance", menuName = "Raccoons/Files/FileInstance")]
    public class FileInstance : BaseFileInstance
    {
        [SerializeField]
        private string filePath;

        public virtual string FilePath { get => filePath; }

        public override string ReadAll()
        {
            return File.ReadAllText(FilePath);
        }
    }
}