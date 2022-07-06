using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Raccoons.Files
{
    [CreateAssetMenu(fileName = "StreamingAssetsFileReader", menuName = "Raccoons/Files/StreamingAssetsFileReader")]
    public class StreamingAssetsFileReader : PathFileReader
    {
        public override string FilePath => Path.Combine(Application.streamingAssetsPath, base.FilePath);

        public override string ReadAll()
        {
            Task<string> task = ReadAllAsync();
            task.Wait();
            return task.Result;
        }

        public override Task<string> ReadAllAsync(CancellationToken cancellationToken = default)
        {
            UnityWebRequest unityWebRequest = UnityWebRequest.Get($"file:///{FilePath}");
            var requestAsync = unityWebRequest.SendWebRequest();
            TaskCompletionSource<string> tsc = new();
            if (unityWebRequest.isDone)
            {
                tsc.TrySetResult(requestAsync.webRequest.downloadHandler.text);
            }
            else
            {
                requestAsync.completed += asyncOp =>
                {
                    tsc.TrySetResult(requestAsync.webRequest.downloadHandler.text);
                    requestAsync.webRequest.Dispose();
                };
            }
            return tsc.Task;
        }
    }
}