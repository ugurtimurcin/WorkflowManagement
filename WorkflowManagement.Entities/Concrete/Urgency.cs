using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Interfaces;

namespace WorkflowManagement.Entities.Concrete
{
    public class Urgency: ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Job> Jobs { get; set; }

    }
}
