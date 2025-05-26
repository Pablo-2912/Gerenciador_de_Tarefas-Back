using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Application.Interfaces
{
    public interface ITaskService<T> : IServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllTasks();

        Task<IEnumerable<T>> GetInRangeById(List<int> ids);
    }
}
