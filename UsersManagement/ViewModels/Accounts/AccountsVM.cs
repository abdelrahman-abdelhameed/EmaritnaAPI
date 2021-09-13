using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UsersManagement.Bll.ViewModels.BaseViewModel;

namespace UsersManagement.Bll.ViewModels.Accounts
{
    public class AccountsVM : BaseViewModel<long>
    {
         
        public Guid Serial { get; set; } = Guid.NewGuid();

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string PhoneNumber1 { get; set; }

        [MaxLength(50)]
        public string PhoneNumber2 { get; set; }

        [MaxLength(50)]
        public string Mobile1 { get; set; }

        [MaxLength(50)]
        public string Mobile2 { get; set; }

        public Nullable<int> CityID { get; set; } // will add by suber admin 

        public Nullable<long> ParentID { get; set; }


        [MaxLength(150)]
        public string DomainName { get; set; }


        public Nullable<int> PlanID { get; set; } // will add to parent clinic only 

        public bool Islocked { get; set; } = false; // if account temporary locked


    }
}
