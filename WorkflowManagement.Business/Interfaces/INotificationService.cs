using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Interfaces
{
    public interface INotificationService: IGenericService<Notification>
    {
        List<Notification> GetUnRead(int appUserId);
        int GetUnreadNotificationCountByUserId(int id);
    }
}
