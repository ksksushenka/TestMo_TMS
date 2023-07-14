using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TestMo_TMS.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace TestMo_TMS.Utilites.Helpers
{
    public class TestDataHelper
    {
        public static Project GetProjectRequest(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Project>();
        }

        public static ResultProject GetProjectResponse(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<ResultProject>();
        }

        public static Project GetInvalidProjectResponse(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Project>();
        }

        public static Run GetRunRequest(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Run>();
        }

        public static ResultRun GetRunResponse(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<ResultRun>();
        }

        public static Run AddTestRun(string FileName)
        {
            return JsonHelper.FromJson(FileName).ToObject<Run>();
        }
    }
}
