using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Emaritna.Bll.Logger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersManagement.Bll.DTO;
using UsersManagement.Bll.IServices;
using UsersManagement.Bll.ViewModels.Authentication;
using UsersManagement.Bll.ViewModels.UsersManagement;

namespace Emaritna.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        #region injected Objects
        private readonly IUserAuthenticationService _userAuthenticationService;
        private readonly IUsersManagementService _usersManagementService;
        private readonly ILoggerService<UserApartmentController> _logger;

        #endregion

        #region Constractor
        public UsersController(IUserAuthenticationService userAuthenticationService,
            IUsersManagementService usersManagementService,
            ILoggerService<UserApartmentController> _logger)
        {
            this._userAuthenticationService = userAuthenticationService;
            this._usersManagementService = usersManagementService;
            this._logger = _logger;
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
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel _DataObj)
        {
            
            if (ModelState.IsValid)
            {
                var checkLogin = await _userAuthenticationService.Login(_DataObj);
                
                   return Ok(checkLogin);
                   
            }
            else
            {
                var Data = new AuthenticationViewmodel();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Data.ErrorMessage += error.ErrorMessage + "/n";
                    }
                }

                var msg = new HttpResponseMessage() { ReasonPhrase = Data.ErrorMessage };
                _logger.LogErrorData(Data.ErrorMessage);
                return BadRequest(msg);
            }
 
        }
        #endregion


        #region Add New User Basic Data
        [HttpPost]
        [Route("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(UserRegisterViewModel _DataObj)
        {

            if (ModelState.IsValid)
            {
                return Ok(await _usersManagementService.UserRegistration(_DataObj));
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
                _logger.LogErrorData(Data.Message);
                return BadRequest(Data);
            }


        }
        #endregion


        #region get current user data 
        [HttpGet]
        [Route("me")]
        [Authorize]
        public async Task<IActionResult> GetUserByJWT()
        {
             
            if (ModelState.IsValid)
            {
                return Ok(await _userAuthenticationService.GetUserDataByEmail(User.Identity.Name));
            }
            else
            {
                var data = new ResponseData<string>();
                data.Success = false;
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        data.Message += error.ErrorMessage + "/n";
                    }
                }
                _logger.LogErrorData(data.Message);
                return BadRequest(data);
            }


        }
        #endregion


    }
}