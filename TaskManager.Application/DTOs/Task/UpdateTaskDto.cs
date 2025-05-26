using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums.Task;

namespace TaskManager.Application.DTOs.Task
{
    public class UpdateTaskDto
    {
        [Required]
        public string Titulo { get; set; } = null!;
        public string? Descricao { get; set; }
       // public DateTime? DataConclusao { get; set; } = null;
        [Required]
        public StatusTask Status { get; set; }
    }
}
