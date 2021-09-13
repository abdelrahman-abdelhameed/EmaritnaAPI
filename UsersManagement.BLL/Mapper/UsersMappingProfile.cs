using AutoMapper;
using UsersManagement.Bll.ViewModels.UsersManagement;
using Emaritna.DAL.Entity.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Bll.Mapper
{
    public class UsersMappingProfile : Profile
    {
        public UsersMappingProfile()
        {

            CreateMap<ApplicationUser, UserDataViewModel>().ReverseMap();

        }
    }
    
}
