using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowManagement.DTO.DTOs.UrgencyDTOs
{
    public class UrgencyEditDTO
    {
        public int Id { get; set; }

        // [Required(ErrorMessage = "Başlık alanı boş bırakılamaz")]
        public string Title { get; set; }
    }
}
