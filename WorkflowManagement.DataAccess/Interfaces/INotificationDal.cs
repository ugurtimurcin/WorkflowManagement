using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Interfaces
{
    public interface INotificationDal: IGenericDal<Notification> 
    {
        List<Notification> GetUnRead(int appUserId);
        int GetUnreadNotificationCountByUserId(int id);
    }
}
