using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Bll.ViewModels.UsersManagement
{
    public class UserDataViewModel
    {

        public string Id { get; set; }

        public long AccountID { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public  string PhoneNumber { get; set; }
          
        
        public bool EmailConfirmed { get; set; }
         
        public  string Email { get; set; }

        public bool LockoutEnabled { get; set; } = false;
         
        public  int AccessFailedCount { get; set; }

    }
}
