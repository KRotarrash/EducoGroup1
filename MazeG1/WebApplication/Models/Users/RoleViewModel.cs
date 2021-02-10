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
    public class RoleViewModel
    {
        public long OwnerId { get; set; }
        public string UserName { get; set; }

        [Required]
        [DisplayName("Роль")]
        public int RoleId { get; set; }

        
    }
}
