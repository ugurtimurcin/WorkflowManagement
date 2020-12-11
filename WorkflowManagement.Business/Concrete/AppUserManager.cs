using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public List<DualHelper> GetMostCompletedJobByEmployee()
        {
            return _appUserDal.GetMostCompletedJobByEmployee();
        }

        public List<DualHelper> GetMostWorkingEmployee()
        {
            return _appUserDal.GetMostWorkingEmployee();
        }

        public List<AppUser> GetNonAdmin()
        {
            return _appUserDal.GetNonAdmin();
        }

        public List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePage = 1)
        {
            return _appUserDal.GetNonAdmin(out totalPage, searchingWord, activePage);
        }
    }
}
