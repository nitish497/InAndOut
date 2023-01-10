using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Infrastructure
{
    public interface IRepository<T> where T: class
    {
        List<T> GetAll();
        T GetById( object id);
        void Create(T model);
        void Update( T model);
        void Delete(T model);
    }
}
