using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using TestMo_TMS.Models;
using System.Text.Json;

namespace TestMo_TMS.Utilites.Helpers
{
    public class TestDataHelper
    {
        public static Project GetTestProject(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            JObject jsonObject = JObject.Parse(json);

            Project project = new Project
            {
                Id = (int)jsonObject["id"],
                Name = (string)jsonObject["name"],
                Summary = (string?)jsonObject["note"]
            };

            return project;
        }

        public static Run GetTestRun(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            JObject jsonObject = JObject.Parse(json);

            Run run = new Run
            {
                Id = (int)jsonObject["id"],
                ProjectId = (int)jsonObject["project_id"],
                Name = (string)jsonObject["name"]
            };

            return run;
        }

        public static Run AddTestRun(string FileName)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData"
                                        + Path.DirectorySeparatorChar + FileName);
            return JsonHelper.FromJson(json).ToObject<Run>();
        }
    }
}
