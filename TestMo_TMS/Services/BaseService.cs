using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMo_TMS.Clients;

namespace TestMo_TMS.Services
{
    public class BaseService
    {
        protected ApiClient _apiClient;

        public BaseService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}