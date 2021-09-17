using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UsersManagement.Bll.DTO;
using UsersManagement.Bll.ViewModels.UsersManagement;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UsersManagement.Bll.IServices;
using System.Linq;
using UsersManagement.Bll.ViewModels.Authentication;
//using System.Security.Principal;

namespace UsersManagement.Bll.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {

        #region inject Objetcs 
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IUserClaimsService userClaimsService;
        private readonly ApplicationSettingData appSettings;
        private readonly UserManager<ApplicationUser> userManager;

        #endregion

        #region Constractor 
        public UserAuthenticationService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<ApplicationSettingData> appSettings,
            IUserClaimsService userClaimsService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userClaimsService = userClaimsService;
            this.appSettings = appSettings.Value;
        }


        #endregion

        #region Login 
        /// <summary>
        /// this method user to authenticate User To use app
        /// this return login status and jwt token 
        /// methods paramters id view model of login it's contans {userName - Password}
        /// and method return view model of login response {  ISSuccessful >> login status , UserName , Jwt accesstoken  }
        /// </summary>
        /// <param name="_DataObj"></param>
        /// <returns></returns>
        public async Task<AuthenticationViewmodel> Login(LoginViewModel _DataObj)
        {
            var Data = new AuthenticationViewmodel();


            var CheckUser = await userManager.FindByEmailAsync(_DataObj.UserName);

            if (CheckUser != null && CheckUser.IsActive)
            {

                var result = await userManager.CheckPasswordAsync(CheckUser, _DataObj.Password);

                if (result)
                {

                    Data.ISSuccessful = result;

                    Data.AuthToken = await GenerateToken(CheckUser);
                    Data.ExpiresIn = DateTime.Now.AddDays(1);

                }
                else
                {
                    Data.ISSuccessful = false;
                    Data.ErrorMessage = "كلمة المرور غير صحيحة";
                }


            }
            else
            {
                Data.ISSuccessful = false;
                Data.ErrorMessage = "بيانات تسجيل الدخول غير صحيحه";
            }


            return Data;

        }
        #endregion


        #region Genrate Token
        private async Task<string> GenerateToken(ApplicationUser applicationUser)
        {
            var Roles = await userManager.GetRolesAsync(applicationUser);

            var Claims = await userClaimsService.GetUserClaims(applicationUser.Id);

            // var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(appSettings.JwtToken);

            var _claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, applicationUser.Email),
                new Claim(ClaimTypes.NameIdentifier , applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Nbf , new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp , new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),

            };

            // get user rolles 
            foreach (var role in Roles)
            {
                _claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // get User Claims 
            foreach (var item in Claims.ReturnData.Claims.Where(a => a.IsSelected).ToList())
            {
                _claims.Add(new Claim(ClaimTypes.WindowsUserClaim, item.ClaimType));
            }


            var tokenDescriptor = new JwtSecurityToken
            (
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)),
                    new JwtPayload(_claims));

            string Output = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);


            return Output;

        }
        #endregion

        #region get User by JWT
        public async Task<UserDataViewModel> GetUserDataByEmail(string Email)
        {
           

            // get user data
            var _userData = await userManager.FindByEmailAsync(Email);

            if (_userData != null)
            {
                return new UserDataViewModel
                {
                    ApartmentNumber = _userData.ApartmentNumber,
                    Email = _userData.Email,
                    FloorNumber = _userData.FloorNumber,
                    FullName = _userData.FullName,
                    Id = _userData.Id,
                    MobileNumber = _userData.MobileNumber,
                    TowerSection = _userData.TowerSection,
                    UserName = _userData.UserName
                };
            }

            return null;

        }


       
        #endregion





    }
}
