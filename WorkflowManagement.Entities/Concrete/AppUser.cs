using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Interfaces;

namespace WorkflowManagement.Entities.Concrete
{
    public class AppUser: IdentityUser<int>, ITable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }

        public List<Notification>  Notifications { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
