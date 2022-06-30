using SocketCubes.Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

namespace SocketCubes.UI
{
    public class SocketCubeUI : MonoBehaviour
    {
        [SerializeField]
        private SocketCube socketCube;

        [SerializeField]
        private TMP_InputField myPort;

        [SerializeField]
        private TMP_InputField targetPort;

        public void SetupClient()
        {
            int port = int.Parse(myPort.text);
            socketCube.RunClient(port);
            targetPort.gameObject.SetActive(true);
        }

        public void SetupTarget()
        {
            string []parts = targetPort.text.Split(':');
            socketCube.ConnectWith(parts[0], int.Parse(parts[1]));
        }
    }
}