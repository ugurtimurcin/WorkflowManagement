using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DataAccess.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetNonAdmin()
        {
            using var context = new WorkflowManagementContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole

                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(a => a.roles.Name == "Member").Select(s=>new AppUser 
                {
                    Id=s.user.Id,
                    FirstName = s.user.FirstName,
                    LastName = s.user.LastName,
                    Picture = s.user.Picture,
                    UserName =  s.user.UserName,
                    Email = s.user.Email
                }).ToList();
        }


        public List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePage = 1)
        {
            using var context = new WorkflowManagementContext();
            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId,
                (resultUser, resultUserRole) => new
                {
                    user = resultUser,
                    userRole = resultUserRole

                }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
                {
                    user = resultTable.user,
                    userRoles = resultTable.userRole,
                    roles = resultRole
                }).Where(a => a.roles.Name == "Member").Select(s => new AppUser
                {
                    Id = s.user.Id,
                    FirstName = s.user.FirstName,
                    LastName = s.user.LastName,
                    Picture = s.user.Picture,
                    UserName = s.user.UserName,
                    Email = s.user.Email
                });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(searchingWord))
            {
                result = result.Where(a => a.FirstName.ToLower().Contains(searchingWord.ToLower()) || a.LastName.ToLower().Contains(searchingWord.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }

        public List<DualHelper> GetMostCompletedJobByEmployee()
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.AppUser).Where(a => a.State).GroupBy(a => a.AppUser.UserName).OrderByDescending(a => a.Count()).Take(5).Select(
                a => new DualHelper
                {
                    Name = a.Key,
                    JobCount = a.Count()
                }).ToList();
        }

        public List<DualHelper> GetMostWorkingEmployee()
        {
            using var context = new WorkflowManagementContext();
            return context.Jobs.Include(a => a.AppUser).Where(a => !a.State && a.AppUserId != null).GroupBy(a => a.AppUser.UserName).OrderByDescending(a => a.Count()).Take(5).Select(
                a => new DualHelper
                {
                    Name = a.Key,
                    JobCount = a.Count()
                }).ToList();
        }
    }
}
