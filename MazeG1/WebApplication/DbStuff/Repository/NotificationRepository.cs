using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(WebContext webContext) : base(webContext) { }

        public IQueryable<Notification> GetNotificationsForUser(long userId, bool isNew)
        {
            return _dbSet
                .Where(x => x.User.Id == userId && (isNew ? x.Status == StatusNotification.Unread : x.Status != StatusNotification.Unread));
        }
    }
}
