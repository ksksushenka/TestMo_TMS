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

        public ResultProject GetProject(int id)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("project_id", id);

            return _apiClient.Execute<ResultProject>(request);
        }

        public Project GetInvalidProject(int id)
        {
            var request = new RestRequest(Endpoints.GET_PROJECT)
                .AddUrlSegment("project_id", id);

            return _apiClient.Execute<Project>(request);
        }
    }
}
