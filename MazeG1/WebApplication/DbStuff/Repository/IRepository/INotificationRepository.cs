using System.Collections.Generic;
using System.Linq;
using WebApplication.DbStuff.Model;

namespace WebApplication.DbStuff.Repository
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        IQueryable<Notification> GetNotificationsForUser(long userId, bool isNew);
    }
}