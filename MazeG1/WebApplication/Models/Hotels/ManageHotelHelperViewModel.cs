using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.DbStuff.Model;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class ManageHotelHelperViewModel
    {
        public long HotelId { get; set; }

        public List<HelperViewModel> Helpers { get; set; }

        public List<long> CheckedUsers { get; set; }
    }
}
