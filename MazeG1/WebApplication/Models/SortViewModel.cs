using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class SortViewModel
    {
        public SortColumn SortColumn { get; set; }
        public SortDirection SortDirection { get; set; }

        public SortViewModel() { }

        public SortViewModel(SortColumn sortColumn, SortDirection sortDirection)
        {
            SortColumn = sortColumn;
            SortDirection = sortDirection;
        }

        public SortDirection colDirection(SortColumn column)
        {
            return column == SortColumn && SortDirection == SortDirection.ASC
                    ? SortDirection.DESC
                    : SortDirection.ASC;
        }
    }
}
