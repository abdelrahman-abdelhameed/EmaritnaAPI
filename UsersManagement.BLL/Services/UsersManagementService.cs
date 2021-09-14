using Microsoft.AspNetCore.Identity;
using UsersManagement.Bll.DTO;
using UsersManagement.Bll.ViewModels.UsersManagement;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.Bll.IServices;

namespace UsersManagement.Bll.Services
{
    public class UsersManagementService : IUsersManagementService
    {
        #region Inject Objects 
        private readonly UserManager<ApplicationUser> userManager;
        #endregion


        #region Constarctor
        public UsersManagementService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        #endregion


        #region Add new user 
         
        /// <summary>
        /// this method add new security user to system
        /// with required data {FullName - Email - phone number - password - account id }
        /// 
        /// </summary>
        /// <param name="_DataObj"></param>
        /// <returns></returns>
        public async Task<ResponseData<string>> AddNewUserBasicData(UserRegisterViewModel _DataObj)
        {

            var ReturnData = new ResponseData<string>();

            var user = new ApplicationUser
            {
                UserName = _DataObj.Email,
                Email = _DataObj.Email,
                PhoneNumber = _DataObj.PhoneNumber,
                FullName = _DataObj.FullName,
               
                
            };

            // Store user data in AspNetUsers database table
            var result = await userManager.CreateAsync(user, _DataObj.Password);

            

            if (result.Succeeded)
            {

                if (_DataObj.Roles.Length > 0)
                {
                    var _user = await userManager.FindByEmailAsync(_DataObj.Email);
                    for (int i = 0; i < _DataObj.Roles.Length; i++)
                    {
                        var AddRole = await userManager.AddToRoleAsync(_user, _DataObj.Roles[i]);

                    }
                }

                ReturnData.Success = true;
                ReturnData.Message = "User Added Successfully";
                var User = await userManager.FindByEmailAsync(_DataObj.Email);
                ReturnData.ReturnData = User.Id;
                return ReturnData;
            }


            ReturnData.Success = false;
            foreach (var error in result.Errors)
            {

                ReturnData.Message += error.Description + "/n";
            }

            return ReturnData;
        }

        #endregion
    }
}
