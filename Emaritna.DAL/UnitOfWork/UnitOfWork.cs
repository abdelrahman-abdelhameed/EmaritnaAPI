using Emaritna.DAL.Context;
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
