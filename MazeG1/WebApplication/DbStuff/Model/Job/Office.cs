using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.DbStuff.Model.Job
{
    public class Office : BaseModel
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual Adress Adress { get; set; }
        public virtual List<Position> Positions { get; set; }
        public virtual OfficeType OfficeType { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
