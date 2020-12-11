using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Concrete
{
    public class JobManager : IJobService
    {
        private readonly IJobDal _jobDal;
        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }
        public void Create(Job entity)
        {
            _jobDal.Create(entity);
        }

        public void Delete(Job entity)
        {
            _jobDal.Delete(entity);
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetAll();
        }

        public Job GetById(int id)
        {
            return _jobDal.GetById(id);
        }

        public List<Job> GetJobsWithUrgenciesUnCompleted()
        {
            return _jobDal.GetJobsWithUrgenciesUnCompleted();
        }

        public List<Job> GetAllWithTables()
        {
            return _jobDal.GetAllWithTables();
        }

        public void Update(Job entity)
        {
            _jobDal.Update(entity);
        }

        public Job GetByIdWithUrgency(int id)
        {
            return _jobDal.GetByIdWithUrgency(id);
        }

        public List<Job> GetByAppUserId(int appUserId)
        {
            return _jobDal.GetByAppUserId(appUserId);
        }

        public Job GetByIdWReports(int id)
        {
            return _jobDal.GetByIdWReports(id);
        }

        public List<Job> GetAllWithTables(Expression<Func<Job, bool>> filter)
        {
            return _jobDal.GetAllWithTables(filter);
        }

        public List<Job> GetByAllTablesUncompleted(out int totalPage, int userId, int activePage)
        {
            return _jobDal.GetByAllTablesUncompleted(out totalPage, userId, activePage);
        }

        public int GetJobCountCompletedByUserId(int id)
        {
            return _jobDal.GetJobCountCompletedByUserId(id);
        }

        public int GetJobCountUncompletedByUserId(int id)
        {
            return _jobDal.GetJobCountUncompletedByUserId(id);
        }

        public int GetJobToAssignCount()
        {
            return _jobDal.GetJobToAssignCount();
        }

        public int GetCompletedJobCount()
        {
            return _jobDal.GetCompletedJobCount();
        }
    }
}
