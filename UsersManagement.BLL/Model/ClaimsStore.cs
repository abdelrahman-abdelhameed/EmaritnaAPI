using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace UsersManagement.Bll.Model
{
    public static class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
          new Claim("Add New User" , "Add New User")
        };
     
    }
}
