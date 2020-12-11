using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DTO.DTOs.JobDTOs
{
    public class JobListDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
    }
}
