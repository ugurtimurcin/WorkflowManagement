using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Concrete
{
    public class UrgencyManager : IUrgencyService
    {
        private readonly IUrgencyDal _urgencyDal;
        public UrgencyManager(IUrgencyDal urgencyDal)
        {
            _urgencyDal = urgencyDal;
        }
        public void Create(Urgency entity)
        {
            _urgencyDal.Create(entity);
        }

        public void Delete(Urgency entity)
        {
            _urgencyDal.Delete(entity);
        }

        public List<Urgency> GetAll()
        {
            return _urgencyDal.GetAll();
        }

        public Urgency GetById(int id)
        {
            return _urgencyDal.GetById(id);
        }

        public void Update(Urgency entity)
        {
            _urgencyDal.Update(entity);
        }
    }
}
