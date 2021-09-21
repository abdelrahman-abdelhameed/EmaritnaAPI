using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class UserDataViewModel
    {

        public string Id { get; set; }


        public string FullName { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }


        public string ApartmentNumber { get; set; }


        public string Email { get; set; }

        public string Pic { get; set; } = string.Empty;


        public int? FloorNumber { get; set; }

        public byte? TowerSection { get; set; }



    }
}
