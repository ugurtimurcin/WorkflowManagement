using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowManagement.Business.Interfaces;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.WebUI.TagHelpers
{
    [HtmlTargetElement("getJobByAppUserId")]
    public class JobAppUserIdTagHelper:TagHelper
    {
        private readonly IJobService _jobService;
        public JobAppUserIdTagHelper(IJobService jobService)
        {
            _jobService = jobService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Job> jobs =  _jobService.GetByAppUserId(AppUserId);
            int countOfCompletedJob =  jobs.Where(i => i.State).Count();
            int countOfWorkingJob = jobs.Where(i => !i.State).Count();


            string htmlString = $"Tamamladığı görev sayısı: <strong>{countOfCompletedJob}</strong><br>" +
                $"Üstünde çalıştığı görev sayısı: <strong>{countOfWorkingJob}</strong>";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
