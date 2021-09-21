using UsersManagement.Bll.DTO;
using UsersManagement.Bll.ViewModels.UsersManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UsersManagement.Bll.IServices
{
    public interface IUsersManagementService
    {

        Task<ResponseData<string>> UserRegistration(UserRegisterViewModel _DataObj);

    }
}
