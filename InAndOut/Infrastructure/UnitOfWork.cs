using InAndOut.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public DbContext _dbCotext { get { return _applicationDbContext; } }

        public void Commit()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
