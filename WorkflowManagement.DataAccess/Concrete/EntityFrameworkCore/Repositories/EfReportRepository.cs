using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report, WorkflowManagementContext>, IReportDal
    {
        public Report GetByIdWJob(int id)
        {
            using var context = new WorkflowManagementContext();
            return context.Reports.Include(a => a.Job).ThenInclude(s=>s.Urgency).Where(a => a.Id == id).FirstOrDefault();
        }

        public int GetReportCount()
        {
            using var context = new WorkflowManagementContext();
            return context.Reports.Count();
        }

        public int GetReportCountByUserId(int id)
        {
            using var context = new WorkflowManagementContext();
            var result = context.Jobs.Include(a => a.Reports).Where(a => a.AppUserId == id);
            return result.SelectMany(a => a.Reports).Count();
        }
    }
}
