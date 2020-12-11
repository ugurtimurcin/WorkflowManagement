using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Interfaces
{
    public interface IReportDal: IGenericDal<Report>
    {
        Report GetByIdWJob(int id);
        int GetReportCountByUserId(int id);
        int GetReportCount();
    }
}
