using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Clients;
using TestMo_TMS.Models;
using TestMo_TMS.Utilites.Configuration;

namespace TestMo_TMS.Services
{
    public class RunService : BaseService
    {
        public RunService(ApiClient apiClient) : base(apiClient)
        {
        }

        public Run GetRun(int runId)
        {
            var request = new RestRequest(Endpoints.GET_RUN)
                .AddUrlSegment("run_id", runId);

            return _apiClient.Execute<Run>(request);
        }

        public RestResponse AddRun(string name, string source , int projectId)
        {
            var request = new RestRequest(Endpoints.ADD_RUN, Method.Post)
                .AddUrlSegment("project_id", projectId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(name, source);

            return _apiClient.Execute(request);
        }
    }
}
