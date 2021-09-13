using Emaritna.DAL.Context;
using Emaritna.DAL.Entity.Clinic;
using Emaritna.DAL.IRepository;
using Emaritna.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emaritna.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork.IUnitOfWork, IDisposable
    {
        private readonly ClinicContext _context;
        private IGenericRepository<Accounts> _AccountsRepository;

         
        

        public UnitOfWork(ClinicContext context)
        {
            _context = context;
        }

        public IGenericRepository<Accounts> AccountsRepository
        {
            get
            {
                return _AccountsRepository ?? (_AccountsRepository
                  = new GenericRepository<Accounts>(_context));
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
