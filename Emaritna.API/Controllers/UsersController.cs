using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Bll.DTO;
using UsersManagement.Bll.IServices;
using UsersManagement.Bll.ViewModels.UsersManagement;

namespace Emaritna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        #region injected Objects
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IUsersManagementService usersManagementService;
        #endregion

        #region Constractor
        public UsersController(IUserAuthenticationService userAuthenticationService,
            IUsersManagementService usersManagementService)
        {
            this._userAuthenticationService = userAuthenticationService;
            this.usersManagementService = usersManagementService;
        }
        #endregion

        #region Login 
        /// <summary>
        /// this method to  Authenticat User Login 
        /// it takes 2 paramters UserName (User Email) and password 
        /// and return the following data 
        ///  -- in case of model is valid 
        ///  -  ISSuccessful >> login status 
        ///  - Token  if  ISSuccessful = treu
        ///  - ErrorMessage if ISSuccessful = false
        ///  - user name 
        ///  -- in case model not valid
        ///   - return bad request with model errors 
        ///  
        /// </summary>
        /// <param name="_DataObj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel _DataObj)
        {
            
            if (ModelState.IsValid)
            {
                var checkLogin = await _userAuthenticationService.Login(_DataObj);
                if (checkLogin.ISSuccessful)
                {
                    return Ok(checkLogin);
                }
                else
                {
                      
                    return BadRequest(checkLogin);
                }
            }
            else
            {
                var Data = new LoginResponseData();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Data.ErrorMessage += error.ErrorMessage + "/n";
                    }
                }

                var msg = new HttpResponseMessage() { ReasonPhrase = Data.ErrorMessage };
                return BadRequest(msg);
            }

           
        }
        #endregion


        #region Add New User Basic Data
        [HttpPost]
        [Route("AddNewUserBasicData")]
        public async Task<IActionResult> AddNewUserBasicData(UserRegisterViewModel _DataObj)
        {

            if (ModelState.IsValid)
            {
                var AddUser = await usersManagementService.AddNewUserBasicData(_DataObj);
                if (AddUser.Success)
                {
                    return Ok(AddUser);
                }
                else
                {

                    return BadRequest(AddUser);
                }
            }
            else
            {
                var Data = new ResponseData<string>();
                Data.Success = false;
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Data.Message += error.ErrorMessage + "/n";
                    }
                }

              
                return BadRequest(Data);
            }


        }
        #endregion
    }
}