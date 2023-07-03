using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using TestMo_TMS.Clients;
using TestMo_TMS.Models;
using TestMo_TMS.Utilites.Configuration;
using TestMo_TMS.Utilites.Helpers;

namespace TestMo_TMS.Services
{
    public class ProjectService : BaseService
    {
        public ProjectService(ApiClient apiClient) : base(apiClient)
        {
        }

        public Project GetProject(int projectId)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("project_id", projectId);

            var response = _apiClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseData = JObject.Parse(response.Content);
                return responseData["TestData"].ToObject<Project>();
            }

            return null;
        }
    }
}
