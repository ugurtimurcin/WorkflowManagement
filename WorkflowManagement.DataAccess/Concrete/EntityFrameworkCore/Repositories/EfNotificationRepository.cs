using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification, WorkflowManagementContext>, INotificationDal
    {
        public List<Notification> GetUnRead(int appUserId)
        {
            using var context = new WorkflowManagementContext();
            return context.Notifications.Where(a => a.AppUserId == appUserId && !a.State).ToList();
        }

        public int GetUnreadNotificationCountByUserId(int id)
        {
            using var context = new WorkflowManagementContext();
            return context.Notifications.Count(a => a.AppUserId == id && !a.State);
        }
    }
}
