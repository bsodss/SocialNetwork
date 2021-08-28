using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public async Task<int> SaveAsync()
        { 
            throw new NotImplementedException();
        }
    }
}
