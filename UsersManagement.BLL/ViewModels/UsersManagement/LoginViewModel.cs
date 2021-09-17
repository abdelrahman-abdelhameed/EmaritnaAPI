using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="من فضلك اكتب البريد الالكتروني ")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "من فضلك اكتب كلمة المرور")]
        public string Password { get; set; }
    }
}
