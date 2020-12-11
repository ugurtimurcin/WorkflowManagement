using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Business.Concrete;
using WorkflowManagement.Business.CustomLogger;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using WorkflowManagement.DataAccess.Interfaces;

namespace WorkflowManagement.Business.DependencyInjectionContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IJobService, JobManager>();
            services.AddScoped<IUrgencyService, UrgencyManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<IJobDal, EfJobRepository>();
            services.AddScoped<IUrgencyDal, EfUrgencyRepository>();
            services.AddScoped<IReportDal, EfReportRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<INotificationDal, EfNotificationRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
