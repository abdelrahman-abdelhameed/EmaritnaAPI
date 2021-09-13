using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email Is Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }
    }
}
