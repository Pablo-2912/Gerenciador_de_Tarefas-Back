using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Models
{
    public abstract class ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime? DataConclusao { get; set; }
    }
}
