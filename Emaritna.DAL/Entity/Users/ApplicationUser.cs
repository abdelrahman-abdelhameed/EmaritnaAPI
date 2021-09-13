using Microsoft.AspNetCore.Identity;
using Emaritna.DAL.Entity.Clinic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Emaritna.DAL.Entity.Users
{
    public class ApplicationUser :IdentityUser
    {
        public long AccountID { get; set; }

        [MaxLength(250)]
        public string FullName { get; set; }


        [ForeignKey("AccountID")]
        public Accounts Account { get; set; }
    }
}
