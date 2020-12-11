using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Interfaces;

namespace WorkflowManagement.Entities.Concrete
{
    public class Job: ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool State { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;

        public int UrgencyId { get; set; }
        public Urgency Urgency { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<Report> Reports { get; set; }
    }
}
