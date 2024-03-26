using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Emerson.EdgeClient.AE.Models
{
    /// <summary>
    /// Response for Alarms and Events REST API Request
    /// </summary>
    public class AeResponse
    {
        /// <summary>
        /// Alarms and Events data returned from REST API query
        /// </summary>
        public IEnumerable<AlarmEvent> AlarmsAndEvents { get; set; }

        /// <summary>
        /// Contains paging information. Default page size is 100.
        /// </summary>
        public AePaging Paging { get; set; }

        #region Accessor Properties -- PAGING
        /// <summary>
        /// Current page number
        /// </summary>
        public int CurrentPageNumber { get
            {
                return Paging != null ? Paging.CurrentPageNumber : 1;
            } 
        }

        /// <summary>
        /// Complete URL to move to the next page.
        /// </summary>
        public string NextPageLink { get
            {
                if (Paging != null)
                    return Paging.NextPageLink;
                return string.Empty;
            }
        }

        /// <summary>
        /// Complete URL to move to the previous page.
        /// </summary>
        public string PreviousPageLink
        {
            get
            {
                if (Paging != null)
                    return Paging.PreviousPageLink;
                return string.Empty;
            }
        }
        #endregion
    }

    /// <summary>
    /// Paging response for Alarms and Events REST API Request
    /// </summary>
    public class AePaging
    {
        /// <summary>
        /// Contains the Next page link or the Previous page link, if any.
        /// </summary>
        public IEnumerable<AePageLinks> Links { get; set; }

        /// <summary>
        /// Contains the paging info; i.e., current page number
        /// </summary>
        public AePageInfo Info { get; set; }


        /// <summary>
        /// Current page number
        /// </summary>
        public int CurrentPageNumber
        {
            get
            {
                return Info != null ? Info.CurrentPageNumber : 1;
            }
        }

        /// <summary>
        /// Complete URL to move to the next page.
        /// </summary>
        public string NextPageLink
        {
            get
            {
                if (Links != null)
                    return Links.First(p => p.Name == "next").EndPoint;
                return string.Empty;
            }
        }

        /// <summary>
        /// Complete URL to move to the previous page.
        /// </summary>
        public string PreviousPageLink
        {
            get
            {
                if (Links != null)
                    return Links.First(p => p.Name == "prev").EndPoint;
                return string.Empty;
            }
        }

        public bool HasNextPage
        {
            get => Links.Any(p => p.Name == "next"); 
        }

        public bool HasPreviousPage
        {
            get => Links.Any(p => p.Name == "prev");
        }
    }

    /// <summary>
    /// Paging Links response for Alarms and Events REST API Request
    /// </summary>
    public class AePageLinks
    {
        /// <summary>
        /// Name of the link: either Next or Prev (Previous)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Complete link to another page (baseaddress/api/version/ae?params)
        /// </summary>
        public string EndPoint { get; set; }
    }

    /// <summary>
    /// Paging Info response for Alarms and Events REST API Request
    /// </summary>
    public class AePageInfo
    {
        /// <summary>
        /// Current page number
        /// </summary>
        public int CurrentPageNumber { get; set; }
    }
}
