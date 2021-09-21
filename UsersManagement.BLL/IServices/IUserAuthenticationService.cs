using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.Bll.ViewModels.Authentication;
using UsersManagement.Bll.ViewModels.UsersManagement;

namespace UsersManagement.Bll.IServices
{
    public interface IUserAuthenticationService
    {
        Task<AuthenticationViewmodel> Login(LoginViewModel _DataObj);

        Task<UserDataViewModel> GetUserDataByEmail(string Email);
    }
}
