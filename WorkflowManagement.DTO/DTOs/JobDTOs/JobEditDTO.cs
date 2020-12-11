using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowManagement.DTO.DTOs.JobDTOs
{
    public class JobEditDTO
    {
        public int Id { get; set; }
        // [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Title { get; set; }
        // [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }
        // [Required(ErrorMessage = "Aciliyet durumu seçiniz")]
        public int UrgencyId { get; set; }
    }
}
