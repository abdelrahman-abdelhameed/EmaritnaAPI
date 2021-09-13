using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class LoginResponseData
    {
        public string UserName { get; set; }

        public string AccessToken { get; set; }

        public bool ISSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
