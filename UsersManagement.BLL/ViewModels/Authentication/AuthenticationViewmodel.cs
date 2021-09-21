using System;
namespace UsersManagement.Bll.ViewModels.Authentication
{
    public class AuthenticationViewmodel
    {

        public string AuthToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime ExpiresIn { get; set; }

        public bool ISSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
