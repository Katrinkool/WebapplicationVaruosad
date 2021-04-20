using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationVaruosad
{
    public class SearchParams
    {
        const int maxPageSize = 250;
        private int pageSize = 30;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = Math.Min(value, maxPageSize); //value >maxPageSize) ? maxPageSize : value
            }
        }

    }
}
