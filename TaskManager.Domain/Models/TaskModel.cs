using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManager.Domain.Enums;
using TaskManager.Domain.Enums.Task;

namespace TaskManager.Domain.Models
{
    public class TaskModel : ModelBase
    {

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        [Required]
        public StatusTask Status { get; set; } = StatusTask.Pending;

    }
}
