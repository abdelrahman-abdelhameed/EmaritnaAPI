using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class UserRegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Please Enter Valid Email Address")]
        [Required( ErrorMessage = "من فضلك ادخل البريد الالكتروني ")]
        public string Email { get; set; }


        [Required(ErrorMessage = "من فضلك اكتب الاسم كامل ")]
        [MaxLength(250 , ErrorMessage ="عدد الحروف الاقصي ٢٥٠ حرف ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "كلمة المرور مطلوبه ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "من فضلك قم بتاكيد كلمة المرور ")]
        [DataType(DataType.Password)]
        [Compare("Password" ,
            ErrorMessage = "كلمات المرور غير متطابقه")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "رقم الهاتف مطلوب ")]
        public string MobileNumber { get; set; }


        // [Required(ErrorMessage = "رقم الشقه مطلوب ")]
        // public string ApartmentNumber { get; set; }


        // [Required(ErrorMessage = " من فضلك ادخل الجانب من البرج")]
        // public byte TowerSection { get; set; }


        // [Required(ErrorMessage = "من فضلك اختر الدور")]
        // public int FloorNumber { get; set; }



        

       

    }
}
