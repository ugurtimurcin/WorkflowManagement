using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.DTO.DTOs.JobDTOs;
using WorkflowManagement.DTO.DTOs.NotificationDTOs;
using WorkflowManagement.DTO.DTOs.ReportDTOs;
using WorkflowManagement.DTO.DTOs.UrgencyDTOs;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.Mapping.AutoMapperProfile
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            #region AppUser-AppUserDTO
            CreateMap<AppUserListDTO, AppUser>();
            CreateMap<AppUser, AppUserListDTO>();
            CreateMap<AppUserLoginDTO, AppUser>();
            CreateMap<AppUser, AppUserLoginDTO>();
            CreateMap<AppUserRegisterDTO, AppUser>();
            CreateMap<AppUser, AppUserRegisterDTO>();
            #endregion

            #region Notification-NotificationDTO
            CreateMap<NotificationListDTO, Notification>();
            CreateMap<Notification, NotificationListDTO>();
            #endregion

            #region Job-JobDTO
            CreateMap<JobAddDTO, Job>();
            CreateMap<Job, JobAddDTO>();
            CreateMap<JobEditDTO, Job>();
            CreateMap<Job, JobEditDTO>();
            CreateMap<JobListAllDTO, Job>();
            CreateMap<Job, JobListAllDTO>();
            CreateMap<JobListDTO, Job>();
            CreateMap<Job, JobListDTO>();
            #endregion

            #region Report-ReportDTO
            CreateMap<ReportAddDTO, Report>();
            CreateMap<Report, ReportAddDTO>();
            CreateMap<ReportEditDTO, Report>();
            CreateMap<Report, ReportEditDTO>();
            #endregion

            #region Urgency-UrgencyDTO
            CreateMap<UrgencyAddDTO, Urgency>();
            CreateMap<Urgency, UrgencyAddDTO>();
            CreateMap<UrgencyEditDTO, Urgency>();
            CreateMap<Urgency, UrgencyEditDTO>();
            CreateMap<UrgencyListDTO, Urgency>();
            CreateMap<Urgency, UrgencyListDTO>();
            #endregion
        }
    }
}
