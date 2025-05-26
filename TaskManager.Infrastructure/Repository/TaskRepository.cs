using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Context;

namespace TaskManager.Infrastructure.Repository
{
    public class TaskRepository : RepositoryBase<TaskModel>, ITaskRepository<TaskModel>
    {
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<TaskModel>> GetInRangeById(List<int> ids)
        {
            return await _dbSet.Where(task => ids.Contains(task.Id)).ToListAsync();
        }
    }
}
