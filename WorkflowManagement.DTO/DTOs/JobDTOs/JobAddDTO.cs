using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowManagement.DTO.DTOs.JobDTOs
{
    public class JobAddDTO
    {
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Title { get; set; }
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }
        //[Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz")]
        public int UrgencyId { get; set; }
    }
}
