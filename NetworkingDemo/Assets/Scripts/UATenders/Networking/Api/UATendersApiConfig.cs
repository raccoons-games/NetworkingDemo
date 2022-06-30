using Raccoons.Networking.Api.Configs;
using UnityEngine;

namespace UATenders.Networking.Api
{
    [System.Serializable]
    public class UATendersApiConfig : BaseApiConfig
    {
        [SerializeField]
        private string apiUrl;
        public override string GetApiUrl()
        {
            return apiUrl;
        }
    }
}