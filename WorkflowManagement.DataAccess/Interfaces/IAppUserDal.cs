using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Interfaces
{
    public interface IAppUserDal
    {
        List<AppUser> GetNonAdmin();
        List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePage = 1);
        List<DualHelper> GetMostCompletedJobByEmployee();
        List<DualHelper> GetMostWorkingEmployee();
    }
}
