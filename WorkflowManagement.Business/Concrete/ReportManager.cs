using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public void Create(Report entity)
        {
            _reportDal.Create(entity);
        }

        public void Delete(Report entity)
        {
            _reportDal.Delete(entity);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public Report GetById(int id)
        {
            return _reportDal.GetById(id);
        }

        public Report GetByIdWJob(int id)
        {
            return _reportDal.GetByIdWJob(id);
        }

        public int GetReportCount()
        {
            return _reportDal.GetReportCount();
        }

        public int GetReportCountByUserId(int id)
        {
            return _reportDal.GetReportCountByUserId(id);
        }

        public void Update(Report entity)
        {
            _reportDal.Update(entity);
        }
    }
}
