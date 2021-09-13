using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.Bll.ViewModels.UsersManagement;

namespace UsersManagement.Bll.IServices
{
    public interface IUserAuthenticationService
    {
       Task<LoginResponseData> Login(LoginViewModel _DataObj);
    }
}
