using Microsoft.AspNetCore.Identity;
using UsersManagement.Bll.DTO;
using UsersManagement.Bll.ViewModels.UsersManagement;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.Bll.IServices;
using Emaritna.DAL.IUnitOfWork;
using System.Linq;

namespace UsersManagement.Bll.Services
{
    public class UsersManagementService : IUsersManagementService
    {
        #region Inject Objects 
        private readonly UserManager<ApplicationUser> userManager;
        #endregion

        private readonly IUnitOfWork unitOfWork;

        #region Constarctor
        public UsersManagementService(UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
        public async Task<ResponseData<string>> UserRegistration(UserRegisterViewModel _DataObj)
        {


            var ReturnData = new ResponseData<string>();

            var user = new ApplicationUser
            {
                UserName = _DataObj.Email,
                Email = _DataObj.Email,
                PhoneNumber = _DataObj.MobileNumber,
                FullName = _DataObj.FullName,
                IsActive = true,
                MobileNumber = _DataObj.MobileNumber,
                UserType = 1,

            };

            // Store user data in AspNetUsers database table
            var result = await userManager.CreateAsync(user, _DataObj.Password);


            if (result.Succeeded)
            {

                // var _user = await userManager.FindByEmailAsync(_DataObj.Email);
                // var _userAppertments = new UserApartments
                // {
                //     ApartmentNumber = _DataObj.ApartmentNumber,
                //     FloorNumber = _DataObj.FloorNumber,
                //     TowerSection = _DataObj.TowerSection,
                //     UserId = _user.Id,
                // };

                // await unitOfWork.UserApartmentsRepository.Add(_userAppertments);
                // unitOfWork.Save();

                ReturnData.Success = true;
                ReturnData.Message = "تم التسجيل بنجاح";
                return ReturnData;
            }


            ReturnData.Success = false;
            foreach (var error in result.Errors)
            {

                ReturnData.Message += error.Description + "/n";
            }

            return ReturnData;
        }


        // private async Task<bool> ValidateIfThisDataExsist(UserRegisterViewModel _DataObj)
        // {
        //     return (await unitOfWork.UserApartmentsRepository.GetWith(a => a.ApartmentNumber.Trim().Equals(_DataObj.ApartmentNumber.Trim())
        //      && a.FloorNumber == _DataObj.FloorNumber && a.TowerSection == a.TowerSection)).Any();
        // }


        #endregion
    }
}
