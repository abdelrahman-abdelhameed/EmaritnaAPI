using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Emaritna.DAL.Entity.Users
{
    public class ApplicationUser :IdentityUser
    {

        [MaxLength(250)]
        public string FullName { get; set; }

        [MaxLength(10)]
        public string ApartmentNumber { get; set; }
        
        public Nullable<byte> TowerSection { get; set; }
        
        public Nullable<int> FloorNumber { get; set; }
        
        [MaxLength(50)]
        public string MobileNumber { get; set; }

        public bool IsActive { get; set; }

    }
}
