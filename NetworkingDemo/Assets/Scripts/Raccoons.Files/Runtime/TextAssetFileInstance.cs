using UnityEngine;

namespace Raccoons.Files
{
    [CreateAssetMenu(fileName = "FileInstance", menuName = "Raccoons/Files/TextAssetInstance")]
    public class TextAssetFileInstance : BaseFileInstance
    {
        [SerializeField]
        private TextAsset textAsset;

        public override string ReadAll()
        {
            return textAsset.text;
        }
    }
}