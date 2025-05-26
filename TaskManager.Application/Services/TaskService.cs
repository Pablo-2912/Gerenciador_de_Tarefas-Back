using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Enums.Task;
using TaskManager.Domain.Interfaces.Repository;
using TaskManager.Domain.Models;

namespace TaskManager.Application.Services
{
    public class TaskService : ServiceBase<TaskModel>, ITaskService<TaskModel>
    {
        private readonly ITaskRepository<TaskModel> _taskRepository;

        public TaskService(ITaskRepository<TaskModel> taskRepository) : base(taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public override Task<TaskModel> UpdateAsync(int id, TaskModel entity)
        {
            if (entity.Status == StatusTask.Completed || (entity.DataConclusao is not null && entity.DataCadastro < entity.DataConclusao) )
                entity.DataConclusao = DateTime.Now;

            else
                entity.DataConclusao = null;

            return base.UpdateAsync(id, entity);
        }

        public async Task<IEnumerable<TaskModel>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        public async Task<IEnumerable<TaskModel>> GetInRangeById(List<int> ids)
        {
            return await _taskRepository.GetInRangeById(ids);
        }
    }

}
