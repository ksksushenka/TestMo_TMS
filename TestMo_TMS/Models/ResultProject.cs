using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMo_TMS.Models
{
    public class ResultProject
    {
        [JsonProperty("result")] public Project Result { get; set; }

        protected bool Equals(ResultProject other)
        {
            return Result == other.Result;
        }

        public override bool Equals(object? obj)
        {
            return Equals((ResultProject)obj);
        }

        public override int GetHashCode()
        {
            return Result.GetHashCode();
        }

        public override string ToString()
        {
            return $"Result = {Result}";
        }
    }
}
