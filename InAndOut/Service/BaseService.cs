using InAndOut.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Service
{
    public class BaseService<T> where T:class
    {
        private readonly IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual List<T> GetAll() {
            return _repository.GetAll();
        }

        public virtual T GetById(object id) {
            return _repository.GetById(id);
        }
        public virtual void Create(T model) {
            _repository.Create(model);
        }
        public virtual void Update(T model) {
            _repository.Update(model);
        }
        public virtual void Delete(T model)
        {
            _repository.Delete(model);
        }

    }
}
