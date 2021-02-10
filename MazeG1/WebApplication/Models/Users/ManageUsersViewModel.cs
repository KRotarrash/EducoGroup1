using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class ManageUsersViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public SpecialUser CurrentUser { get; set; }
        public PaginatorInfoViewModel PaginatorInfo { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
