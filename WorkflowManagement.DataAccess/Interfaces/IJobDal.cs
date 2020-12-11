using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Interfaces
{
    public interface IJobDal: IGenericDal<Job>
    {
        List<Job> GetJobsWithUrgenciesUnCompleted();
        List<Job> GetAllWithTables();
        List<Job> GetAllWithTables(Expression<Func<Job, bool>> filter);
        List<Job> GetByAllTablesUncompleted(out int totalPage, int userId, int activePage);
        Job GetByIdWithUrgency(int id);
        List<Job> GetByAppUserId(int appUserId);
        Job GetByIdWReports(int id);
        int GetJobCountCompletedByUserId(int id);
        int GetJobCountUncompletedByUserId(int id);
        int GetJobToAssignCount();
        int GetCompletedJobCount();
    }
}
