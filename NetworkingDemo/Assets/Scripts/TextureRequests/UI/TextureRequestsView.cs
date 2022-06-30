using Raccoons.Networking.Api.WebRequests;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TextureRequests.UI
{
    public class TextureRequestsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField urlInput;

        [SerializeField]
        private RawImage demoImage;

        public IWebRequestProvider RequestProvider { get; private set; }

        [Inject]
        public void Construct(IWebRequestProvider webRequestProvider)
        {
            RequestProvider = webRequestProvider;
        }

        public async void LoadImage()
        {
            var result = await RequestProvider.Provide().Get(urlInput.text).Send();
            using (result)
            {
                Texture2D texture2D = new Texture2D(0, 0);
                texture2D.LoadImage((result as IByteResponse).GetBytes());
                demoImage.texture = texture2D;
            }
        }

        public void OnApplicationFocus(bool focus)
        {
            if (focus)
            {
                string buffer = GUIUtility.systemCopyBuffer;
                if (buffer.EndsWith(".png") || buffer.EndsWith(".jpg"))
                {
                    if (File.Exists(buffer))
                    {
                        urlInput.text = "file:///"+buffer;
                    }
                    else
                    {
                        urlInput.text = buffer;
                    }
                }
            }
        }
    }
}