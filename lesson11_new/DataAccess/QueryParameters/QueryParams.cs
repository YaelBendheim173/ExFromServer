using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class QueryParams
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;


        private int pageSize = 15;

        public int PageSize
        {
            get { return pageSize; }
            set { if (value > 0 && value < maxPageSize) pageSize = value; }
        }
    }
}
