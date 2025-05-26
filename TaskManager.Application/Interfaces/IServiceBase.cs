using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Interfaces
{
    public interface IServiceBase<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
    }

}
