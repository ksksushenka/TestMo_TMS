using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMo_TMS.Utilites.Configuration
{
    public class Endpoints
    {
        public static readonly string GET_PROJECT = "api/v1/projects/{project_id}";
        public static readonly string GET_RUN = "api/v1/runs/{run_id}";
        public static readonly string ADD_RUN = "api/v1/projects/{project_id}/automation/runs";
    }
}
