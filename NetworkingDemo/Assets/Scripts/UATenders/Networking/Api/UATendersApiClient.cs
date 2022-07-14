using Raccoons.Networking.Api.Clients;
using Raccoons.Networking.Api.WebRequests;
using Raccoons.Serialization;
using System.Threading.Tasks;

namespace UATenders.Networking.Api
{

    public class UATendersApiClient : ApiClient<UATendersApiConfig>
    {
        public const string TENDERS = "/tenders";

        public UATendersApiClient(UATendersApiConfig apiConfig, ISerializer serializer, IWebRequestProvider webRequestProvider) 
            : base(apiConfig, serializer, webRequestProvider)
        {
        }

        public async Task<string> GetListOfTendersJson()
        {
            IWebRequestBuilder unityWebRequestBuilder = Get(BuildUrl(TENDERS));
            var result = await unityWebRequestBuilder.Send();
            return (result as ITextResponse).GetText();
        }
    }
}