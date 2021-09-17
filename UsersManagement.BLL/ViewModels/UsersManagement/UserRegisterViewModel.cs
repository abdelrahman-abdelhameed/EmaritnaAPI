using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class UserRegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        [Required( ErrorMessage = "Email Address is Required")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Full Name  is Required")]
        [MaxLength(250 , ErrorMessage ="max chars for this input is 250")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare("Password" ,
            ErrorMessage = "Password And Confirmation Password don't match")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Phone Number is Required")]
        public string PhoneNumber { get; set; }

    }
}
