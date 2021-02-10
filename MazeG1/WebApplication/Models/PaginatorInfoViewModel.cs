using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class PaginatorInfoViewModel
    {
        public int TotalRecordCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }        
        public List<int> PageSizeOptions
        {
            get
            {
                return new List<int>() { 2, 5, 10 };
            }
        }
        public int TotalPageCount
        {
            get
            {
                return TotalRecordCount % PageSize == 0
                    ? TotalRecordCount / PageSize
                    : TotalRecordCount / PageSize + 1;
            }
        }
        public int From
        {
            get
            {
                return Page * PageSize + 1;
            }
        }
        public int To
        {
            get
            {
                var to = (Page + 1) * PageSize;
                return TotalRecordCount < to
                    ? TotalRecordCount
                    : to;
            }
        }

        public SortColumn SortColumn { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
