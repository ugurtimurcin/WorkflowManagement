using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowManagement.DTO.DTOs.AppUserDTOs
{
    public class AppUserListDTO
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string LastName { get; set; }
        // [Required(ErrorMessage = "Bu alan boş bırakılamaz"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Picture { get; set; }
    }
}
