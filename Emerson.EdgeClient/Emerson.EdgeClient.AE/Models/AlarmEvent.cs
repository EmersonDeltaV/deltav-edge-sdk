using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerson.EdgeClient.AE.Models
{
    public class AlarmEvent
    {
        public DateTime DateTime { get; set; }
        public string EventType { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
        public string Node { get; set; }
        public string Unit { get; set; }
        public string Module { get; set; }
        public string ModuleDescription { get; set; }
        public string Parameter { get; set; }
        public string State { get; set; }
        public string Level { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }

    }
}
