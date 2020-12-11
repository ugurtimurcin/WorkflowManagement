using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfUrgencyRepository: EfGenericRepository<Urgency, WorkflowManagementContext>, IUrgencyDal 
    {
    }
}
