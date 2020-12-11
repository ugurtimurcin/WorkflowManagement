using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        public void Create(Notification entity)
        {
            _notificationDal.Create(entity);
        }

        public void Delete(Notification entity)
        {
            _notificationDal.Delete(entity);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetById(int id)
        {
            return _notificationDal.GetById(id);
        }

        public List<Notification> GetUnRead(int appUserId)
        {
            return _notificationDal.GetUnRead(appUserId);
        }

        public int GetUnreadNotificationCountByUserId(int id)
        {
            return _notificationDal.GetUnreadNotificationCountByUserId(id);
        }

        public void Update(Notification entity)
        {
            _notificationDal.Update(entity);
        }
    }
}
