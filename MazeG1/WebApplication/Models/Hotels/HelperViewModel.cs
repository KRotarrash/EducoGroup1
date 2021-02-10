using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.DbStuff.Model;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class HelperViewModel
    {
        public bool IsHelper { get; set; }

        public UserViewModel Helper { get; set; }

        public long HotelId { get; set; }
    }
}
