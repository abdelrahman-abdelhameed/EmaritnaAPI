using Emaritna.DAL.Entity.Announcement;
using Emaritna.DAL.Entity.Users;
using Emaritna.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emaritna.DAL.IUnitOfWork
{
    public interface IUnitOfWork
    {

        IGenericRepository<ApplicationUser> ApplicationUserRepository { get; }
        IGenericRepository<Announcements> AnnouncementsRepository { get; }
        
        void Save();


    }
}
