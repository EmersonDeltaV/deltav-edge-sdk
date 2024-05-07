using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerson.EdgeClient.Graph.Models
{
    public class Entity
    {
        public string Id { get; set; }
        public string Path { get; set; }
        public string FullPath { get; set; }
        public Dictionary<string, EntityProperty> P { get; set; }
        public Dictionary<string, List<RelationshipProperties>> R { get; set; }
    }

    public class EntityProperty
    {
        public required string Type { get; set; }
        public required object Value { get; set; }
        public string? History { get; set; }
        public string? Timestamp { get; set; }
    }

    public class RelationshipProperties
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
