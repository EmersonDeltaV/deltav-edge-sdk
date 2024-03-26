using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerson.EdgeClient.AE.Services
{
    /// <summary>
    /// REST API Query Filter for AE Endpoint
    /// </summary>
    public class AeFilterBuilder
    {
        private Queue<string> filters = new Queue<string>();
        public AeFilterBuilder Node(string node)
        {
            filters.Enqueue($"Node={node}");
            return this;
        }
        public AeFilterBuilder Area(string area)
        {
            filters.Enqueue($"Area={area}");
            return this;
        }
        public AeFilterBuilder Parameter(string area)
        {
            filters.Enqueue($"Parameter={area}");
            return this;
        }
        public AeFilterBuilder PageSize(int pageSize)
        {
            filters.Enqueue($"PS={pageSize}");
            return this;
        }
        public AeFilterBuilder PageNumber(int pageNum)
        {
            filters.Enqueue($"PN={pageNum}");
            return this;
        }

        /// <summary>
        /// Build the parameters e.g. ?Node=node1&Area=Area_A&Parameter=SPEED -- append this to the api endpoint.
        /// </summary>
        /// <param name="paramPrefix">prefix character for the parameter. Defaults to '?'</param>
        /// <returns></returns>
        public string BuildFilter(string paramPrefix = "?")
        {
            if (filters.Count == 0)
                return string.Empty;

            var sb = new StringBuilder(paramPrefix);
            sb.Append(filters.Dequeue());

            while (filters.TryDequeue(out var filter))
            {
                sb.Append($"&{filter}");
            }

            return sb.ToString();
        }
    }
}
