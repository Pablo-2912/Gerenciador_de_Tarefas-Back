using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskManager.Application.DTOs.Task;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Models;

namespace TaskManagement.API.Controllers
{
    [Route("api/task")]
    [ApiController]
    [AllowAnonymous]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService<TaskModel> _taskService;

        public TaskController(ITaskService<TaskModel> taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("get-by-ids")]
        public async Task<IActionResult> GetByIds([FromQuery] List<int> ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest("ID list cannot be empty.");

            var tasks = await _taskService.GetInRangeById(ids);

            if (tasks == null || !tasks.Any())
                return NotFound();

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
        {
            if (dto == null)
                return BadRequest("Task data is required.");

            if(!ModelState.IsValid)
                return BadRequest("Task data is required.");

            var taskModel = new TaskModel
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                Status = dto.Status
            };

            var createdTask = await _taskService.CreateAsync(taskModel);

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto dto)
        {
            if (dto == null)
                return BadRequest("Task data is required.");

            if (!ModelState.IsValid)
                return BadRequest("Task data is required.");

            var existingTask = await _taskService.GetByIdAsync(id);
            if (existingTask == null)
                return NotFound();

            existingTask.Titulo = dto.Titulo;
            existingTask.Descricao = dto.Descricao;
            existingTask.Status = dto.Status;

            var updatedTask = await _taskService.UpdateAsync(id, existingTask);

            return Ok(updatedTask);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
