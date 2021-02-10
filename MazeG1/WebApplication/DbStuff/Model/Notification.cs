using System.ComponentModel.DataAnnotations;

namespace WebApplication.DbStuff.Model
{
    public class Notification : BaseModel
    {
        [Required]
        public virtual SpecialUser User { get; set; }

        [Required]
        public virtual TypeNotification Type { get; set; }

        [Required]
        public virtual StatusNotification Status { get; set; }

        [Required]
        public virtual string Content { get; set; }

        public virtual SpecialUser RequestSender { get; set; }
    }
}
