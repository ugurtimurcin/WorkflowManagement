using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using WorkflowManagement.Business.ValidationRules.FluentValidation;
using WorkflowManagement.DataAccess.Concrete.EntityFrameworkCore.Context;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.DTO.DTOs.JobDTOs;
using WorkflowManagement.DTO.DTOs.ReportDTOs;
using WorkflowManagement.DTO.DTOs.UrgencyDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;

            })
                .AddEntityFrameworkStores<WorkflowManagementContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "WorkflowManagementCookie";
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(15);
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = "/Home/Index";
                opt.AccessDeniedPath = "/Home/AccessDenied";
            });
        }

        public static void AddValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AppUserLoginDTO>, AppUserLoginValidator>();
            services.AddTransient<IValidator<AppUserRegisterDTO>, AppUserRegisterValidator>();
            services.AddTransient<IValidator<JobAddDTO>, JobAddValidator>();
            services.AddTransient<IValidator<JobEditDTO>, JobEditValidator>();
            services.AddTransient<IValidator<ReportAddDTO>, ReportAddValidator>();
            services.AddTransient<IValidator<ReportEditDTO>, ReportEditValidator>();
            services.AddTransient<IValidator<UrgencyAddDTO>, UrgencyAddValidator>();
            services.AddTransient<IValidator<UrgencyEditDTO>, UrgencyEditValidator>();
        }
    }
}
