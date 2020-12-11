using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Interfaces
{
    public interface IReportService: IGenericService<Report>
    {
        Report GetByIdWJob(int id);
        int GetReportCountByUserId(int id);
        int GetReportCount();
    }
}
