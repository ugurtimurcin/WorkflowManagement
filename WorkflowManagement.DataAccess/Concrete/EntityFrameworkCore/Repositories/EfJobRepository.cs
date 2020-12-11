using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfJobRepository : EfGenericRepository<Job, WorkflowManagementContext>, IJobDal
    {
        public List<Job> GetJobsWithUrgenciesUnCompleted()
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.Urgency).Where(a => !a.State).OrderByDescending(s => s.Time).ToList();
        }

        public List<Job> GetAllWithTables()
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.Urgency).Include(a=>a.Reports).Include(s=>s.AppUser).Where(a => !a.State).OrderByDescending(s => s.Time).ToList();
        }

        public Job GetByIdWithUrgency(int id)
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.Urgency).FirstOrDefault(a => !a.State && a.Id == id);
        }

        public Job GetByIdWReports(int id)
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.Reports).Include(i=>i.AppUser).Where(a => a.Id == id).FirstOrDefault();
        }

        public List<Job> GetByAppUserId(int appUserId)
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Where(i => i.AppUserId == appUserId).ToList();
        }

        public List<Job> GetAllWithTables(Expression<Func<Job, bool>> filter)
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.Urgency).Include(a => a.Reports).Include(s => s.AppUser).Where(filter).OrderByDescending(s => s.Time).ToList();
        }

        public List<Job> GetByAllTablesUncompleted(out int totalPage, int userId, int activePage = 1)
        {
            using var context = new WorkflowManagementContext();
            var result = context.Jobs.Include(a => a.Urgency).Include(a => a.Reports).Include(a => a.AppUser).Where(s => s.AppUserId == userId && s.State)
                .OrderByDescending(s => s.Time);

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            return result.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public int GetJobCountCompletedByUserId(int id)
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Count(a => a.AppUserId == id && a.State);
        }

        public int GetJobCountUncompletedByUserId(int id)
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Count(a => a.AppUserId == id && !a.State);
        }

        public int GetJobToAssignCount()
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Count(a => a.AppUserId == null && !a.State);
        }

        public int GetCompletedJobCount()
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Count(a => a.State);
        }
    }
}
