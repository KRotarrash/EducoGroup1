using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.DbStuff.Model
{
    public class Marriage : BaseModel
    {
        [Required]
        public virtual SpecialUser Husband { get; set; }

        [Required]
        public virtual SpecialUser Wife { get; set; }

        [Required]
        public virtual DateTime DateStartMarriage { get; set; }

        public virtual DateTime? DateFinishMarriage { get; set; }
    }
}
