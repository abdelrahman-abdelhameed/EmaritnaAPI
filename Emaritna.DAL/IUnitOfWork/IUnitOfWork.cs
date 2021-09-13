using Emaritna.DAL.Entity.Clinic;
using Emaritna.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emaritna.DAL.IUnitOfWork
{
    public interface IUnitOfWork
    {

        IGenericRepository<Accounts> AccountsRepository { get; }
        
        void Save();


    }
}
