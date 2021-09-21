using Emaritna.DAL.Context;
using Emaritna.DAL.Entity.Announcement;
using Emaritna.DAL.Entity.Users;
using Emaritna.DAL.IRepository;
using Emaritna.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emaritna.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork, IDisposable
    {
        private readonly EmaritnaContext _context;
        private IGenericRepository<ApplicationUser> _ApplicationUserRepository;
        private IGenericRepository<Announcements> _AnnouncementsRepository;
        private IGenericRepository<UserApartments> _UserApartmentsRepository;




        public UnitOfWork(EmaritnaContext context)
        {
            _context = context;
        }

        public IGenericRepository<ApplicationUser> ApplicationUserRepository
        {
            get
            {
                return _ApplicationUserRepository ?? (_ApplicationUserRepository
                  = new GenericRepository<ApplicationUser>(_context));
            }
        }


        public IGenericRepository<Announcements> AnnouncementsRepository
        {
            get
            {
                return _AnnouncementsRepository ?? (_AnnouncementsRepository
                  = new GenericRepository<Announcements>(_context));
            }
        }


        public IGenericRepository<UserApartments> UserApartmentsRepository
        {
            get
            {
                return _UserApartmentsRepository ?? (_UserApartmentsRepository
                  = new GenericRepository<UserApartments>(_context));
            }
        }
 
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
