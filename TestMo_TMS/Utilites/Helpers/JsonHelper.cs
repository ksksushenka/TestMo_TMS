using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TestMo_TMS.Utilites.Helpers
{
    public class JsonHelper
    {
        public static JObject FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JObject>(json);
        }
    }
}
