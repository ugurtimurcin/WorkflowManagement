using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.DTO.DTOs.AppUserDTOs;
using WorkflowManagement.DTO.DTOs.JobDTOs;

namespace WorkflowManagement.DTO.DTOs.AssignEmployeeDTOs
{
    public class AssignEmployeeListDTO
    {
        public AppUserListDTO AppUser { get; set; }
        public JobListDTO Job { get; set; }
    }
}
