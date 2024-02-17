using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmTask.Common.Dtos
{
    [Serializable]
    public class SearchCriteria
    {
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The number of page to be retrieved.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// The property name to sort with
        /// </summary>
        public string Sort { get; set; } = "";
        public bool Descending { get; set; }
        public SearchCriteria()
        {
            PageSize = 10;
            PageNumber = 1;
        }
    }
}
