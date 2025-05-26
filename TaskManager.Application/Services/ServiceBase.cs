using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Interfaces.Repository;

namespace TaskManager.Application.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        protected readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> UpdateAsync(int id, T entity)
        {


            return await _repository.UpdateAsync(id, entity);
        }
    }

}
