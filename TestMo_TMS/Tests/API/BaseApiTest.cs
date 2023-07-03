using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Clients;
using TestMo_TMS.Services;

namespace TestMo_TMS.Tests.API
{
    public class BaseApiTest
    {
        protected ApiClient _apiClient;
        protected ProjectService _projectService;
        protected RunService _runService;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
            _projectService = new ProjectService(_apiClient);
            _runService = new RunService(_apiClient);
        }
    }
}
