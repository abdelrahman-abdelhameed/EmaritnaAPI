using Microsoft.AspNetCore.Identity;
using UsersManagement.Bll.DTO;
using UsersManagement.Bll.ViewModels.UsersManagement;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.Bll.IServices;
using UsersManagement.Bll.Model;


namespace UsersManagement.Bll.Services
{
    public class UserClaimsService : IUserClaimsService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserClaimsService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

         
        // get all claims  and check which one is selected for user
        public async Task<ResponseData<UserClaimsViewModel>> GetUserClaims(string UserID)
        {
            var _response = new ResponseData<UserClaimsViewModel>();

            var User = await _userManager.FindByIdAsync(UserID);

            if (User == null)
            {
             
                _response.Success = false;
                _response.Message = "User Not Found";
                return _response;

            }

            var ExistingUserClaims = await _userManager.GetClaimsAsync(User);

            var Data = new UserClaimsViewModel
            {
                UserId = UserID,
                
            };

            foreach (Claim _claim in ClaimsStore.AllClaims)
            {
                UserClaim userClaim = new UserClaim()
                {
                    ClaimType =_claim.Type
                };

                // if user has claim set is selected true 
                if (ExistingUserClaims.Any(a=>a.Type == _claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                // add this claim to return data
                Data.Claims.Add(userClaim);
            }

            _response.ReturnData = Data;
            _response.Success = true;
            _response.Message = "Done";
            return _response;
        }
    }
}
