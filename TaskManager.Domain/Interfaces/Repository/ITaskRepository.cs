using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Interfaces.Repository
{
    public interface ITaskRepository<T> : IRepositoryBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllTasks();

        Task<IEnumerable<T>> GetInRangeById(List<int> ids);

    }
}
