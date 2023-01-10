using InAndOut.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)//, ApplicationDbContext context)
        {
           // _db = context;
            _unitOfWork = unitOfWork;
        }
        public List<T> GetAll()
        {
            //try {
            //    var data = _db.Set<T>().ToList();
            //    return data;
            //}
            //catch (Exception ex) {
            //    throw (ex);
            //}
            var data = _unitOfWork._dbCotext.Set<T>().ToList();
            return data;

        }

        public T GetById( object id)
        {
            try
            {
                return _unitOfWork._dbCotext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Create(T model) {
            try
            {
                //_db.Set<T>().Add(model);
                //_db.SaveChanges();
                _unitOfWork._dbCotext.Add(model);
                _unitOfWork.Commit();
                _unitOfWork.Dispose();
            }
            catch (Exception ex) {
                throw (ex);
            }
        }

        public void Update(T model) {
            try
            {
                //_db.Set<T>().Update(model);
                //_db.SaveChanges();
                _unitOfWork._dbCotext.Update(model);
                _unitOfWork.Commit();
                _unitOfWork.Dispose();
            }
            catch (Exception ex) {
                throw (ex);
            }
        }
        public void Delete(T model) {
            try
            {
                _unitOfWork._dbCotext.Remove(model);
                _unitOfWork.Commit();
                _unitOfWork.Dispose();
            }
            catch (Exception ex) { throw (ex); } 
        }
    }
}
