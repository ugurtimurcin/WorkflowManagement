using System;
using System.Collections.Generic;
using System.Text;

namespace WorkflowManagement.DTO.DTOs.AppUserDTOs
{
    public class AppUserLoginDTO
    {
       // [Required(ErrorMessage = "Kullanıcı adı giriniz")]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Şifre giriniz"), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
