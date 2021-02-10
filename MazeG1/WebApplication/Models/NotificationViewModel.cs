using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.Models
{
    public class NotificationViewModel
    {
        public long Id { get; set; }

        public long UserId { get; set; }

        public TypeNotification Type { get; set; }

        public StatusNotification Status { get; set; }

        public string Content { get; set; }

        public long RequestSenderId { get; set; }

        public string RequestSenderName { get; set; }

        public List<UserShortViewModel> Users { get; set; }
    }
}
