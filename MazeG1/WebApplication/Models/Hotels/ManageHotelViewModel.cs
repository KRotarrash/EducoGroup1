using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.DbStuff.Model;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class ManageHotelViewModel
    {
        public List<HotelViewModel> Hotels { get; set; }

        public PaginatorInfoViewModel PaginatorInfo { get; set; }

        public SortViewModel SortViewModel { get; set; }
    }
}
