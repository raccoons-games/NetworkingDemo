using Raccoons.Networking.Serialization;
using Raccoons.Serialization.Runtime.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using Zenject;

namespace SocketCubes.Networking
{
    public class SocketCubeNetData
    {
        public Vector3 position;
    }

    public class SocketCube : MonoBehaviour
    {
        private UdpClient _udpClient;

        private SocketCubeNetData _netData = new SocketCubeNetData();
        private bool _netDataChanged = false;
        private object _netDataLock = new object();

        private Thread _listeningThread;

        private bool _isConnected = false;

        public ISerializer Serializer { get; private set; }

        private static Socket ConnectSocket(string server, int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            // Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
            foreach (IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket =
                    new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }

        [Inject]
        public void Construct(ISerializer serializer)
        {
            Serializer =  new JsonUtilitySerializer();
        }

        public void RunClient(int port)
        {
            _udpClient = new UdpClient(port);
            _listeningThread = new Thread(ClientListening);
            _listeningThread.Start();
        }
        

        public async void ClientListening()
        {
            while (true)
            {
                var result = await _udpClient.ReceiveAsync();
                string json = Encoding.UTF8.GetString(result.Buffer);
                lock (_netDataLock)
                {
                    _netData = Serializer.Deserialize<SocketCubeNetData>(json);
                    _netDataChanged = true;
                }
            }
        }
        
        public void ConnectWith(string host, int port)
        {
            _udpClient.Connect(host, port);
            _isConnected = true;
        }

        private void Update()
        {
            lock (_netDataLock)
            {
                if (_netDataChanged)
                {
                    ApplyNetData();
                }
                else
                {
                    if (_isConnected)
                    {
                        UpdateNetData();
                        SendNetData();
                    }
                }
            }
        }

        private void UpdateNetData()
        {
            lock (_netDataLock)
            {
                _netData.position = transform.position;
            }
        }

        private void SendNetData()
        {
            string json;
            lock (_netDataLock)
            {
                json = Serializer.Serialize(_netData);
            }
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            _udpClient.Send(bytes, bytes.Length);
        }

        private void ApplyNetData()
        {
            lock (_netDataLock)
            {
                transform.position = _netData.position;
                _netDataChanged = false;
            }
        }

        private void OnDestroy()
        {
            _listeningThread?.Abort();
            _udpClient?.Close();
        }
    }
}