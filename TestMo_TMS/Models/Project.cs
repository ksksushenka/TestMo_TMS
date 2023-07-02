﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Summary = summary;
        }

        public string? Name { get; set; } = string.Empty;
        public string? Summary { get; set; } = string.Empty;

        protected bool Equals(Project other)
        {
            return Name == other.Name && Summary == other.Summary;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Project)obj);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Summary.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name = {Name} and Summary = {Summary}";
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
