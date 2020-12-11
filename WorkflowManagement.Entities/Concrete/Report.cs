using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Interfaces;

namespace WorkflowManagement.Entities.Concrete
{
    public class Report: ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
