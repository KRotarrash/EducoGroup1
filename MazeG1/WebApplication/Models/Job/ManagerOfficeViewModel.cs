using System.Collections.Generic;
using WebApplication.DbStuff.Model.Job;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Job
{
    public class ManagerOfficeViewModel
    {
        public bool IsAnyAddress { get; set; }
        public virtual List<OfficeViewModel> Offices { get; set; }
    }
}
