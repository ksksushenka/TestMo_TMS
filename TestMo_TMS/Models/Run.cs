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
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("project_id")] public int ProjectId { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("source")] public string Source { get; set; }

        protected bool Equals(Run other)
        {
            return Id == other.Id && ProjectId == other.ProjectId && Name == other.Name && Source == other.Source;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Project)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + ProjectId.GetHashCode() + Name.GetHashCode() + Source.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id = {Id} and ProjectId = {ProjectId} and Name = {Name} and Source = {Source}";
        }
    }
}
