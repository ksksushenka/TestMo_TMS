using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestMo_TMS.Models
{
    public class Run
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("project_id")] public int Project_Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("source")] public string Source { get; set; }

        protected bool Equals(Run other)
        {
            return Id == other.Id && Project_Id == other.Project_Id && Name == other.Name && Source == other.Source;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Run)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Project_Id.GetHashCode() + Name.GetHashCode() + Source.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id = {Id} and Project_Id = {Project_Id} and Name = {Name} and Source = {Source}";
        }
    }
}
