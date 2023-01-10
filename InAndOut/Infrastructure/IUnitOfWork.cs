using Microsoft.EntityFrameworkCore;
using System;

namespace InAndOut.Infrastructure
{
    public interface IUnitOfWork:IDisposable
    {

         DbContext _dbCotext { get; }
        void Commit();

    }
}
