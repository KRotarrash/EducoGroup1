using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication.Models.CustomAttribute;

namespace WebApplication.Models
{
    public class UserShortViewModel
    {
        public long Id { get; set; }

        public string UserName { get; set; }
    }
}
