using System;
using System.Collections.Generic;
using System.Text;
using WorkflowManagement.Entities.Concrete;

namespace WorkflowManagement.DTO.DTOs.ReportDTOs
{
    public class ReportEditDTO
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
    }
}
