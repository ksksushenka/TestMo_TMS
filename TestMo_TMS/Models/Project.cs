using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestMo_TMS.Models
{
    public class Project : IComparable<Project>
    {
        public Project()
        {
        }

        public Project(string? name, string? summary)
        {
            Name = name;
            Note = summary;
        }

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("note")] public string Note { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("message")] public string? Message { get; set; }

        protected bool Equals(Project other)
        {
            return Name == other.Name && Note == other.Note && Id == other.Id && Message == other.Message;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Project)obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Note.GetHashCode() + Id.GetHashCode() + Message.GetHashCode();
        }

        public override string ToString()
        {
            return $"Id = {Id} and Name = {Name} and Note = {Note} and Message = {Message}";
        }

        public int CompareTo(Project other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return this.ToString().CompareTo(other.ToString());
        }
    }
}
